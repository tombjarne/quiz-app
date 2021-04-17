using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lifekeys.Models.Quiz.Questions
{
    public class Question
    {
        [Key]
        public string Id { get; set; }
        public string QuizId { get; set; }
        public QuestionType Type { get; set; }
        public Quiz ParentQuiz { get; set; }
        public string QuestionText { get; set; }
        public bool? IsTrue { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Solution> Solutions { get; set; }

        public Question(string id, string quizId, QuestionType type, string text)
        {
            Id = id;
            QuizId = quizId;
            Type = type;
            QuestionText = text;
        }

        public Question() { }
    }
}
