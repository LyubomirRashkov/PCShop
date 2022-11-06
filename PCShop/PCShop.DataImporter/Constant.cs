namespace PCShop.DataSeeder
{
    /// <summary>
    /// Class holding constants
    /// </summary>
    internal static class Constant
    {
        /// <summary>
        /// Configuration constants
        /// </summary>
        internal static class Configuration
        {
            /// <summary>
            /// Connection string constant
            /// </summary>
            internal const string ConnectionString = "Server = (local)\\SQLEXPRESS; Database = MyPCShop; Integrated Security = true; Encrypt = false";
        }

        /// <summary>
        /// Laptop constants
        /// </summary>
        internal static class Laptop
        {
            /// <summary>
            /// Laptops source path constant
            /// </summary>
            internal const string LaptopsSourcePath = "../../../../PCShop.DataGenerator/Datasets/laptops.json";

            /// <summary>
            /// Laptop price min value constant
            /// </summary>
            internal const int LaptopPriceMinValue = 600;
            /// <summary>
            /// Laptop price max value constant
            /// </summary>
            internal const int LaptopPriceMaxValue = 10_000;

            /// <summary>
            /// Laptop quantity min value constant
            /// </summary>
            internal const int LaptopQuantityMinValue = 1;
            /// <summary>
            /// Laptop quantity max value constant
            /// </summary>
            internal const int LaptopQuantityMaxValue = 10;
        }

        /// <summary>
        /// Monitor constants
        /// </summary>
        internal static class Monitor
        {
            /// <summary>
            /// Monitors source path constant
            /// </summary>
            internal const string MonitorsSourcePath = "../../../../PCShop.DataGenerator/Datasets/monitors.json";

            /// <summary>
            /// Monitor price min value constant
            /// </summary>
            internal const int MonitorPriceMinValue = 500;
            /// <summary>
            /// Monitor price max value constant
            /// </summary>
            internal const int MonitorPriceMaxValue = 8000;

            /// <summary>
            /// Monitor quantity min value constant
            /// </summary>
            internal const int MonitorQuantityMinValue = 1;
            /// <summary>
            /// Monitor quantity max value constant
            /// </summary>
            internal const int MonitorQuantityMaxValue = 10;
        }

        /// <summary>
        /// Keyboard constants
        /// </summary>
        internal static class Keyboard
        {
            /// <summary>
            /// Keyboards source path constant
            /// </summary>
            internal const string KeyboardsSourcePath = "../../../../PCShop.DataGenerator/Datasets/keyboards.json";

            /// <summary>
            /// Keyboard price min value constant
            /// </summary>
            internal const int KeyboardPriceMinValue = 10;
            /// <summary>
            /// Keyboard price max value constant
            /// </summary>
            internal const int KeyboardPriceMaxValue = 200;

            /// <summary>
            /// Keyboard quantity min value constant
            /// </summary>
            internal const int KeyboardQuantityMinValue = 1;
            /// <summary>
            /// Keyboard quantity max value constant
            /// </summary>
            internal const int KeyboardQuantityMaxValue = 10;
        }

        /// <summary>
        /// Mouse constants
        /// </summary>
        internal static class Mouse
        {
            /// <summary>
            /// Mice source path constant
            /// </summary>
            internal const string MiceSourcePath = "../../../../PCShop.DataGenerator/Datasets/mice.json";

            /// <summary>
            /// Mouse price min value constant
            /// </summary>
            internal const int MousePriceMinValue = 10;
            /// <summary>
            /// Mouse price max value constant
            /// </summary>
            internal const int MousePriceMaxValue = 200;

            /// <summary>
            /// Mouse quantity min value constant
            /// </summary>
            internal const int MouseQuantityMinValue = 1;
            /// <summary>
            /// Mouse quantity max value constant
            /// </summary>
            internal const int MouseQuantityMaxValue = 10;
        }

        /// <summary>
        /// Headphone constants
        /// </summary>
        internal static class Headphone
        {
            /// <summary>
            /// Headphones source path constant
            /// </summary>
            internal const string HeadphonesSourcePath = "../../../../PCShop.DataGenerator/Datasets/headphones.json";

            /// <summary>
            /// Headphone price min value constant
            /// </summary>
            internal const int HeadphonePriceMinValue = 30;
            /// <summary>
            /// Headphone price max value constant
            /// </summary>
            internal const int HeadphonePriceMaxValue = 500;

            /// <summary>
            /// Headphone quantity min value constant
            /// </summary>
            internal const int HeadphoneQuantityMinValue = 1;
            /// <summary>
            /// Headphone quantity max value constant
            /// </summary>
            internal const int HeadphoneQuantityMaxValue = 10;
        }

        /// <summary>
        /// Microphone constants
        /// </summary>
        internal static class Microphone
        {
            /// <summary>
            /// Microphones source path constant
            /// </summary>
            internal const string MicrophonesSourcePath = "../../../../PCShop.DataGenerator/Datasets/microphones.json";

            /// <summary>
            /// Microphone price min value constant
            /// </summary>
            internal const int MicrophonePriceMinValue = 20;
            /// <summary>
            /// Microphone price max value constant
            /// </summary>
            internal const int MicrophonePriceMaxValue = 300;

            /// <summary>
            /// Microphone quantity min value constant
            /// </summary>
            internal const int MicrophoneQuantityMinValue = 1;
            /// <summary>
            /// Microphone quantity max value constant
            /// </summary>
            internal const int MicrophoneQuantityMaxValue = 10;
        }
    }
}
