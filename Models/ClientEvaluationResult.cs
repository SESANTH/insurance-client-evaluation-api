namespace InsuranceClientEvaluation.Models
{
    public class ClientEvaluationResult
    {
        public bool IsEligible { get; set; }
        public ClientTier Tier { get; set; }
        public RiskLevel RiskLevel { get; set; }
    }
}
