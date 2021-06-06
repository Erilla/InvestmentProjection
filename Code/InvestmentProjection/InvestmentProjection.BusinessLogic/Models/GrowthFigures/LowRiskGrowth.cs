using System;

namespace InvestmentProjection.BusinessLogic.Models.GrowthFigures
{
    public class LowRiskGrowth : IGrowthFigures
    {
        public Tuple<decimal, decimal> WideBounds => new Tuple<decimal, decimal>(1m, 3m);
        public Tuple<decimal, decimal> NarrowBounds => new Tuple<decimal, decimal>(1.5m, 2.5m);
    }
}
