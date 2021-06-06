using System.Collections.ObjectModel;

namespace InvestmentProjection.BusinessLogic.Models
{
    public class ChartData
    {
        public Collection<int> Labels { get; set; }
        public Collection<GraphDataSet> TotalInvestedDataSet { get; set; }
        public Collection<GraphDataSet> WideUpperBoundsGrowth { get; set; }
        public Collection<GraphDataSet> WideLowerBoundsGrowth { get; set; }
        public Collection<GraphDataSet> NarrowUpperBoundsGrowth { get; set; }
        public Collection<GraphDataSet> NarrowLowerBoundsGrowth { get; set; }
    }
}
