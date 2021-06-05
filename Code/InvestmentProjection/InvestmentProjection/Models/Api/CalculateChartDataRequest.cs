using System.ComponentModel.DataAnnotations;

namespace InvestmentProjection.Models.Api
{
    public class CalculateChartDataRequest
    {
        [Required]
        [Display(Name = "Lump Sum Investment (£)")]
        public decimal LumpSumInvestment { get; init; }

        [Required]
        [Display(Name = "Monthly Investment (£)")]
        public decimal MonthlyInvestment { get; init; }

        [Required]
        [Display(Name = "Target Value (£)")]
        public decimal TargetValue { get; init; }

        [Required]
        [Display(Name = "Timescale (Years)")]
        public int Timescale { get; init; }

        [Required]
        [Display(Name = "Risk Level")]
        public RiskLevel RiskLevel { get; init; }
    }
}
