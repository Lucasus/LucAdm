using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LucAdm.Web
{
    public class UsersController : ApiController
    {
        private readonly UserQueryService _userQueryService;
        private readonly UserService _userService;

        public UsersController(UserQueryService userQueryService, UserService userService)
        {
            _userQueryService = userQueryService;
            _userService = userService;
        }

        public async Task<UsersDto> GetAsync([FromUri] GetUsersQuery query)
        {
            return await _userQueryService.GetAsync(query);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            return await _userQueryService.GetByIdAsync(id);
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
