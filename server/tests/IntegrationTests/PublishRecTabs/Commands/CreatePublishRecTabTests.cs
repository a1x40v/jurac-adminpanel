using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using NUnit.Framework;

namespace IntegrationTests.PublishRecTabs.Commands
{
    using static Testing;
    public class CreatePublishRecTabTests : BasePublishRecTabTests
    {
        [Test]
        public async Task ShouldCreatePublishRecTab()
        {
            var userId = await RunAsUserAsync();
            var command = GetValidCreateTabCommand(userId);

            await SendAsync(command);

            var recTabs = await GetAllAsync<RegabiturPublishrectab>();

            Assert.AreEqual(recTabs.Count, 1);

            var recTab = recTabs.FirstOrDefault();

            Assert.AreEqual(recTab.UserId, userId);
            Assert.AreEqual(recTab.SumPoints, 100);
        }

        [Test]
        public async Task ShouldNotCreateRecTabModification()
        {
            var userId = await RunAsUserAsync();
            var command = GetValidCreateTabCommand(userId);
            command.IsPublished = false;

            await SendAsync(command);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 0);
        }

        [Test]
        public async Task ShouldCreateRecTabModification()
        {
            var userId = await RunAsUserAsync();
            var command = GetValidCreateTabCommand(userId);
            command.IsPublished = true;

            await SendAsync(command);

            var recTabs = await GetAllAsync<RegabiturPublishrectab>();
            var recTab = recTabs.FirstOrDefault();

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.RectabId, recTab.Id);
            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Created);
        }

    }
}