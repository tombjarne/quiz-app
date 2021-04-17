using System;

namespace Lifekeys.Helpers
{
    public class SessionDetails
    {
        public string UserId { get; set; }
        public string QuizId { get; set; }
        public bool [] QuestionsCompleted { get; set; }

        public SessionDetails(string userId, string quizId)
        {
            UserId = userId;
            QuizId = quizId;
            QuestionsCompleted = Array.Empty<bool>();
        }
    }
}
