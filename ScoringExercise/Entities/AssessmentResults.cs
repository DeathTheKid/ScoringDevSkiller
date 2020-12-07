namespace ScoringExercise.Entities
{
    /// <summary>
    /// Represents the results of a single assessment instance
    /// </summary>
    public class AssessmentResults
    {
        public int ItemsAttempted { get; set; }
        public int ItemsCorrect { get; set; }
        public int TotalMarksAwarded { get; set; }
    }
}