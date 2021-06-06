using System;

namespace InvestmentProjection.BusinessLogic.Models.GrowthFigures
{
    public class HighRiskGrowth : IGrowthFigures
    {
        public Tuple<decimal, decimal> WideBounds => new Tuple<decimal, decimal>(-1m, 7m);
        public Tuple<decimal, decimal> NarrowBounds => new Tuple<decimal, decimal>(2m, 4m);
    }
}
