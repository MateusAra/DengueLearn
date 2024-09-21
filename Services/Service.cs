using System.Net.Mail;
using System.Net;
using System.Text.Json;
using System.Globalization;
using DengueLearn.Models;
using DengueLearn.Repository.Interfaces;
using DengueLearn.Services.Interfaces;

namespace DengueLearn.Services
{
    public class Service : IService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IVideoRepository _videoRepository;
        private readonly IQuestionRepository _questionRepository;

        public Service(IUserRepository userRepository,
            IQuestionRepository questionRepository,
            IVideoRepository videoRepository,
            IConfiguration configuration,
            IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _httpContext = httpContext;
            _videoRepository = videoRepository;
            _questionRepository = questionRepository;
        }

        public UserModel AddUser(UserModel user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;

            return _userRepository.AddUser(user);
        }

        public void AddUserSession(UserModel user)
        {
            var userSession = JsonSerializer.Serialize(user);

            _httpContext.HttpContext.Session.SetString("userSessionLogged", userSession);
        }

        public bool DeleteUser(long id)
        {
            var user = GetUserById(id);

            var deleted = _userRepository.DeleteUser(user);

            return deleted;
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserModel? GetUserById(long id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new Exception(Messages.Messages.NotFoundUser);
            }

            return user;
        }

        public UserModel? GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            return user;
        }

        public UserModel GetUserSession()
        {
            var session = _httpContext.HttpContext.Session.GetString("userSessionLogged");

            if (string.IsNullOrEmpty(session))
                return null;

            return JsonSerializer.Deserialize<UserModel>(session);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("userSessionLogged");
        }

        public bool SendEmail(string destination, string subject, string message)
        {
            try
            {
                string _body = "<!DOCTYPE html>\r\n<html lang=\\\"en\\\">\r\n\r\n<head>\r\n    <meta charset=\\\"UTF-8\\\">\r\n    <meta name=\\\"viewport\\\" content=\\\"width=device-width, initial-scale=1.0\\\">\r\n    <title>Vitoria Moura Opto</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            line-height: 1.6;\r\n            background-color: #f4f4f4;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        .container {\r\n            max-width: 600px;\r\n            margin: 20px auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 5px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        h1 {\r\n            color: #333333;\r\n        }\r\n\r\n        p {\r\n            color: #666666;\r\n        }\r\n\r\n        a {\r\n            color: #007bff;\r\n            text-decoration: none;\r\n        }\r\n\r\n        a:hover {\r\n            text-decoration: underline;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body>\r\n    <div class=\\\"container text-center\\\">\r\n        <h1>Admin VM Opto</h1>\r\n        <p>{content}</p> \r\n        <small>\r\n            Veja este \r\n            <a href=\\\"#\\\">\r\n                https://gerenciadordeclientesmts.azurewebsites.net</a> \r\n                para mais informações.\r\n        </small>\r\n    </div>\r\n</body>\r\n\r\n</html>";

                string host = _configuration.GetValue<string>("SMTP:Host");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int port = _configuration.GetValue<int>("SMTP:Port");
                string body = _body.Replace("{content}", message);

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, name),
                };

                mail.To.Add(destination);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception erro)
            {
                return false;
            }
        }

        public UserModel? UpdatePassword(UserModel user)
        {
            var userData = GetUserById(user.Id);

            userData.Password = user.Password;
            userData.UpdatedDate = DateTime.Now;

            var userUpdated = _userRepository.UpdateUser(userData);

            return userUpdated;
        }

        public UserModel UpdateUser(UserModel user)
        {
            var userData = GetUserById(user.Id);

            userData.UserName = user.UserName;
            userData.Email = user.Email;
            userData.UpdatedDate = DateTime.Now;

            var userUpdated = _userRepository.UpdateUser(userData);

            return userUpdated;
        }

        public VideoModel GetVideoById(long id)
        {
            return _videoRepository.GetVideoById(id);
        }

        public List<QuestionModel> GetAllQuestions()
        {
            return _questionRepository.GetAllQuestions();
        }
    }
}