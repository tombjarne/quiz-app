using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lifekeys.Models.Quiz.Questions;

namespace Lifekeys.Models.Quiz
{
    public class Solution
    {
        [Key]
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public Question Parent { get; set; }
        public List<Answer> Answers { get; set; }

        public Solution(string id, string questionId, List<Answer> answers)
        {
            Id = id;
            QuestionId = questionId;
            Answers = answers;
        }

        public Solution() { }
    }
}
