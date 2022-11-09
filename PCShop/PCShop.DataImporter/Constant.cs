namespace PCShop.DataSeeder
{
    /// <summary>
    /// Class holding constants
    /// </summary>
    internal static class Constant
    {
        /// <summary>
        /// Class holding configuration constants
        /// </summary>
        internal static class ConfigurationConstants
        {
            /// <summary>
            /// Constant for the connection string
            /// </summary>
            internal const string ConnectionString = "Server = (local)\\SQLEXPRESS; Database = MyPCShop; Integrated Security = true; Encrypt = false";
        }

        /// <summary>
        /// Class holding laptop constants
        /// </summary>
        internal static class LaptopConstants
        {
            /// <summary>
            /// Constant fot the laptops source path
            /// </summary>
            internal const string LaptopsSourcePath = "../../../../PCShop.DataGenerator/Datasets/laptops.json";

            /// <summary>
            /// Constant for the min value of the laptop price
            /// </summary>
            internal const int LaptopPriceMinValue = 600;
            /// <summary>
            /// Constant for the max value of the laptop price
            /// </summary>
            internal const int LaptopPriceMaxValue = 10_000;

            /// <summary>
            /// Constant for the min value of the laptop quantity
            /// </summary>
            internal const int LaptopQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the laptop quantity
            /// </summary>
            internal const int LaptopQuantityMaxValue = 10;
        }

        /// <summary>
        /// Class holding monitor constants
        /// </summary>
        internal static class MonitorConstants
        {
            /// <summary>
            /// Constant fot the monitors source path
            /// </summary>
            internal const string MonitorsSourcePath = "../../../../PCShop.DataGenerator/Datasets/monitors.json";

            /// <summary>
            /// Constant for the min value of the monitor price
            /// </summary>
            internal const int MonitorPriceMinValue = 500;
            /// <summary>
            /// Constant for the max value of the monitor price
            /// </summary>
            internal const int MonitorPriceMaxValue = 8000;

            /// <summary>
            /// Constant for the min value of the monitor quantity
            /// </summary>
            internal const int MonitorQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the monitor quantity
            /// </summary>
            internal const int MonitorQuantityMaxValue = 10;
        }

        /// <summary>
        /// Class holding keyboard constants
        /// </summary>
        internal static class KeyboardConstants
        {
            /// <summary>
            /// Constant fot the keyboards source path
            /// </summary>
            internal const string KeyboardsSourcePath = "../../../../PCShop.DataGenerator/Datasets/keyboards.json";

            /// <summary>
            /// Constant for the min value of the keyboard price
            /// </summary>
            internal const int KeyboardPriceMinValue = 10;
            /// <summary>
            /// Constant for the max value of the keyboard price
            /// </summary>
            internal const int KeyboardPriceMaxValue = 200;

            /// <summary>
            /// Constant for the min value of the keyboard quantity
            /// </summary>
            internal const int KeyboardQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the keyboard quantity
            /// </summary>
            internal const int KeyboardQuantityMaxValue = 10;
        }

        /// <summary>
        /// Class holding mouse constants
        /// </summary>
        internal static class MouseConstants
        {
            /// <summary>
            /// Constant fot the mice source path
            /// </summary>
            internal const string MiceSourcePath = "../../../../PCShop.DataGenerator/Datasets/mice.json";

            /// <summary>
            /// Constant for the min value of the mouse price
            /// </summary>
            internal const int MousePriceMinValue = 10;
            /// <summary>
            /// Constant for the max value of the mouse price
            /// </summary>
            internal const int MousePriceMaxValue = 200;

            /// <summary>
            /// Constant for the min value of the mouse quantity
            /// </summary>
            internal const int MouseQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the mouse quantity
            /// </summary>
            internal const int MouseQuantityMaxValue = 10;
        }

        /// <summary>
        /// Class holding headphone constants
        /// </summary>
        internal static class HeadphoneConstants
        {
            /// <summary>
            /// Constant fot the headphones source path
            /// </summary>
            internal const string HeadphonesSourcePath = "../../../../PCShop.DataGenerator/Datasets/headphones.json";

            /// <summary>
            /// Constant for the min value of the headphone price
            /// </summary>
            internal const int HeadphonePriceMinValue = 30;
            /// <summary>
            /// Constant for the max value of the headphone price
            /// </summary>
            internal const int HeadphonePriceMaxValue = 500;

            /// <summary>
            /// Constant for the min value of the headphone quantity
            /// </summary>
            internal const int HeadphoneQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the headphone quantity
            /// </summary>
            internal const int HeadphoneQuantityMaxValue = 10;
        }

        /// <summary>
        /// Class holding microphone constants
        /// </summary>
        internal static class MicrophoneConstants
        {
            /// <summary>
            /// Constant fot the microphones source path
            /// </summary>
            internal const string MicrophonesSourcePath = "../../../../PCShop.DataGenerator/Datasets/microphones.json";

            /// <summary>
            /// Constant for the min value of the microphone price
            /// </summary>
            internal const int MicrophonePriceMinValue = 20;
            /// <summary>
            /// Constant for the max value of the microphone price
            /// </summary>
            internal const int MicrophonePriceMaxValue = 300;

            /// <summary>
            /// Constant for the min value of the microphone quantity
            /// </summary>
            internal const int MicrophoneQuantityMinValue = 1;
            /// <summary>
            /// Constant for the max value of the microphone quantity
            /// </summary>
            internal const int MicrophoneQuantityMaxValue = 10;
        }
    }
}
