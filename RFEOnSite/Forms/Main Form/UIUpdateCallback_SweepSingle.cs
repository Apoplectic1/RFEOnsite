namespace RFEOnSite
{
    public partial class MainForm
    {
        public void UIUpdateCallback_SweepSingle(string sweepsFromExplorer)
        {
            gRFEOnSite.Chart.DrawChart(sweepsFromExplorer, gRFEOnSite.CurrentSweepNumber);

            double AllBlockCompositeDbms = gRFEOnSite.Chart.DrawSweepBlock(gRFEOnSite.BlockTableList);

            gRFEOnSite.Chart.SetChartYLimits();

            gRFEOnSite.Explorer.SweepValueStable = gRFEOnSite.StableSweep.StableCheck(AllBlockCompositeDbms);

            gRFEOnSite.CurrentSweepNumber++;
        }
    }
}
