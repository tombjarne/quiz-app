using Lifekeys.Models.Quiz.Questions;

namespace Lifekeys.Schemas
{
    public class AnswerSchema
    {
        public string QuizId { get; set; }
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }
        public int Type { get; set; }

        public AnswerSchema(string quizId, string questionId, string answerId, int type)
        {
            QuizId = quizId;
            QuestionId = questionId;
            AnswerId = answerId;
            Type = type;
        }
    }
}
