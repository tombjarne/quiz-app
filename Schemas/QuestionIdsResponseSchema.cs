using System.Collections.Generic;

namespace Lifekeys.Schemas
{
    public class QuestionIdsResponseSchema
    {
        public List<string> Questions { get; set; }

        public QuestionIdsResponseSchema(List<string> questions)
        {
            Questions = questions;
        }
    }
}
