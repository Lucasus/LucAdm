using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LucAdm.Web
{
    public class UserController : ApiController
    {
        private UserRepository userRepository;
        private UserService userService;

        public UserController(UserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public IList<UserVM> Get()
        {
            return userRepository.GetAll().Select(x => x.ToViewModel<UserVM>()).ToList();
        }

        public OperationResponse<int> Post(CreateUserCommand command)
        {
            return userService.CreateUser(command);
        }
    }
}
