using InvestmentProjection.BusinessLogic.Models;
using InvestmentProjection.BusinessLogic.Models.Requests;
using System;
using System.Collections.ObjectModel;

namespace InvestmentProjection.BusinessLogic.Handlers.CalculationsHandler
{
    public class CalculationsHandler : ICalculationsHandler
    {
        public ChartData GetChartData(CalculateChartDataRequest request)
        {
            var totalInvestmentDataSet = GenerateTotalInvsetmentDataSet(request.LumpSumInvestment, request.MonthlyInvestment, request.Timescale);
            return new ChartData
            {
                TotalInvestedDataSet = totalInvestmentDataSet
            };
        }

        private Collection<GraphDataSet> GenerateTotalInvsetmentDataSet(decimal LumpSum, decimal MonthlyInvestment, int TimeScale)
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddYears((int)(TimeScale + Math.Floor(TimeScale * 0.2)));

            var numberOfPoints = (endDate.Year - startDate.Year) * 12 + startDate.Month - endDate.Month;

            var currentInvestment = LumpSum;

            var result = new Collection<GraphDataSet>()
            {
                new GraphDataSet { X = 0, Y = currentInvestment }
            };

            for (int i = 0; i < numberOfPoints; i++)
            {
                currentInvestment += MonthlyInvestment;
                result.Add(new GraphDataSet
                {
                    X = i+1,
                    Y = currentInvestment
                });
            }

            return result;
        }
    }
}
