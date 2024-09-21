using DengueLearn.Models;
using DengueLearn.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DengueLearn.Controllers
{
    public class QuizesController : Controller
    {
        private readonly IService _service;

        public QuizesController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetQuiz(int id)
        {
            var questions = _service.GetAllQuestions();

            var quiz = new QuizModel
            {
                Questions = questions.Where(x => x.QuizId == id).ToList()
            };

            return View(quiz);
        }

        [HttpPost]
        public IActionResult Submit(QuizModel quiz)
        {
            int score = 0;
            var questions = _service.GetAllQuestions();
            var correctAnswers = new Dictionary<long, string>();

            foreach (var question in questions)
            {
                correctAnswers.Add(question.Id, question.CorrectOption);
            }

            foreach (var question in quiz.Questions)
            {
                if (correctAnswers[question.Id] == question.SelectedOption)
                {
                    score++;
                }
            }

            ViewBag.Score = score;
            ViewBag.TotalQuestions = quiz.Questions.Count;

            return View("Result");
        }
    }
}
