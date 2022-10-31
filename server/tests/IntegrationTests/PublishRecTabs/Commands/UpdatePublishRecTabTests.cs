using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Constants;
using Domain.Enums;
using NUnit.Framework;

namespace IntegrationTests.PublishRecTabs.Commands
{
    using static Testing;
    public class UpdatePublishRecTabTests : BasePublishRecTabTests
    {
        [Test]
        public async Task ShouldUpdatePublishRecTab()
        {
            var userId = await RunAsUserAsync();

            await SendAsync(GetValidCreateTabCommand(userId));

            var command = GetValidUpdateTabCommand(userId);

            await SendAsync(command);

            var tab = (await GetAllAsync<RegabiturPublishrectab>()).Find(x => x.UserId == userId);

            Assert.NotNull(tab);

            Assert.AreEqual(tab.Individ, 20);
            Assert.AreEqual(tab.TestType, UserTestType.VI);
            Assert.AreEqual(tab.Individ, 20);
            Assert.AreEqual(tab.Comment, "Comment updated");
            Assert.AreEqual(tab.BakOfoGp, false);
            Assert.AreEqual(tab.BakOfoUp, false);
            Assert.AreEqual(tab.MagZfoPo, true);
            Assert.AreEqual(tab.MagOfoTp, true);
        }

        // 1) modification does not exist.
        // 1.1) prevIsPublished = false, isPublished = true
        [Test]
        public async Task ShouldCreateNewShowedMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = false;
            await SendAsync(createCommand);

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = true;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Showed);
            Assert.AreEqual(mod.Author, "testusername");
        }

        // 1.2) prevIsPublished = true, isPublished = true
        [Test]
        public async Task ShouldCreateNewUpdatedMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = true;
            await SendAsync(createCommand);

            await RemoveAllAsync<AdminpanelRectabmodification>();

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = true;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Updated);
            Assert.AreEqual(mod.Author, "testusername");
        }

        // 1.3) prevIsPublished = false, isPublished = false
        [Test]
        public async Task ShouldNotCreateMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = false;
            await SendAsync(createCommand);

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = false;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 0);
        }

        // 1.4) prevIsPublished = false, isPublished = true
        [Test]
        public async Task ShouldCreateNewHiddenMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = true;
            await SendAsync(createCommand);

            await RemoveAllAsync<AdminpanelRectabmodification>();

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = false;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Hidden);
            Assert.AreEqual(mod.Author, "testusername");
        }

        // 2) modification already exists
        // 2.1) prevIsPublished = false, isPublished = true
        [Test]
        public async Task ShouldUpdateModToShowed()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = false;
            await SendAsync(createCommand);

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = true;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 1);

            var mod = mods.FirstOrDefault();

            Assert.AreEqual(mod.Type, (ushort)RecTabModificationType.Showed);
            Assert.AreEqual(mod.Author, "testusername");
        }

        // 2.1) prevIsPublished = true, isPublished = false
        [Test]
        public async Task ShouldDeleteMod()
        {
            var userId = await RunAsUserAsync();
            var createCommand = GetValidCreateTabCommand(userId);
            createCommand.IsPublished = true;
            await SendAsync(createCommand);

            var updateCommand = GetValidUpdateTabCommand(userId);
            updateCommand.IsPublished = false;
            await SendAsync(updateCommand);

            var mods = await GetAllAsync<AdminpanelRectabmodification>();

            Assert.AreEqual(mods.Count, 0);
        }
    }
}