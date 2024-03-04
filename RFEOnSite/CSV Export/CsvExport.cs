using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace RFEOnSite
{
    // Simple CSV export
    // Example:
    //   CsvExport myExport = new CsvExport();
    //
    //   myExport.AddRow();
    //   myExport["Region"] = "New York, USA";
    //   myExport["Sales"] = 100000;
    //   myExport["Date Opened"] = new DateTime(2003, 12, 31);
    //
    //   myExport.AddRow();
    //   myExport["Region"] = "Sydney \"in\" Australia";
    //   myExport["Sales"] = 50000;
    //   myExport["Date Opened"] = new DateTime(2005, 1, 1, 9, 30, 0);
    //
    // Then you can do any of the following three output options:
    //   string myCsv = myExport.Export();
    //   myExport.ExportToFile("Somefile.csv");
    //   byte[] myCsvData = myExport.ExportToBytes();
    
   	public class CsvExport
    {
        private List<string> mFields = new List<string>();
        private List<Dictionary<string, object>> mRows = new List<Dictionary<string, object>>();
        private readonly string mColumnSeparator;
        private readonly bool mIncludeColumnSeparatorDefinitionPreamble;

        private Dictionary<string, object> CurrentRow { get { return mRows[mRows.Count - 1]; } }
 

        public CsvExport(string columnSeparator = ",", bool includeColumnSeparatorDefinitionPreamble = false)
        {
            mColumnSeparator = columnSeparator;
            mIncludeColumnSeparatorDefinitionPreamble = includeColumnSeparatorDefinitionPreamble;  
        }
        
        public object this[string field]
        {
            set
            {
                // Keep track of the field names, because the dictionary loses the ordering
                if (!mFields.Contains(field)) mFields.Add(field);
                CurrentRow[field] = value;
            }
        }
       
        public void AddRow()
        {
            mRows.Add(new Dictionary<string, object>());
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
            if (mIncludeColumnSeparatorDefinitionPreamble) yield return "sep=" + mColumnSeparator;

            // The header
            yield return string.Join(mColumnSeparator, mFields);

            // The rows
            foreach (Dictionary<string, object> row in mRows)
            {
                foreach (string k in mFields.Where(f => !row.ContainsKey(f)))
                {
                    row[k] = null;
                }
                yield return string.Join(mColumnSeparator, mFields.Select(field => MakeValueCsvFriendly(row[field], mColumnSeparator)));
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
            // Creates a new file, writes a collection of strings to the file, and then closes the file.
            File.WriteAllLines(path, ExportToLines(), Encoding.UTF8);
        }

        public byte[] ExportToBytes()
        {
            var data = Encoding.UTF8.GetBytes(Export());
            return Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        }
    }
}