using System;

namespace InvestmentProjection.BusinessLogic.Models.GrowthFigures
{
    public static class GrowthFactory
    {
        public static IGrowthFigures Build(RiskLevel risklevel)
        {
            switch (risklevel)
            {
                case RiskLevel.Low:
                    return new LowRiskGrowth();
                case RiskLevel.Medium:
                    return new MediumRiskGrowth();
                case RiskLevel.High:
                    return new HighRiskGrowth();
                default:
                    throw new ArgumentException("Risk Level not recognised");
            }
        }
    }
}
