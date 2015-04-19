using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LucAdm.Web
{
    public class UsersController : ApiController
    {
        private readonly UserRepository _userRepository;
        private readonly UserService _userService;

        public UsersController(UserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public UsersVm Get([FromUri] GetUsersQuery query)
        {
            return new UsersVm()
            {
                List = _userRepository.Get(query).Select(x => x.ToViewModel<UserItemVm>()).ToList(),
                Total = 15
            };
        }

        public UserVm Get(int id)
        {
            return _userRepository.GetById(id).ToViewModel<UserVm>();
        }

        public OperationResponse<int> Post(CreateUserCommand command)
        {
            return _userService.CreateUser(command);
        }


        public HttpResponseMessage Put(UpdateUserCommand command)
        {
            _userService.UpdateUser(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(Validated<int> id)
        {
            _userService.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
