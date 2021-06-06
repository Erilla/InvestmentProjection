using InvestmentProjection.BusinessLogic.Models;
using System;

namespace InvestmentProjection.BusinessLogic.Handlers.GrowthFigureHandler
{
    public interface IGrowthFigureHandler
    {
        Tuple<decimal, decimal> GetWideBoundsFigures(RiskLevel risklevel, decimal currentInvestment);
        Tuple<decimal, decimal> GetNarrowBoundsFigures(RiskLevel risklevel, decimal currentInvestment);
    }
}
