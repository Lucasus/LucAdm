using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LucAdm.Web
{
    public class UserController : ApiController
    {
        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IList<UserVM> Get()
        {
            return userRepository.GetAll().Select(x => x.ToViewModel<UserVM>()).ToList();
        }
    }
}
