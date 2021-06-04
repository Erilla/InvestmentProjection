using System.ComponentModel.DataAnnotations;

namespace InvestmentProjection.Models.Api
{
    public class CalculateChartDataRequest
    {
        [Required]
        public decimal LumpSumInvestment { get; init; }

        [Required]
        public decimal MonthlyInvestment { get; init; }

        [Required]
        public decimal TargetValue { get; init; }

        [Required]
        public int Timescale { get; init; }

        [Required]
        public RiskLevel RiskLevel { get; init; }
    }
}
