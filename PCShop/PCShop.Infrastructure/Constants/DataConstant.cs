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

			/// <summary>
			/// Constant for the max length of user's username
			/// </summary>
			public const int UsernameMaxLength = 20;

			/// <summary>
			/// Constant for the max length of user's email
			/// </summary>
			public const int EmailMaxLength = 40;
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

        /// <summary>
        /// Class holding Brand constants
        /// </summary>
        public static class BrandConstants
		{
            /// <summary>
            /// Constant for the max length of brand's name
            /// </summary>
            public const int BrandNameMaxLength = 20;
		}

        /// <summary>
        /// Class holding Color constants
        /// </summary>
        public static class ColorConstants
		{
            /// <summary>
            /// Constant for the max length of color's name
            /// </summary>
            public const int ColorNameMaxLength = 10;
		}

        /// <summary>
        /// Class holding CPU constants
        /// </summary>
        public static class CPUConstants
		{
            /// <summary>
            /// Constant for the max length of CPU's name
            /// </summary>
            public const int CPUNameMaxLength = 30;
		}

        /// <summary>
        /// Class holding DisplayCoverage constants
        /// </summary>
        public static class DisplayCoverageConstants
		{
            /// <summary>
            /// Constant for the max length of displayCoverage's name
            /// </summary>
            public const int DisplayCoverageNameMaxLength = 15;
		}

        /// <summary>
        /// Class holding DisplayTechnology constants
        /// </summary>
        public static class DisplayTechnologyConstants
		{
            /// <summary>
            /// Constant for the max length of displayTechnology's name
            /// </summary>
            public const int DisplayTechnologyNameMaxLength = 10;
		}

        /// <summary>
        /// Class holding Format constants
        /// </summary>
        public static class FormatConstants
		{
            /// <summary>
            /// Constant for the max length of format's name
            /// </summary>
			public const int FormatNameMaxLength = 20;
		}

        /// <summary>
        /// Class holding Resolution constants
        /// </summary>
        public static class ResolutionConstants
		{
            /// <summary>
            /// Constant for the max length of resolution's value string
            /// </summary>
            public const int ResolutionValueMaxLength = 25;
		}

        /// <summary>
        /// Class holding Sensitivity constants
        /// </summary>
        public static class SensitivityConstants
		{
            /// <summary>
            /// Constant for the max length of sensitivity's range string
            /// </summary>
            public const int SensitivityRangeMaxLength = 20;
		}

        /// <summary>
        /// Class holding Type constants
        /// </summary>
        public static class TypeConstants
		{
            /// <summary>
            /// Constant for the max length of type's name
            /// </summary>
			public const int TypeNameMaxLength = 25;
		}

        /// <summary>
        /// Class holding VideoCard constants
        /// </summary>
        public static class VideoCardConstants
		{
            /// <summary>
            /// Constant for the max length of videoCard's name
            /// </summary>
			public const int VideoCardNameMaxLength = 30;
		}
    }
}
