using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Features.Users.Requests.Commands;
using Domain;
using NUnit.Framework;

namespace IntegrationTests.Users.Commands
{
    using static Testing;
    public class DeleteUserTests : TestBase
    {
        [Test]
        public void ShouldRequireValidUserId()
        {
            var command = new DeleteUserCommand
            {
                Id = 100500
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await SendAsync(command));
        }

        [Test]
        public async Task ShouldDeleteUser()
        {
            var id = await RunAsUserAsync();

            await SendAsync(new DeleteUserCommand
            {
                Id = id
            });

            var user = await FindAsync<AuthUser>(id);

            Assert.IsNull(user);
        }

        [Test]
        public async Task ShouldDeleteUserWithRelatedEntities()
        {
            var id = await RunAsUserAsync(true, true, true);

            await SendAsync(new DeleteUserCommand
            {
                Id = id
            });

            var user = await FindAsync<AuthUser>(id);

            Assert.IsNull(user);
        }
    }
}