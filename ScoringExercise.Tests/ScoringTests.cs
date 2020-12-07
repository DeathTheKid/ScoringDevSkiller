using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScoringExercise;
using ScoringExercise.Entities;

namespace ScoringExerciseTests
{
    [TestFixture]
    public class ScoringTests
    {
        readonly List<MultiChoiceItem> _assessmentItems;

        public ScoringTests()
        {
            // Assessment items
            _assessmentItems = new List<MultiChoiceItem>
            {
                new MultiChoiceItem()
                {
                    ItemText = "Which city is the capital of Sweden?",
                    Options = new string[] {"Helsinki", "Stockholm", "Malmö", "Oslo"},
                    CorrectAnswerIndex = 1,
                    MarksAwardedIfCorrect = 1
                },
                new MultiChoiceItem()
                {
                    ItemText = "Which of these cheeses normally has large round holes?",
                    Options = new string[] {"Emmental", "Feta", "Danish Blue", "Gruyere"},
                    CorrectAnswerIndex = 0,
                    MarksAwardedIfCorrect = 1
                },
                new MultiChoiceItem()
                {
                    ItemText = "Which of the following is not a root vegetable?",
                    Options = new string[] {"Carrot", "Parsnip", "Turnip", "Shallot"},
                    CorrectAnswerIndex = 3,
                    MarksAwardedIfCorrect = 4
                },
                new MultiChoiceItem()
                {
                    ItemText = "What colour is the outmost archery target ring?",
                    Options = new string[] {"White", "Yellow", "Red", "Black"},
                    CorrectAnswerIndex = 0,
                    MarksAwardedIfCorrect = 1
                },
                new MultiChoiceItem()
                {
                    ItemText = "What is the chemical symbol for silver?",
                    Options = new string[] {"Au", "Sr", "Si", "Ag"},
                    CorrectAnswerIndex = 3,
                    MarksAwardedIfCorrect = 2
                }
            };

        }

        [Test]
        public void AllCorrect()
        {
            // create test data where all items have corresponding responses
            // and all responses are correct
            Dictionary<int, int> responses = new Dictionary<int, int>();

            int i = 0;
            foreach (MultiChoiceItem item in _assessmentItems)
            {
                responses.Add(i, item.CorrectAnswerIndex);
                i++;
            }

            // check that actual results are in line with expected results
            AssessmentResults expected = new AssessmentResults()
            {
                ItemsAttempted = _assessmentItems.Count,
                ItemsCorrect = _assessmentItems.Count,
                TotalMarksAwarded = _assessmentItems.Sum(item => item.MarksAwardedIfCorrect)
            };
            AssessmentResults actual = ScoringEngine.GetResults(_assessmentItems, responses);

            AssertValueEquality(expected, actual);
        }

        [Test]
        public void AllWrong()
        {
            // create test data where all items have corresponding responses
            // and all responses are wrong
            Dictionary<int, int> responses = new Dictionary<int, int>();

            int i = 0;
            foreach (MultiChoiceItem item in _assessmentItems)
            {
                if ((item.CorrectAnswerIndex + 1) < item.Options.Length)
                    responses.Add(i, item.CorrectAnswerIndex + 1);
                else
                    responses.Add(i, item.CorrectAnswerIndex - 1);
                i++;
            }

            // check that actual results are in line with expected results
            AssessmentResults expected = new AssessmentResults()
            {
                ItemsAttempted = responses.Count,
                ItemsCorrect = 0,
                TotalMarksAwarded = 0
            };
            AssessmentResults actual = ScoringEngine.GetResults(_assessmentItems, responses);

            AssertValueEquality(expected, actual);
        }

        private void AssertValueEquality(AssessmentResults expected, AssessmentResults actual)
        {
            CollectionAssert.AreEqual(
                new int[] { expected.ItemsAttempted, expected.ItemsCorrect, expected.TotalMarksAwarded },
                new int[] { actual.ItemsAttempted, actual.ItemsCorrect, actual.TotalMarksAwarded }
            );
        }
    }
}
