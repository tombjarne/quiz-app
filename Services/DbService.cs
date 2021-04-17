using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lifekeys.Contexts;
using Lifekeys.Models.Quiz;
using Lifekeys.Models.Quiz.Questions;
using Microsoft.EntityFrameworkCore;

namespace Lifekeys.Services
{
    public class DbService
    {
        private readonly QuizContext _quizContext;

        public DbService(QuizContext quizContext)
        {
            _quizContext = quizContext;
        }

        // SELECT

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                return await _quizContext.Quizzes
                    .ToListAsync();
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }

        public async Task<Quiz> GetRandom()
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                var random = new Random();
                var skip = random.Next(0, _quizContext.Quizzes.Count());

                return await _quizContext.Quizzes
                    .Skip(skip)
                    .Take(1)
                    .FirstAsync();
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }

        public async Task<bool> CheckAnswer(string answerId)
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                var result = await _quizContext.Answers
                    .SingleAsync(a => a.Id == answerId && a.SolutionId != null);

                return result != null;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
                return false;
            }
        }

        public async Task<bool> CheckTrueFalseAnswer(string questionId, bool answer)
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                var result = await _quizContext.Questions
                    .SingleAsync(a => a.Id == questionId && a.IsTrue == answer);

                return result != null;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public async Task<Quiz> GetSingleById(string id)
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                return await _quizContext.Quizzes
                    .SingleAsync(q => q.Id == id);
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }

        public async Task<List<Question>> GetQuestionsForId(string id)
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                return await _quizContext.Questions
                    .Where(q => q.QuizId == id)
                    .ToListAsync();
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }

        public async Task<Question> GetQuestionById(string id)
        {
            // TODO: introduce hashing and de-hashing in the future
            try
            {
                return await _quizContext.Questions
                    .SingleAsync(q => q.Id == id);
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}
