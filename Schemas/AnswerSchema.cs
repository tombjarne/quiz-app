namespace Lifekeys.Schemas
{
    public class AnswerSchema
    {
        public string AnswerId { get; set; }
        public int Type { get; set; }
        public bool Solution { get; set; }

        public AnswerSchema(string answerId, 
            int type, bool solution)
        {
            AnswerId = answerId;
            Type = type;
            Solution = solution;
        }
    }
}
