namespace FlightManager.Common
{
    public static class GlobalConstants
    {
        public const string AdministrationArea = "Administration";

        public const string LongDateFormat = "dd/MM/yyyy HH:mm";

        public static class Roles
        {
            public const string Administrator = "Administrator";

            public const string Employee = "Employee";
        }

        public static class EmailCredentials
        {
            public static string Email { get; set; }
        }

        public static class EmailSubjects
        {
            public const string PassengerConfirmationEmail = "Ticket reservation confirmation.";

            public const string ClientConfirmationEmail = "Tickets reservation confirmation.";
        }

        public static class Admin
        {
            public const string Username = "admin";

            public const string Password = "123456";

            public const string Email = "admin@mail.com";

            public const string Name = "Admin";

            public const string Surname = "Root";

            public const string PersonalNumber = "0123456789";

            public const string Address = "Smolyan, Bulgaria";

            public const string PhoneNumber = "0877887780";
        }
    }
}
