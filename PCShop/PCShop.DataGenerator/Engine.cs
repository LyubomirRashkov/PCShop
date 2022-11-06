using Newtonsoft.Json;
using PCShop.DataGenerator.Classes.GravitatingClasses;
using Type = PCShop.DataGenerator.Classes.GravitatingClasses.Type;
using PCShop.DataGenerator.Classes;
using static PCShop.DataGenerator.Constant;
using Monitor = PCShop.DataGenerator.Classes.Monitor;

namespace PCShop.DataGenerator
{
    /// <summary>
    /// The "core" class
    /// </summary>
    internal class Engine
    {
        private readonly Random randomNumber;

        /// <summary>
        /// Constructor of Engine class
        /// </summary>
        internal Engine()
        {
            this.randomNumber = new Random();
        }

        /// <summary>
        /// Property holding all brands by product type
        /// </summary>
        internal Brand Brands => this.Deserialize<Brand>("InitialSourceFiles/brands.json");

        /// <summary>
        /// Property holding all colors by product type
        /// </summary>
        internal Color Colors => this.Deserialize<Color>("InitialSourceFiles/colors.json");

        /// <summary>
        /// Property holding all CPUs
        /// </summary>
        internal CPU CPUs => this.Deserialize<CPU>("InitialSourceFiles/cpus.json");

        /// <summary>
        /// Property holding all displpay coverages by product type
        /// </summary>
        internal DisplayCoverage DisplayCoverages => this.Deserialize<DisplayCoverage>(
                                                   "InitialSourceFiles/displayCoverages.json");

        /// <summary>
        /// Property holding all display sizes by product type
        /// </summary>
        internal DisplaySize DisplaySizes => this.Deserialize<DisplaySize>("InitialSourceFiles/displaySizes.json");

        /// <summary>
        /// Property holding all display technologies
        /// </summary>
        internal DisplayTechnology DisplayTechnologies => this.Deserialize<DisplayTechnology>(
                                                        "InitialSourceFiles/displayTechnologies.json");

        /// <summary>
        /// Property holding all keyboard formats
        /// </summary>
        internal Format Formats => this.Deserialize<Format>("InitialSourceFiles/formats.json");

        /// <summary>
        /// Property holding all URLs of images by product type
        /// </summary>
        internal ImageUrl ImageUrls => this.Deserialize<ImageUrl>("InitialSourceFiles/imageURLs.json");

        /// <summary>
        /// Property holding all RAMs
        /// </summary>
        internal RAM RAMs => this.Deserialize<RAM>("InitialSourceFiles/rams.json");

        /// <summary>
        /// Property holding all monitor refresh rates
        /// </summary>
        internal RefreshRate RefreshRates => this.Deserialize<RefreshRate>("InitialSourceFiles/refreshRates.json");

        /// <summary>
        /// Property holding all resolutions by product type
        /// </summary>
        internal Resolution Resolutions => this.Deserialize<Resolution>("InitialSourceFiles/resolutions.json");

        /// <summary>
        /// Property holding all mouse sensitivities
        /// </summary>
        internal Sensitivity Sensitivities => this.Deserialize<Sensitivity>("InitialSourceFiles/sensitivities.json");

        /// <summary>
        /// Property holding all laptop SSD capacities
        /// </summary>
        internal SSDCapacity SSDCapacities => this.Deserialize<SSDCapacity>("InitialSourceFiles/ssds.json");

        /// <summary>
        /// Property holding all types by product type
        /// </summary>
        internal Type Types => this.Deserialize<Type>("InitialSourceFiles/types.json");

        /// <summary>
        /// Property holding all laptop video cards
        /// </summary>
        internal VideoCard VideoCards => this.Deserialize<VideoCard>("InitialSourceFiles/videoCards.json");

        /// <summary>
        /// Property holding all warranties
        /// </summary>
        internal Warranty Warranties => this.Deserialize<Warranty>("InitialSourceFiles/warranties.json");

        /// <summary>
        /// The "starting" method
        /// </summary>
        internal void Run()
        {
            var laptops = this.CreateLaptops();

            this.WriteToFileAsJson(laptops, "../../../Datasets/laptops.json");

            var monitors = this.CreateMonitors();

            this.WriteToFileAsJson(monitors, "../../../Datasets/monitors.json");

            var keyboards = this.CreateKeyboards();

            this.WriteToFileAsJson(keyboards, "../../../Datasets/keyboards.json");

            var mice = this.CreateMice();

            this.WriteToFileAsJson(mice, "../../../Datasets/mice.json");

            var headphones = this.CreateHeadphones();

            this.WriteToFileAsJson(headphones, "../../../Datasets/headphones.json");

            var microphones = this.CreateMicrophones();

            this.WriteToFileAsJson(microphones, "../../../Datasets/microphones.json");
        }

        private T Deserialize<T>(string destinationPath)
        {
            string jsonAsString = File.ReadAllText(destinationPath);

            return JsonConvert.DeserializeObject<T>(jsonAsString);
        }

        private List<Laptop> CreateLaptops()
        {
            var laptops = new List<Laptop>(LaptopsCount);

            for (int i = 0; i < LaptopsCount; i++)
            {
                var laptop = new Laptop()
                {
                    Brand = this.Brands.LaptopBrands[randomNumber.Next(this.Brands.LaptopBrands.Count)],
                    Color = this.Colors.LaptopColors[randomNumber.Next(this.Colors.LaptopColors.Count)],
                    ImageUrl = this.ImageUrls.LaptopImageUrls[randomNumber.Next(this.ImageUrls.LaptopImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    CPU = this.CPUs.LaptopCPUs[randomNumber.Next(this.CPUs.LaptopCPUs.Count)],
                    RAM = this.RAMs.LaptopRAMs[randomNumber.Next(this.RAMs.LaptopRAMs.Count)],
                    SSDCapacity = this.SSDCapacities.LaptopSSDCapacities[randomNumber
                                                    .Next(this.SSDCapacities.LaptopSSDCapacities.Count)],
                    VideoCard = this.VideoCards.LaptopVideoCards[randomNumber
                                               .Next(this.VideoCards.LaptopVideoCards.Count)],
                    Type = this.Types.LaptopTypes[randomNumber.Next(this.Types.LaptopTypes.Count)],
                    DisplaySize = this.DisplaySizes.LaptopDisplaySizes[randomNumber
                                                   .Next(this.DisplaySizes.LaptopDisplaySizes.Count)],
                    DisplayCoverage = this.DisplayCoverages.DisplayCoverages[randomNumber
                                                           .Next(this.DisplayCoverages.DisplayCoverages.Count)],
                    DisplayTechnology = this.DisplayTechnologies.DisplayTechnologies[randomNumber
                                                               .Next(this.DisplayTechnologies.DisplayTechnologies.Count)],
                    Resolution = this.Resolutions.LaptopResolutions[randomNumber
                                                 .Next(this.Resolutions.LaptopResolutions.Count)],
                };

                laptops.Add(laptop);
            }

            return laptops;
        }

        private List<Monitor> CreateMonitors()
        {
            var monitors = new List<Monitor>(MonitorsCount);

            for (int i = 0; i < MonitorsCount; i++)
            {
                var monitor = new Monitor()
                {
                    Brand = this.Brands.MonitorBrands[randomNumber.Next(this.Brands.MonitorBrands.Count)],
                    Color = this.Colors.MonitorColors[randomNumber.Next(this.Colors.MonitorColors.Count)],
                    ImageUrl = this.ImageUrls.MonitorImageUrls[randomNumber.Next(this.ImageUrls.MonitorImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    DisplaySize = this.DisplaySizes.MonitorDisplaySizes[randomNumber
                                                   .Next(this.DisplaySizes.MonitorDisplaySizes.Count)],
                    Type = this.Types.MonitorTypes[randomNumber.Next(this.Types.MonitorTypes.Count)],
                    DisplayTechnology = this.DisplayTechnologies.DisplayTechnologies[randomNumber
                                                               .Next(this.DisplayTechnologies.DisplayTechnologies.Count)],
                    DisplayCoverage = this.DisplayCoverages.DisplayCoverages[randomNumber
                                                           .Next(this.DisplayCoverages.DisplayCoverages.Count)],
                    Resolution = this.Resolutions.MonitorResolutions[randomNumber
                                                 .Next(this.Resolutions.MonitorResolutions.Count)],
                    RefreshRate = this.RefreshRates.RefreshRates[randomNumber.Next(this.RefreshRates.RefreshRates.Count)],
                };

                monitors.Add(monitor);
            }

            return monitors;
        }

        private List<Keyboard> CreateKeyboards()
        {
            var keyboards = new List<Keyboard>(KeyboardsCount);

            for (int i = 0; i < KeyboardsCount; i++)
            {
                var keyboard = new Keyboard()
                {
                    Brand = this.Brands.KeyboardBrands[randomNumber.Next(this.Brands.KeyboardBrands.Count)],
                    Color = this.Colors.KeyboardColors[randomNumber.Next(this.Colors.KeyboardColors.Count)],
                    ImageUrl = this.ImageUrls.KeyboardImageUrls[randomNumber
                                             .Next(this.ImageUrls.KeyboardImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    Format = this.Formats.KeyboardFormats[randomNumber.Next(this.Formats.KeyboardFormats.Count)],
                    Type = this.Types.KeyboardTypes[randomNumber.Next(this.Types.KeyboardTypes.Count)],
                };

                keyboards.Add(keyboard);
            }

            return keyboards;
        }

        private List<Mouse> CreateMice()
        {
            var mice = new List<Mouse>(MiceCount);

            for (int i = 0; i < MiceCount; i++)
            {
                var mouse = new Mouse()
                {
                    Brand = this.Brands.MouseBrands[randomNumber.Next(this.Brands.MouseBrands.Count)],
                    Color = this.Colors.MouseColors[randomNumber.Next(this.Colors.MouseColors.Count)],
                    ImageUrl = this.ImageUrls.MouseImageUrls[randomNumber.Next(this.ImageUrls.MouseImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    Type = this.Types.MouseTypes[randomNumber.Next(this.Types.MouseTypes.Count)],
                    Sensitivity = this.Sensitivities.MouseSensitivities[randomNumber
                                                    .Next(this.Sensitivities.MouseSensitivities.Count)],
                };

                mice.Add(mouse);
            }

            return mice;
        }

        private List<Headphone> CreateHeadphones()
        {
            var headphones = new List<Headphone>(HeadphonesCount);

            for (int i = 0; i < HeadphonesCount; i++)
            {
                var headphone = new Headphone()
                {
                    Brand = this.Brands.HeadphoneBrands[randomNumber.Next(this.Brands.HeadphoneBrands.Count)],
                    Color = this.Colors.HeadphoneColors[randomNumber.Next(this.Colors.HeadphoneColors.Count)],
                    ImageUrl = this.ImageUrls.HeadphoneImageUrls[randomNumber
                                             .Next(this.ImageUrls.HeadphoneImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    Type = this.Types.HeadphoneTypes[randomNumber.Next(this.Types.HeadphoneTypes.Count)],
                };

                headphones.Add(headphone);
            }

            return headphones;
        }

        private List<Microphone> CreateMicrophones()
        {
            var microphones = new List<Microphone>(MicrophonesCount);

            for (int i = 0; i < MicrophonesCount; i++)
            {
                var microphone = new Microphone()
                {
                    Brand = this.Brands.MicrophoneBrands[randomNumber.Next(this.Brands.MicrophoneBrands.Count)],
                    Color = this.Colors.MicrophoneColors[randomNumber.Next(this.Colors.MicrophoneColors.Count)],
                    ImageUrl = this.ImageUrls.MicrophoneImageUrls[randomNumber
                                             .Next(this.ImageUrls.MicrophoneImageUrls.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                };

                microphones.Add(microphone);
            }

            return microphones;
        }

        private void WriteToFileAsJson(IEnumerable<object> collection, string destinationPath)
        {
            string collectionAsJson = JsonConvert.SerializeObject(collection, Formatting.Indented);

            File.WriteAllText(destinationPath, collectionAsJson);
        }
    }
}
