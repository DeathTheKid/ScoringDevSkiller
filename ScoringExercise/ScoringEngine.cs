using System.Collections.Generic;
using ScoringExercise.Entities;
using System.Linq;

namespace ScoringExercise
{
    public static class ScoringEngine
    {
        /// <summary>
        /// Calculates the results of an assessment based upon the test content and candidate responses.
        /// </summary>
        public static AssessmentResults GetResults(List<MultiChoiceItem> multiChoiceItems, Dictionary<int, int> responses)
        {
            var itemsCorrect = 0;
            var marksAwarded = 0;
            foreach(var response in responses)
            {
                var tempItem = multiChoiceItems[response.Key];
                if(tempItem.CorrectAnswerIndex == response.Value)
                {
                    itemsCorrect += 1;
                    marksAwarded += tempItem.MarksAwardedIfCorrect;
                } 
            }
            //items attempted
            var retVal = new AssessmentResults
            {
                ItemsAttempted = responses.Count(),
                ItemsCorrect = itemsCorrect,
                TotalMarksAwarded = marksAwarded
            };
            return retVal;
        }
    }
}