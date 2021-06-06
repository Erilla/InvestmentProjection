using InvestmentProjection.BusinessLogic.Models;
using InvestmentProjection.BusinessLogic.Models.GrowthFigures;
using System;

namespace InvestmentProjection.BusinessLogic.Handlers.GrowthFigureHandler
{
    public class GrowthFigureHandler : IGrowthFigureHandler
    {
        public Tuple<decimal, decimal> GetWideBoundsFigures(RiskLevel risklevel, decimal currentInvestment)
        {
            var growthFigures = GrowthFactory.Build(risklevel);

            return new Tuple<decimal, decimal>(
                    CalculateFigure(currentInvestment, growthFigures.WideBounds.Item1), 
                    CalculateFigure(currentInvestment, growthFigures.WideBounds.Item2)
                );
        }

        public Tuple<decimal, decimal> GetNarrowBoundsFigures(RiskLevel risklevel, decimal currentInvestment)
        {
            var growthFigures = GrowthFactory.Build(risklevel);

            return new Tuple<decimal, decimal>(
                    CalculateFigure(currentInvestment, growthFigures.NarrowBounds.Item1),
                    CalculateFigure(currentInvestment, growthFigures.NarrowBounds.Item2)
                );
        }

        private decimal CalculateFigure(decimal currentInvestment, decimal percentage)
        {
            return currentInvestment + currentInvestment * (percentage / 100);
        }
    }
}
