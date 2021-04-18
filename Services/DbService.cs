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
            try
            {
                var test = await _quizContext.Questions
                    .SingleAsync(q => q.Id == id);

                Debug.WriteLine(test);

                var question = _quizContext.Questions
                    .Select(q => new Question
                    {
                        Id = q.Id,
                        Answers = q.Answers.Select(a => new Answer()
                        {
                            Id = a.Id,
                            ParentSolution = a.ParentSolution,
                            SolutionId = a.SolutionId,
                            Value = a.Value
                        }).ToList(),
                        IsTrue = q.IsTrue,
                        ParentQuiz = q.ParentQuiz,
                        QuestionText = q.QuestionText,
                        QuizId = q.Id,
                        Solutions = q.Solutions.Select(s => new Solution()
                        {
                            Answers = s.Answers,
                            Id = s.Id,
                            Parent = q,
                            QuestionId = q.Id
                        }).ToList(),
                        Type = q.Type
                    });

                return question.First();
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}
