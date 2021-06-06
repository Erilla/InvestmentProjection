using InvestmentProjection.BusinessLogic.Models;
using InvestmentProjection.BusinessLogic.Models.Requests;
using System.Threading.Tasks;

namespace InvestmentProjection.BusinessLogic.Handlers.CalculationsHandler
{
    public interface ICalculationsHandler
    {
        Task<ChartData> GetChartDataAsync(CalculateChartDataRequest request);
    }
}
