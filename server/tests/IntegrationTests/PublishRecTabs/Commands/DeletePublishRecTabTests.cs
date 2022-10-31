using System.Linq;
using System.Threading.Tasks;
using Application.Features.PublishRecTab.Requests.Commands;
using Domain;
using Domain.Enums;
using NUnit.Framework;

namespace IntegrationTests.PublishRecTabs.Commands
{
    using static Testing;
    public class DeletePublishRecTabTests : BasePublishRecTabTests
    {
        [Test]
        public async Task ShouldDeletePublishRecTab()
        {
            var userId = await RunAsUserAsync();
            var command = GetValidCreateTabCommand(userId);

            await SendAsync(command);

            await SendAsync(new DeletePublishRecTabCommand { UserId = userId });

            var recTabs = await GetAllAsync<RegabiturPublishrectab>();

            Assert.AreEqual(recTabs.Count, 0);
        }

        // 1) modification does not exist.
        [Test]
        public async Task ShouldCreateNewDeletedMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            await SendAsync(createCommand);

            await RemoveAllAsync<AdminpanelRectabmodification>();

            await SendAsync(new DeletePublishRecTabCommand { UserId = userId });

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Deleted);
            Assert.AreEqual(mod.Author, "testusername");
        }

        // 2) modification already exists
        // 2.1) type = created
        [Test]
        public async Task ShouldDeleteModWithCreatedType()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = true;
            await SendAsync(createCommand);

            await SendAsync(new DeletePublishRecTabCommand { UserId = userId });

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 0);
        }

        // 2.2) type != created
        [Test]
        public async Task ShouldUpdateModToDeletedType()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            await SendAsync(createCommand);

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = true;
            await SendAsync(updateCommand);

            await SendAsync(new DeletePublishRecTabCommand { UserId = userId });
            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();
            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Deleted);
        }


    }
}