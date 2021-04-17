namespace Lifekeys.Schemas
{
    public class AnswerSchema
    {
        public string QuizId { get; set; }
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }
        public int Type { get; set; }
        public bool Solution { get; set; }

        public AnswerSchema(string quizId, string questionId, string answerId, 
            int type, bool solution)
        {
            QuizId = quizId;
            QuestionId = questionId;
            AnswerId = answerId;
            Type = type;
            Solution = solution;
        }
    }
}
