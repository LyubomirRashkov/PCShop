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
        public static class UserConstants
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
            /// Constant for the min length of user's email
            /// </summary>
            public const int EmailMinLength = 10;

            /// <summary>
            /// Constant for the min length of user's password
            /// </summary>
            public const int PasswordMinLength = 4;
            /// <summary>
            /// Constant for the max length of user's password
            /// </summary>
            public const int PasswordMaxLength = 20;
        }

        /// <summary>
        /// Class holding Brand constants
        /// </summary>
        public static class BrandConstants
        {
            /// <summary>
            /// Constant for the min length of brand's name
            /// </summary>
            public const int BrandNameMinLength = 3;
        }

        /// <summary>
        /// Class holding Color constants
        /// </summary>
        public static class ColorConstants
        {
            /// <summary>
            /// Constant for the min length of color's name
            /// </summary>
            public const int ColorNameMinLength = 3;
        }

        /// <summary>
        /// Class holding CPU constants
        /// </summary>
        public static class CPUConstants
        {
            /// <summary>
            /// Constant for the min length of CPU's name
            /// </summary>
            public const int CPUNameMinLength = 3;
        }

        /// <summary>
        /// Class holding DisplayCoverage constants
        /// </summary>
        public static class DisplayCoverageConstants
        {
            /// <summary>
            /// Constant for the min length of displayCoverage's name
            /// </summary>
            public const int DisplayCoverageNameMinLength = 3;
        }

        /// <summary>
        /// Class holding DisplayTechnology constants
        /// </summary>
        public static class DisplayTechnologyConstants
        {
            /// <summary>
            /// Constant for the min length of displayTechnology's name
            /// </summary>
            public const int DisplayTechnologyNameMinLength = 3;
        }

        /// <summary>
        /// Class holding Format constants
        /// </summary>
        public static class FormatConstants
        {
            /// <summary>
            /// Constant for the min length of format's name
            /// </summary>
            public const int FormatNameMinLength = 3;
        }

        /// <summary>
        /// Class holding Resolution constants
        /// </summary>
        public static class ResolutionConstants
        {
            /// <summary>
            /// Constant for the min length of resolution's value string
            /// </summary>
			public const int ResolutionValueMinLength = 5;
        }

        /// <summary>
        /// Class holding Sensitivity constants
        /// </summary>
        public static class SensitivityConstants
        {
            /// <summary>
            /// Constant for the min length of sensitivity's range string
            /// </summary>
            public const int SensitivityRangeMinLength = 5;
        }

        /// <summary>
        /// Class holding Type constants
        /// </summary>
        public static class TypeConstants
        {
            /// <summary>
            /// Constant for the min length of type's name
            /// </summary>
            public const int TypeNameMinLength = 3;
        }

        /// <summary>
        /// Class holding VideoCard constants
        /// </summary>
        public static class VideoCardConstants
        {
            /// <summary>
            /// Constant for the min length of videoCard's name
            /// </summary>
			public const int VideoCardNameMinLength = 3;
        }

        /// <summary>
        /// Class holding Laptop constants
        /// </summary>
        public static class LaptopConstants
        {
            /// <summary>
            /// Constant for the min value of laptop's RAM
            /// </summary>
            public const int RAMMinValue = 1;
            /// <summary>
            /// Constant for the max value of laptop's RAM
            /// </summary>
            public const int RAMMaxValue = int.MaxValue;

            /// <summary>
            /// Constant for the min value of laptop's SSD capacity
            /// </summary>
            public const int SSDCapacityMinValue = 1;
            /// <summary>
            /// Constant for the max value of laptop's SSD capacity
            /// </summary>
            public const int SSDCapacityMaxValue = int.MaxValue;

            /// <summary>
            /// Constant for the error message of invalid Laptop unique identifier
            /// </summary>
            public const string ErrorMessageForInvalidLaptopId = "Invalid laptop id!";
        }

        /// <summary>
        /// Class holding constants for all product types
        /// </summary>
        public static class ProductConstants
        {
            /// <summary>
            /// Constant for the min value of product's quantity
            /// </summary>
            public const int QuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of product's quantity
            /// </summary>
            public const int QuantityMaxValue = int.MaxValue;

            /// <summary>
            /// Constant for the min value of product's warranty
            /// </summary>
            public const int WarrantyMinValue = 0;
            /// <summary>
            /// Constant for the max value of product's warranty
            /// </summary>
            public const int WarrantyMaxValue = int.MaxValue;

            /// <summary>
            /// Constant for the error message of product's integer property
            /// </summary>
            public const string IntegerErrorMessage = "The field {0} must be an integer between {1} and {2}";

			/// <summary>
			/// Constant for the error message of a deleted product
			/// </summary>
			public const string ErrorMessageForDeletedProduct = "The selected product is deleted!";

			/// <summary>
			/// Constant for the error message of a product that is out of stock
			/// </summary>
			public const string ErrorMessageForProductThatIsOutOfStock = "The selected product is out of stock!";

			/// <summary>
			/// Constant for the number of products displayed on one page
			/// </summary>
			public const int ProductsPerPage = 25;

            /// <summary>
            /// Constant for unknown product characteristic
            /// </summary>
            public const string UnknownProductCharacteristic = "unknown";
		}

        /// <summary>
        /// Class holding Client constants
        /// </summary>
        public static class ClientConstants
        {
            /// <summary>
            /// Constant for the max number of allowed active sales
            /// </summary>
            public const int MaxNumberOfAllowedSales = 10;

            /// <summary>
            /// Constant for the error message of invalid User unique identifier
            /// </summary>
            public const string ErrorMessageForInvalidUserId = "Invalid user id!";

			/// <summary>
			/// Constant for the required number of purchases a client must make to become a SuperUser
			/// </summary>
			public const int RequiredNumberOfPurchasesToBeSuperUser = 5;
        }
    }
}
