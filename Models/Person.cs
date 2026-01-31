namespace InsuranceClientEvaluation.Models
{
    public class Person
    {
        public int Age { get; set; }
        public bool HasHealthChallenges { get; set; }
        public int NumberOfDependents { get; set; }
        public decimal AnnualIncome { get; set; }
        public bool HasPreviousClaims { get; set; }
    }
}
