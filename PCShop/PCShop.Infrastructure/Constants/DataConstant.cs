namespace PCShop.Infrastructure.Constants
{
    /// <summary>
    /// Class holding data constants
    /// </summary>
    public static class DataConstant
    {
        /// <summary>
        /// Class holding User constants
        /// </summary>
        public static class UserConstants
        {
            /// <summary>
            /// Constant for the max length of user's first name
            /// </summary>
            public const int FirstNameMaxLength = 20;

            /// <summary>
            /// Constant for the max length of user's last name
            /// </summary>
            public const int LastNameMaxLength = 20;
        }

        /// <summary>
        /// Class holding Role constants
        /// </summary>
        public static class RoleConstants
        {
            /// <summary>
            /// Constant for the name of Administrator role
            /// </summary>
            public const string Administrator = "Administrator";

            /// <summary>
            /// Constant for the name of SuperUser role
            /// </summary>
            public const string SuperUser = "SuperUser";
        }
    }
}
