using Domain;
using Domain.Enums;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (context.AdminpanelBackendstates.Any())
                return;

            var backendState = new AdminpanelBackendstate { RectabDeployStatus = (ushort)RectabDeploymentStatus.NotUpdated };

            context.Add(backendState);

            var result = await context.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new Exception("Failed to seed BackendState data");
            }
        }
    }
}