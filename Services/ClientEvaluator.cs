using InsuranceClientEvaluation.Models;
using InsuranceClientEvaluation.Rules;

namespace InsuranceClientEvaluation.Services
{
    public class ClientEvaluator
    {
        public ClientEvaluationResult Evaluate(Person person)
        {
            if (!IsEligible(person))
            {
                return new ClientEvaluationResult
                {
                    IsEligible = false
                };
            }

            var tier = DetermineTier(person);
            tier = ApplyClaimDowngrade(person, tier);
            var risk = DetermineRisk(person);

            return new ClientEvaluationResult
            {
                IsEligible = true,
                Tier = tier,
                RiskLevel = risk
            };
        }

        private bool IsEligible(Person person)
        {
            return person.Age >= EvaluationRules.MinAge &&
                   person.Age <= EvaluationRules.MaxAge;
        }

        private ClientTier DetermineTier(Person person)
        {
            if (person.Age >= EvaluationRules.SeniorAge)
                return ClientTier.Senior;

            if (person.HasHealthChallenges)
                return ClientTier.Care;

            if (person.NumberOfDependents > EvaluationRules.MaxDependents)
                return ClientTier.Family;

            if (person.AnnualIncome > EvaluationRules.PremiumIncome)
                return ClientTier.Premium;

            return ClientTier.Standard;
        }

        private ClientTier ApplyClaimDowngrade(Person person, ClientTier tier)
        {
            if (person.HasPreviousClaims && person.Age >= 40)
            {
                return tier > ClientTier.Standard
                    ? tier - 1
                    : ClientTier.Standard;
            }

            return tier;
        }

        private RiskLevel DetermineRisk(Person person)
        {
            return (person.HasHealthChallenges && person.HasPreviousClaims)
                ? RiskLevel.High
                : RiskLevel.Normal;
        }
    }
}
