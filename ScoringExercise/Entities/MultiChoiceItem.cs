namespace ScoringExercise.Entities
{
    /// <summary>
    /// Represents a single multi-choice item in an assessment
    /// </summary>
    public class MultiChoiceItem
    {
        // the text associated with the item aka the question
        public string ItemText { get; set; }
        // the option strings from which the candidate chooses a response
        public string[] Options { get; set; }
        // the index of the correct answer from within the Options array
        public int CorrectAnswerIndex { get; set; }
        // the number of marks awarded if the correct response is chosen
        public int MarksAwardedIfCorrect { get; set; }
    }
}