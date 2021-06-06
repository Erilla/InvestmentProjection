using System.Collections.ObjectModel;

namespace InvestmentProjection.BusinessLogic.Models
{
    public class ChartData
    {
        public Collection<int> Labels { get; set; }
        public Collection<GraphDataSet> TotalInvestedDataSet { get; set; }
    }
}
