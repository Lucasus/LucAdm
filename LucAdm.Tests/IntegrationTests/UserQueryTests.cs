using FluentAssertions;
using LucAdm.DataGen;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LucAdm.Tests
{
    public class UserQueryTests : IClassFixture<UsesDbFixture>
    {
        [NamedTheory, Trait("Category", "Integration")]
        public void UserQuery_Get_Should_Return_Correct_Users()
        {
            var queryService = new UserQueryService(new PersistenceContext().ResetDbState());

            var users = queryService.Get(new GetUsersQuery()
            {
                Page = 1,
                PageSize = 5,
                SearchTerm = "g"
            });

            users.Total.Should().Be(2);
            users.List.Select(x => x.UserName).ToList().ShouldAllBeEquivalentTo(new List<string>() { Users.GandalfTheAdmin.UserName, Users.Legolas.UserName });
        }
    }
}