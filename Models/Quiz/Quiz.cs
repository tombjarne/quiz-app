using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lifekeys.Models.Quiz.Questions;

namespace Lifekeys.Models.Quiz
{
    public class Quiz
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string id, string title, List<Question> questions)
        {
            Id = id;
            Title = title;
            Questions = questions;
        }

        public Quiz() { }

    }
}
