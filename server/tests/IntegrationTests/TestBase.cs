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

        protected async Task CreateUserProfiles()
        {
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.BakOfoUp
            });
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.BakZfoUp
            });
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.BakOzfoUp
            });
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.AspZfoKs
            });
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.AspOfoGp
            });
            await AddAsync<RegabiturChoicesprofile>(new RegabiturChoicesprofile
            {
                Description = UserChoisesProfile.AspOfoUgp
            });
        }
    }
}