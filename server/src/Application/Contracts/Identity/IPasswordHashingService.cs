namespace Application.Contracts.Identity
{
    public interface IPasswordHashingService
    {
        string PBKDF2_SHA256_GetHash(string password, string saltAsBase64String, int iterations, int hashByteSize);
        byte[] PBKDF2_SHA256_GetHash(string password, byte[] salt, int iterations, int hashByteSize);
        bool ValidatePassword(string password, string salt, int iterations, int hashByteSize, string hashAsBase64String);
        bool ValidatePassword(string password, byte[] saltBytes, int iterations, int hashByteSize, byte[] actualGainedHasAsByteArray);
    }
}