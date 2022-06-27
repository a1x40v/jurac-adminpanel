namespace Domain.Factories
{
    public static class RegabiturCustomuserFactory
    {
        public static RegabiturCustomuser CreateEmpty()
        {
            return new RegabiturCustomuser
            {
                DateOfBirth = DateTime.MinValue,
                Patronymic = String.Empty,
                PhoneNumber = String.Empty,
                SendingStatus = String.Empty,
                Address = String.Empty,
                CommentAdmin = String.Empty,
                DateOfDoc = String.Empty,
                NameUz = String.Empty,
                Passport = String.Empty,
                Snils = String.Empty,
                Message = String.Empty
            };
        }
    }
}