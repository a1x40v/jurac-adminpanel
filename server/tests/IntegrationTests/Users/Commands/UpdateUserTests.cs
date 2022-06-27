using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Features.Users.Requests.Commands;
using Domain.Constants;
using NUnit.Framework;

namespace IntegrationTests.Users.Commands
{
    using static Testing;

    public class UpdateUserTests : TestBase
    {
        private UpdateUserCommand CreateUpdateCommand(int userId)
        {
            return new UpdateUserCommand
            {
                Id = userId,
                FirstName = "NEW_FRISTNAME",
                LastName = "NEW_LASTNAME",
                Email = "newemail@example.com",
                Patronymic = "NEW_PATRANOMYC",
                DateOfBirth = DateTime.UtcNow.Date,
                PhoneNumber = "89992211",
                SendingStatus = UserDocSendingStatus.Send,
                CompleteFlag = true,
                AgreementFlag = true,
                WorkFlag = true,
                SuccessFlag = true,
                Address = "New Updated Address",
                CommentAdmin = "New Updated Comment",
                DateOfDoc = "New Date of Doc",
                NameUz = "New Name Uz",
                Passport = "09213333",
                Snils = "11112222997",
            };
        }

        private UpdateUserCommand CreateUpdateCommand(int userId, ICollection<string> profiles)
        {
            var cmd = CreateUpdateCommand(userId);
            cmd.ChoicesProfiles = profiles;
            return cmd;
        }

        [Test]
        public void ShouldRequrieMinimumFields()
        {
            var command = new UpdateUserCommand();

            Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));
        }

        [Test]
        public void ShouldRequireValidUserId()
        {
            var command = CreateUpdateCommand(100500);

            Assert.ThrowsAsync<NotFoundException>(async () => await SendAsync(command));
        }

        [Test]
        public void ShouldRequireValidSendingStatus()
        {
            var command = CreateUpdateCommand(100500);
            command.SendingStatus = "incorrectStatus";

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.That(ex.Errors, Contains.Key("SendingStatus"));
        }

        [Test]
        public async Task ShouldUpdateUser()
        {
            int userId = await CreateUser();

            var command = CreateUpdateCommand(userId);

            await SendAsync(command);

            var authUser = await FindUserAsync(userId);

            Assert.AreEqual(authUser.FirstName, command.FirstName);
            Assert.AreEqual(authUser.LastName, command.LastName);
            Assert.AreEqual(authUser.Email, command.Email);

            var customUser = authUser.RegabiturCustomuser;

            Assert.AreEqual(customUser.Patronymic, command.Patronymic);
            Assert.AreEqual(customUser.DateOfBirth, command.DateOfBirth);
            Assert.AreEqual(customUser.PhoneNumber, command.PhoneNumber);
            Assert.AreEqual(customUser.SendingStatus, command.SendingStatus);
            Assert.AreEqual(customUser.CompleteFlag, command.CompleteFlag);
            Assert.AreEqual(customUser.AgreementFlag, command.AgreementFlag);
            Assert.AreEqual(customUser.WorkFlag, command.WorkFlag);
            Assert.AreEqual(customUser.SuccessFlag, command.SuccessFlag);
            Assert.AreEqual(customUser.Address, command.Address);
            Assert.AreEqual(customUser.CommentAdmin, command.CommentAdmin);
            Assert.AreEqual(customUser.DateOfDoc, command.DateOfDoc);
            Assert.AreEqual(customUser.NameUz, command.NameUz);
            Assert.AreEqual(customUser.Passport, command.Passport);
            Assert.AreEqual(customUser.Snils, command.Snils);
        }

        [Test]
        public async Task ShouldUpdateUserProfiles()
        {
            await CreateUserProfiles();

            int userId = await CreateUser();

            var newProfiles = new List<string>
            {
                UserChoisesProfile.AspOfoUgp,
                UserChoisesProfile.AspOfoGp,
                UserChoisesProfile.BakZfoUp
            };

            var command = CreateUpdateCommand(userId, newProfiles);

            await SendAsync(command);

            var authUser = await FindUserAsync(userId);

            var actualProfiles = authUser.RegabiturAdditionalinfo
                .RegabiturAdditionalinfoEducationProfiles
                .Select(x => x.Choicesprofile.Description)
                .ToList();

            CollectionAssert.AreEquivalent(newProfiles, actualProfiles);
        }
    }
}