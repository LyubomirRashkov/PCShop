namespace PCShop.Core.Constants
{
    /// <summary>
    /// Class holding constants
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// Class holding User constants
        /// </summary>
        public static class User
        {
            /// <summary>
            /// Constant for the min length of user's first name
            /// </summary>
            public const int FirstNameMinLength = 2;

            /// <summary>
            /// Constant for the min length of user's last name
            /// </summary>
            public const int LastNameMinLength = 2;

            /// <summary>
            /// Constant for the min length of user's username
            /// </summary>
            public const int UsernameMinLength = 2;
            /// <summary>
            /// Constant for the max length of user's username
            /// </summary>
            public const int UsernameMaxLength = 20;

            /// <summary>
            /// Constant for the min length of user's email
            /// </summary>
            public const int EmailMinLength = 10;
            /// <summary>
            /// Constant for the max length of user's email
            /// </summary>
            public const int EmailMaxLength = 40;

            /// <summary>
            /// Constant for the min length of user's password
            /// </summary>
            public const int PasswordMinLength = 4;
            /// <summary>
            /// Constant for the max length of user's password
            /// </summary>
            public const int PasswordMaxLength = 20;
        }
    }
}
