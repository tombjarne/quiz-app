using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Lifekeys.Schemas;
using Lifekeys.Services;
using Microsoft.AspNetCore.Http;

namespace Lifekeys.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizService _quizService;

        public QuizController(DbService dbService, IHttpContextAccessor accessor)
        {
            _quizService = new QuizService(dbService, accessor);
        }

        /// <summary>
        /// GetAllQuizzes()
        /// returns all quizzes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRandomQuiz()
        {
            return await _quizService.GetRandom();
        }

        // GET api/<QuizController>/5
        [HttpGet("{quizId}")]
        public async Task<IActionResult> GetQuizById([FromQuery] string id)
        {
            return await _quizService.GetSingleById(id);
        }

        [HttpGet("{quizId}/questions")]

        public async Task<IActionResult> GetQuestions(string quizId)
        {
            return await _quizService.GetQuestionsForId(quizId);
        }

        [HttpGet("{quizId}/questions/{questionId}")]

        public async Task<IActionResult> GetQuestion([FromQuery] string quizId, string questionId)
        {
            return await _quizService.GetQuestionById(questionId);
        }

        [HttpPost("{quizId}/questions/{questionId}/submit")]
        public async Task<IActionResult> SubmitAnswer(
            string quizId, string questionId, [FromBody] AnswerSchema answer)
        {
            if (answer.Type == 2)
            {
                return await _quizService.CheckTrueFalseAnswer(answer.QuestionId, answer.Solution);
            }
            return await _quizService.CheckAnswer(answer.QuestionId);
        }

        [HttpGet("{quizId}/questions/{questionId}/answers")]
        public async Task<IActionResult> GetAnswers([FromQuery] string quizId, string questionId)
        {
            return await _quizService.GetQuestionById(questionId);
        }

        [HttpGet("{quizId}/questions/{questionId}/answers{answerId}")]
        public async Task<IActionResult> GetAnswer([FromQuery] string quizId, string questionId)
        {
            return await _quizService.GetQuestionById(questionId);
        }
    }
}
