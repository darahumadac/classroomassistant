using System.Configuration;
using System.Linq;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Controllers
{
    public class LoginManager
    {
        private readonly Repository<User> _userRepository;
        private readonly string DEFAULT_PASSWORD = ConfigurationManager.AppSettings["defaultPw"];

        public LoginManager(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            User user = _userRepository.GetAll()
                .Find(u =>
                    u.Username.Equals(username)
                    && u.Password.Equals(password)
                    && u.IsActive
                    && !u.Password.Equals(DEFAULT_PASSWORD));

            if (user == null)
            {
                user = new User();
            }

            return user;
        }

    }
}
