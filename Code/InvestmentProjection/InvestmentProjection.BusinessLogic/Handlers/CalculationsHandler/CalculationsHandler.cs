using InvestmentProjection.BusinessLogic.Handlers.GrowthFigureHandler;
using InvestmentProjection.BusinessLogic.Models;
using InvestmentProjection.BusinessLogic.Models.Requests;
using System;
using System.Collections.ObjectModel;

namespace InvestmentProjection.BusinessLogic.Handlers.CalculationsHandler
{
    public class CalculationsHandler : ICalculationsHandler
    {
        private readonly IGrowthFigureHandler _growthFigureHandler;

        public CalculationsHandler(IGrowthFigureHandler growthFigureHandler)
        {
            _growthFigureHandler = growthFigureHandler;
        }

        public ChartData GetChartData(CalculateChartDataRequest request)
        {
            var totalInvestedDataSet = GenerateTotalInvsetmentDataSet(request.LumpSumInvestment, request.MonthlyInvestment, request.Timescale);
            var wideBoundsDataSet = GenerateWideBoundsGrowth(totalInvestedDataSet, request.RiskLevel);
            var narrowBoundsDataSet = GenerateNarrowBoundsGrowth(totalInvestedDataSet, request.RiskLevel);

            return new ChartData
            {
                Labels = GenerateLabels(request.Timescale),
                TotalInvestedDataSet = totalInvestedDataSet,
                WideLowerBoundsGrowth = wideBoundsDataSet.Item1,
                WideUpperBoundsGrowth = wideBoundsDataSet.Item2,
                NarrowLowerBoundsGrowth = narrowBoundsDataSet.Item1,
                NarrowUpperBoundsGrowth = narrowBoundsDataSet.Item2,
            };
        }

        private Tuple<Collection<GraphDataSet>, Collection<GraphDataSet>> GenerateNarrowBoundsGrowth(Collection<GraphDataSet> totalInvestedDataSet, RiskLevel riskLevel)
        {
            var upperBounds = new Collection<GraphDataSet>();
            var lowerBounds = new Collection<GraphDataSet>();

            foreach (var currentInvestedDataPoint in totalInvestedDataSet)
            {
                var figures = _growthFigureHandler.GetNarrowBoundsFigures(riskLevel, currentInvestedDataPoint.Y);

                upperBounds.Add(new GraphDataSet
                {
                    X = currentInvestedDataPoint.X,
                    Y = figures.Item1
                });

                lowerBounds.Add(new GraphDataSet
                {
                    X = currentInvestedDataPoint.X,
                    Y = figures.Item2
                });
            }

            var result = new Tuple<Collection<GraphDataSet>, Collection<GraphDataSet>>(upperBounds, lowerBounds);

            return result;
        }

        private Tuple<Collection<GraphDataSet>, Collection<GraphDataSet>> GenerateWideBoundsGrowth(Collection<GraphDataSet> totalInvestedDataSet, RiskLevel riskLevel)
        {
            var upperBounds = new Collection<GraphDataSet>();
            var lowerBounds = new Collection<GraphDataSet>();

            foreach (var currentInvestedDataPoint in totalInvestedDataSet)
            {
                var figures = _growthFigureHandler.GetWideBoundsFigures(riskLevel, currentInvestedDataPoint.Y);

                upperBounds.Add(new GraphDataSet
                {
                    X = currentInvestedDataPoint.X,
                    Y = figures.Item1
                });

                lowerBounds.Add(new GraphDataSet
                {
                    X = currentInvestedDataPoint.X,
                    Y = figures.Item2
                });
            }

            var result = new Tuple<Collection<GraphDataSet>, Collection<GraphDataSet>>(upperBounds, lowerBounds);

            return result;
        }

        private Collection<int> GenerateLabels(int timeScale)
        {
            var result = new Collection<int>();
            for (int i = 0; i < GetNumberOfYearsToDisplay(timeScale); i++)
            {
                result.Add(i);
            }
            return result;
        }

        private Collection<GraphDataSet> GenerateTotalInvsetmentDataSet(decimal lumpSum, decimal monthlyInvestment, int timeScale)
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

            return result;
        }

        private int GetNumberOfYearsToDisplay(int timeScale) => (int)(timeScale + Math.Ceiling(timeScale * Constants.Grace));
    }
}
