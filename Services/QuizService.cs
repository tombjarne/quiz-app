using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Lifekeys.Services
{
    public class QuizService : ControllerBase
    {
        private readonly DbService _dbService;
        private readonly AuthService _authService;

        public QuizService(DbService dbService, IHttpContextAccessor accessor)
        {
            _dbService = dbService;
            _authService = new AuthService(accessor);
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _dbService.GetAllQuizzes();
                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> GetRandom()
        {
             
            try
            {   var result = await _dbService.GetRandom();

                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> CheckAnswer(string answerId)
        {
            try
            {
                var result = await _dbService.CheckAnswer(answerId);

                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> CheckTrueFalseAnswer(string questionId, bool answer)
        {
            try
            {
                var result = await _dbService.CheckTrueFalseAnswer(questionId, answer);

                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> GetSingleById(string id)
        {
            try
            {
                var result = await _dbService.GetSingleById(id);
                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> GetQuestionsForId(string id)
        {
            try
            {
                var result = await _dbService.GetQuestionsForId(id);
                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> GetQuestionById(string id)
        {
            try
            {
                var result = await _dbService.GetQuestionById(id);
                return StatusCode(200, JsonConvert.SerializeObject(result));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }
    }
}
