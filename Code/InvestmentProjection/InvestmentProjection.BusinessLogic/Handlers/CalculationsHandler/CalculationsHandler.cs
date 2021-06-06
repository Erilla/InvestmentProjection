using InvestmentProjection.BusinessLogic.Models;
using InvestmentProjection.BusinessLogic.Models.Requests;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace InvestmentProjection.BusinessLogic.Handlers.CalculationsHandler
{
    public class CalculationsHandler : ICalculationsHandler
    {
        public async Task<ChartData> GetChartDataAsync(CalculateChartDataRequest request)
        {
            return new ChartData
            {
                Labels = await GenerateLabels(request.Timescale),
                TotalInvestedDataSet = await GenerateTotalInvsetmentDataSet(request.LumpSumInvestment, request.MonthlyInvestment, request.Timescale)
            };
        }

        private Task<Collection<int>> GenerateLabels(int timeScale)
        {
            var result = new Collection<int>();
            for (int i = 0; i < GetNumberOfYearsToDisplay(timeScale); i++)
            {
                result.Add(i);
            }
            return Task.FromResult(result);
        }

        private Task<Collection<GraphDataSet>> GenerateTotalInvsetmentDataSet(decimal lumpSum, decimal monthlyInvestment, int timeScale)
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddYears(GetNumberOfYearsToDisplay(timeScale));

            var numberOfPoints = (endDate.Year - startDate.Year) * 12 + startDate.Month - endDate.Month;

            var currentInvestment = lumpSum;

            var result = new Collection<GraphDataSet>()
            {
                new GraphDataSet { X = 0, Y = currentInvestment }
            };

            for (int i = 0; i < numberOfPoints; i++)
            {
                currentInvestment += monthlyInvestment;
                result.Add(new GraphDataSet
                {
                    X = (i+1)/12m,
                    Y = currentInvestment
                });
            }

            return Task.FromResult(result);
        }

        private int GetNumberOfYearsToDisplay(int timeScale) => (int)(timeScale + Math.Ceiling(timeScale * 0.2));
    }
}
