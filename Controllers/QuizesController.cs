using DengueLearn.Models;
using DengueLearn.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

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
            var user = _service.GetUserSession();

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

            if (score == quiz.Questions.Count)
            {
                var alreadyResult = _service.GetAllResults();

                if (alreadyResult.FirstOrDefault(x => x.UserId == user.Id && x.QuizId == quiz.Id) == null)
                {
                    var result = new ResultQuizModel()
                    {
                        Passed = true,
                        QuizId = quiz.Id,
                        UserId = user.Id
                    };

                    _service.AddResult(result);
                }
            }

            ViewBag.Score = score;
            ViewBag.TotalQuestions = quiz.Questions.Count;

            return View("Result");
        }

        public IActionResult GetConquists()
        {
            var user = _service.GetUserSession();
            var results = _service.GetAllResults();

            var conquists = results.Where(x => x.Passed == true && x.UserId == user.Id).ToList();

            return View(conquists);
        }

        public IActionResult GetCertificate(int quizId)
        {
            var user = _service.GetUserSession();

            ViewBag.QuizId = quizId;

            return View(user);
        }
    }
}
