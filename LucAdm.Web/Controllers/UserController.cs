using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LucAdm.Web
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserRepository _userRepository;
        private readonly UserService _userService;

        public UserController(UserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public IList<UserVm> Get()
        {
            return _userRepository.GetAll().Select(x => x.ToViewModel<UserVm>()).ToList();
        }

        public UserVm Get(int id)
        {
            return null;
        }

        public OperationResponse<int> Post(CreateUserCommand command)
        {
            return _userService.CreateUser(command);
        }

        [HttpPost]
        [Route("{id}")]
        public virtual HttpResponseMessage Post(UpdateUserCommand command)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public virtual HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
