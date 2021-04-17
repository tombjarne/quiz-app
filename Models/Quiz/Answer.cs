using System.ComponentModel.DataAnnotations;

namespace Lifekeys.Models.Quiz
{
    public class Answer
    {
        [Key]
        public string Id { get; set; }
        public string Value { get; set; }
        public string SolutionId { get; set; }
        public Solution ParentSolution { get; set; }

        public Answer(string id, string value, string solutionId, Solution parent)
        {
            Id = id;
            Value = value;
            SolutionId = solutionId;
            ParentSolution = parent;
        }

        public Answer()
        { }
    }
}
