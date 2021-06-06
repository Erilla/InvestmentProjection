using System;

namespace InvestmentProjection.BusinessLogic.Models.GrowthFigures
{
    public interface IGrowthFigures
    {
        Tuple<decimal, decimal> WideBounds { get; }
        Tuple<decimal, decimal> NarrowBounds { get; }
    }
}
