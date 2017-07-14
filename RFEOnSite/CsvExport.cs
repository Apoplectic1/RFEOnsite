using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace RFEOnSite
{

    /// <summary>
    /// Simple CSV export
    /// Example:
    ///   CsvExport myExport = new CsvExport();
    ///
    ///   myExport.AddRow();
    ///   myExport["Region"] = "New York, USA";
    ///   myExport["Sales"] = 100000;
    ///   myExport["Date Opened"] = new DateTime(2003, 12, 31);
    ///
    ///   myExport.AddRow();
    ///   myExport["Region"] = "Sydney \"in\" Australia";
    ///   myExport["Sales"] = 50000;
    ///   myExport["Date Opened"] = new DateTime(2005, 1, 1, 9, 30, 0);
    ///
    /// Then you can do any of the following three output options:
    ///   string myCsv = myExport.Export();
    ///   myExport.ExportToFile("Somefile.csv");
    ///   byte[] myCsvData = myExport.ExportToBytes();
    /// </summary>
   	public class CsvExport
    {
        List<string> _fields = new List<string>();
        List<Dictionary<string, object>> _rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> _currentRow { get { return _rows[_rows.Count - 1]; } }
        private readonly string _columnSeparator;
        private readonly bool _includeColumnSeparatorDefinitionPreamble;
        public CsvExport(string columnSeparator = ",", bool includeColumnSeparatorDefinitionPreamble = true)
        {
            _columnSeparator = columnSeparator;
            _includeColumnSeparatorDefinitionPreamble = includeColumnSeparatorDefinitionPreamble;
        }
        
        public object this[string field]
        {
            set
            {
                // Keep track of the field names, because the dictionary loses the ordering
                if (!_fields.Contains(field)) _fields.Add(field);
                _currentRow[field] = value;
            }
        }
       
        public void AddRow()
        {
            _rows.Add(new Dictionary<string, object>());
        }
        
        public void AddRows<T>(IEnumerable<T> list)
        {
            if (list.Any())
            {
                foreach (var obj in list)
                {
                    AddRow();
                    var values = obj.GetType().GetProperties();
                    foreach (var value in values)
                    {
                        this[value.Name] = value.GetValue(obj, null);
                    }
                }
            }
        }

        public static string MakeValueCsvFriendly(object value, string columnSeparator = ",")
        {
            if (value == null) return "";
            if (value is INullable && ((INullable)value).IsNull) return "";
            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString().Trim();
            if (output.Contains(columnSeparator) || output.Contains("\"") || output.Contains("\n") || output.Contains("\r"))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            if (output.Length > 30000) //cropping value for stupid Excel
            {
                if (output.EndsWith("\""))
                {
                    output = output.Substring(0, 30000);
                    if (output.EndsWith("\"") && !output.EndsWith("\"\"")) //rare situation when cropped line ends with a '"'
                        output += "\""; //add another '"' to escape it
                    output += "\"";
                }
                else
                    output = output.Substring(0, 30000);
            }
            return output;
        }

        private IEnumerable<string> ExportToLines()
        {
            if (_includeColumnSeparatorDefinitionPreamble) yield return "sep=" + _columnSeparator;

            // The header
            yield return string.Join(_columnSeparator, _fields);

            // The rows
            foreach (Dictionary<string, object> row in _rows)
            {
                foreach (string k in _fields.Where(f => !row.ContainsKey(f)))
                {
                    row[k] = null;
                }
                yield return string.Join(_columnSeparator, _fields.Select(field => MakeValueCsvFriendly(row[field], _columnSeparator)));
            }
        }

        public string Export()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string line in ExportToLines())
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
        
        public void ExportToFile(string path)
        {
            File.WriteAllLines(path, ExportToLines(), Encoding.UTF8);
        }

        public byte[] ExportToBytes()
        {
            var data = Encoding.UTF8.GetBytes(Export());
            return Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        }




    }
}