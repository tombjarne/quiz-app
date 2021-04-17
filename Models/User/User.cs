using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lifekeys.Models.User
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public List<Quiz.Quiz> Quizzes { get; set; }

        public User(string id)
        {
            Id = id;
        }

        public User() { }
    }
}
