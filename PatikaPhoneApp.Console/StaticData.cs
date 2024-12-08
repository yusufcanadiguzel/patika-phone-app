namespace PatikaPhoneApp.Console
{
    public static class StaticData
    {
        public static List<User> Users { get; set; }

        static StaticData()
        {
            Users = new List<User>()
            {
                new User { FirstName = "Yusufcan", LastName = "Adıgüzel", PhoneNumber = "12345678910"},
                new User { FirstName = "Adıgüzel", LastName = "Yusufcan", PhoneNumber = "10987654321"},
                new User { FirstName = "Test", LastName = "Admin", PhoneNumber = "12345678910"},
                new User { FirstName = "Admin", LastName = "Test", PhoneNumber = "10987654321"},
                new User { FirstName = "Test", LastName = "User", PhoneNumber = "12345678910"},
            };
        }
    }
}
