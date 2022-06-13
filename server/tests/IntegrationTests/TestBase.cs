using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Constants;
using NUnit.Framework;

namespace IntegrationTests
{
    using static Testing;
    public class TestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            await ResetState();
        }

        protected async Task<int> CreateUser()
        {
            var authUser = new AuthUser
            {
                Password = "password",
                IsSuperuser = false,
                Username = "testusername",
                FirstName = "Testfirstname",
                LastName = "Testlastname",
                Email = "test@example.com",
                IsStaff = false,
                IsActive = false,
                DateJoined = DateTime.Now
            };

            // Custom User
            var customUser = new RegabiturCustomuser
            {
                DateOfBirth = DateTime.Now,
                Patronymic = "Testpatronymic",
                PhoneNumber = "123456",
                SendingStatus = UserDocSendingStatus.No,
                CompleteFlag = false,
                AgreementFlag = false,
                WorkFlag = false,
                SuccessFlag = false,
                Address = "Test address",
                CommentAdmin = "Test comment admin",
                DateOfDoc = "Test date of doc",
                NameUz = "Test name uz",
                Passport = "12345678",
                Snils = "12345678901",
                Message = "Test message"
            };
            authUser.RegabiturCustomuser = customUser;

            // Additional Info
            var addInfo = new RegabiturAdditionalinfo();
            authUser.RegabiturAdditionalinfo = addInfo;

            // Choises profile
            var choicesProfile = new RegabiturChoicesprofile
            {
                Description = "ОФО Бакалавриат"
            };

            addInfo.RegabiturAdditionalinfoEducationProfiles = new List<RegabiturAdditionalinfoEducationProfile>
            {
                 new RegabiturAdditionalinfoEducationProfile
                 {
                     Additionalinfo = addInfo,
                     Choicesprofile = new RegabiturChoicesprofile { Description = "ОФО Бакалавриат"}
                 },
                 new RegabiturAdditionalinfoEducationProfile
                 {
                     Additionalinfo = addInfo,
                     Choicesprofile = new RegabiturChoicesprofile { Description = "ОФО Магистратура"}
                 }
            };

            // Documentuser
            var docUser = new RegabiturDocumentuser
            {
                NameDoc = "Test name doc",
                Doc = "Test doc"
            };
            authUser.RegabiturDocumentusers = new List<RegabiturDocumentuser> {
                docUser
            };

            // Publishtab
            var publishtab = new RegabiturPublishtab
            {
                IndividualStr = "Test Ind Str",
                TestType = "Test testtype"
            };
            authUser.RegabiturPublishtab = publishtab;

            await AddAsync<AuthUser>(authUser);

            return authUser.Id;
        }
    }
}