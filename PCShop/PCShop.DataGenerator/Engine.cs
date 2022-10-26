using Newtonsoft.Json;
using PCShop.DataGenerator.Classes.GravitatingClasses;
using Type = PCShop.DataGenerator.Classes.GravitatingClasses.Type;
using PCShop.DataGenerator.Classes;
using static PCShop.DataGenerator.Constants;
using Monitor = PCShop.DataGenerator.Classes.Monitor;

namespace PCShop.DataGenerator
{
    /// <summary>
    /// The "core" class
    /// </summary>
    public class Engine
    {
        private readonly Random randomNumber;

        /// <summary>
        /// Constructor of Engine class
        /// </summary>
        public Engine()
        {
            this.randomNumber = new Random();
        }

        /// <summary>
        /// Property holding all brands by product type
        /// </summary>
        public Brand Brands => this.Deserialize<Brand>("InitialSourceFiles/brands.json");

        /// <summary>
        /// Property holding all colors by product type
        /// </summary>
        public Color Colors => this.Deserialize<Color>("InitialSourceFiles/colors.json");

        /// <summary>
        /// Property holding all CPUs
        /// </summary>
        public CPU CPUs => this.Deserialize<CPU>("InitialSourceFiles/cpus.json");

        /// <summary>
        /// Property holding all displpay coverages by product type
        /// </summary>
        public DisplayCoverage DisplayCoverages => this.Deserialize<DisplayCoverage>(
                                                   "InitialSourceFiles/displayCoverages.json");

        /// <summary>
        /// Property holding all display sizes by product type
        /// </summary>
        public DisplaySize DisplaySizes => this.Deserialize<DisplaySize>("InitialSourceFiles/displaySizes.json");

        /// <summary>
        /// Property holding all display technologies
        /// </summary>
        public DisplayTechnology DisplayTechnologies => this.Deserialize<DisplayTechnology>(
                                                        "InitialSourceFiles/displayTechnologies.json");

        /// <summary>
        /// Property holding all keyboard formats
        /// </summary>
        public Format Formats => this.Deserialize<Format>("InitialSourceFiles/formats.json");

        /// <summary>
        /// Property holding all URLs of images by product type
        /// </summary>
        public ImageURL ImageURLs => this.Deserialize<ImageURL>("InitialSourceFiles/imageURLs.json");

        /// <summary>
        /// Property holding all RAMs
        /// </summary>
        public RAM RAMs => this.Deserialize<RAM>("InitialSourceFiles/rams.json");

        /// <summary>
        /// Property holding all monitor refresh rates
        /// </summary>
        public RefreshRate RefreshRates => this.Deserialize<RefreshRate>("InitialSourceFiles/refreshRates.json");

        /// <summary>
        /// Property holding all resolutions by product type
        /// </summary>
        public Resolution Resolutions => this.Deserialize<Resolution>("InitialSourceFiles/resolutions.json");

        /// <summary>
        /// Property holding all mouse sensitivities
        /// </summary>
        public Sensitivity Sensitivities => this.Deserialize<Sensitivity>("InitialSourceFiles/sensitivities.json");

        /// <summary>
        /// Property holding all laptop SSD capacities
        /// </summary>
        public SSDCapacity SSDCapacities => this.Deserialize<SSDCapacity>("InitialSourceFiles/ssds.json");

        /// <summary>
        /// Property holding all types by product type
        /// </summary>
        public Type Types => this.Deserialize<Type>("InitialSourceFiles/types.json");

        /// <summary>
        /// Property holding all laptop video cards
        /// </summary>
        public VideoCard VideoCards => this.Deserialize<VideoCard>("InitialSourceFiles/videoCards.json");

        /// <summary>
        /// Property holding all warranties
        /// </summary>
        public Warranty Warranties => this.Deserialize<Warranty>("InitialSourceFiles/warranties.json");

        /// <summary>
        /// The "starting" method
        /// </summary>
        public void Run()
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
                    ImageUrl = this.ImageURLs.LaptopImageURLs[randomNumber.Next(this.ImageURLs.LaptopImageURLs.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    CPU = this.CPUs.LaptopCPUs[randomNumber.Next(this.CPUs.LaptopCPUs.Count)],
                    RAM = this.RAMs.LaptopRAMs[randomNumber.Next(this.RAMs.LaptopRAMs.Count)],
                    SSDCapacity = this.SSDCapacities.LaptopSSDCapacities[randomNumber
                                                    .Next(this.SSDCapacities.LaptopSSDCapacities.Count)],
                    VideoCard = this.VideoCards.LaptopVideoCards[randomNumber
                                               .Next(this.VideoCards.LaptopVideoCards.Count)],
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
                    ImageUrl = this.ImageURLs.MonitorImageURLs[randomNumber.Next(this.ImageURLs.MonitorImageURLs.Count)],
                    Warranty = this.Warranties.Warranties[randomNumber.Next(this.Warranties.Warranties.Count)],
                    DisplaySize = this.DisplaySizes.MonitorDisplaySizes[randomNumber
                                                   .Next(this.DisplaySizes.MonitorDisplaySizes.Count)],
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
                    ImageUrl = this.ImageURLs.KeyboardImageURLs[randomNumber
                                             .Next(this.ImageURLs.KeyboardImageURLs.Count)],
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
                    ImageUrl = this.ImageURLs.MouseImageURLs[randomNumber.Next(this.ImageURLs.MouseImageURLs.Count)],
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
                    ImageUrl = this.ImageURLs.HeadphoneImageURLs[randomNumber
                                             .Next(this.ImageURLs.HeadphoneImageURLs.Count)],
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
                    ImageUrl = this.ImageURLs.MicrophoneImageURLs[randomNumber
                                             .Next(this.ImageURLs.MicrophoneImageURLs.Count)],
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
