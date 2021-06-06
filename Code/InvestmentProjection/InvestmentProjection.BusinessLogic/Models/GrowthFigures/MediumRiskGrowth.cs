using System;

namespace InvestmentProjection.BusinessLogic.Models.GrowthFigures
{
    public class MediumRiskGrowth : IGrowthFigures
    {
        public Tuple<decimal, decimal> WideBounds => new Tuple<decimal, decimal>(0, 5m);
        public Tuple<decimal, decimal> NarrowBounds => new Tuple<decimal, decimal>(1.5m, 3.5m);
    }
}
