using Newtonsoft.Json;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using static PCShop.DataSeeder.Constant.Headphone;
using static PCShop.DataSeeder.Constant.Keyboard;
using static PCShop.DataSeeder.Constant.Laptop;
using static PCShop.DataSeeder.Constant.Microphone;
using static PCShop.DataSeeder.Constant.Monitor;
using static PCShop.DataSeeder.Constant.Mouse;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.DataSeeder
{
    /// <summary>
    /// Seeder model
    /// </summary>
    internal class Seeder
    {
        private readonly PCShopDbContext dbContext;
        private readonly Random random;

        /// <summary>
        /// Constructor of Seeder class
        /// </summary>
        internal Seeder()
        {
            this.dbContext = new PCShopDbContext();
            this.random = new Random();
        }

        /// <summary>
        /// Seeds data into the database
        /// </summary>
        internal void Seed()
        {
            this.SeedLaptops(LaptopsSourcePath);

            this.SeedMonitors(MonitorsSourcePath);

            this.SeedKeyboards(KeyboardsSourcePath);

            this.SeedMice(MiceSourcePath);

            this.SeedHeadphones(HeadphonesSourcePath);

            this.SeedMicrophones(MicrophonesSourcePath);
        }

        private void SeedLaptops(string laptopsSourcePath)
        {
            string laptopsAsString = File.ReadAllText(laptopsSourcePath);

            var laptopInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Laptop>>(laptopsAsString);

            if (laptopInputModels is not null)
            {
                foreach (var laptopInputModel in laptopInputModels)
                {
                    var laptop = new Laptop()
                    {
                        ImageUrl = laptopInputModel.ImageUrl,
                        Warranty = laptopInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(LaptopPriceMinValue, LaptopPriceMaxValue),
                        Quantity = this.random.Next(LaptopQuantityMinValue, LaptopQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == laptopInputModel.Brand);
                    dbBrand ??= new Brand { Name = laptopInputModel.Brand };
                    laptop.Brand = dbBrand;

                    var dbCpu = this.dbContext.CPUs.FirstOrDefault(cpu => cpu.Name == laptopInputModel.CPU);
                    dbCpu ??= new CPU { Name = laptopInputModel.CPU };
                    laptop.CPU = dbCpu;

                    var dbRam = this.dbContext.RAMs.FirstOrDefault(ram => ram.Value == laptopInputModel.RAM);
                    dbRam ??= new RAM { Value = laptopInputModel.RAM };
                    laptop.RAM = dbRam;

                    var dbSsdCapacity = this.dbContext.SSDCapacities.FirstOrDefault(s => s.Value == laptopInputModel.SSDCapacity);
                    dbSsdCapacity ??= new SSDCapacity { Value = laptopInputModel.SSDCapacity };
                    laptop.SSDCapacity = dbSsdCapacity;

                    var dbVideoCard = this.dbContext.VideoCards.FirstOrDefault(vc => vc.Name == laptopInputModel.VideoCard);
                    dbVideoCard ??= new VideoCard { Name = laptopInputModel.VideoCard };
                    laptop.VideoCard = dbVideoCard;

                    var dbType = this.dbContext.Types.FirstOrDefault(t => t.Name == laptopInputModel.Type);
                    dbType ??= new Type { Name = laptopInputModel.Type };
                    laptop.Type = dbType;

                    var dbDisplaySize = this.dbContext.DisplaySizes.FirstOrDefault(ds => ds.Value == laptopInputModel.DisplaySize);
                    dbDisplaySize ??= new DisplaySize { Value = laptopInputModel.DisplaySize };
                    laptop.DisplaySize = dbDisplaySize;

                    var dbDisplayCoverage = this.dbContext.DisplayCoverages.FirstOrDefault(dc => dc.Name == laptopInputModel.DisplayCoverage);
                    dbDisplayCoverage ??= new DisplayCoverage { Name = laptopInputModel.DisplayCoverage };
                    laptop.DisplayCoverage = dbDisplayCoverage;

                    var dbDisplayTechnology = this.dbContext.DisplayTechnologies.FirstOrDefault(dt => dt.Name == laptopInputModel.DisplayTechnology);
                    dbDisplayTechnology ??= new DisplayTechnology { Name = laptopInputModel.DisplayTechnology };
                    laptop.DisplayTechnology = dbDisplayTechnology;

                    var dbResolution = this.dbContext.Resolutions.FirstOrDefault(r => r.Value == laptopInputModel.Resolution);
                    dbResolution ??= new Resolution { Value = laptopInputModel.Resolution };
                    laptop.Resolution = dbResolution;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == laptopInputModel.Color);
                    dbColor ??= new Color { Name = laptopInputModel.Color };
                    laptop.Color = dbColor;

                    this.dbContext.Laptops.Add(laptop);

                    this.dbContext.SaveChanges();
                }
            }
        }

        private void SeedMonitors(string monitorsSourcePath)
        {
            string monitorsAsString = File.ReadAllText(monitorsSourcePath);

            var monitorInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Monitor>>(monitorsAsString);

            if (monitorInputModels is not null)
            {
                foreach (var monitorInputModel in monitorInputModels)
                {
                    var monitor = new Monitor()
                    {
                        ImageUrl = monitorInputModel.ImageUrl,
                        Warranty = monitorInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(MonitorPriceMinValue, MonitorPriceMaxValue),
                        Quantity = this.random.Next(MonitorQuantityMinValue, MonitorQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == monitorInputModel.Brand);
                    dbBrand ??= new Brand { Name = monitorInputModel.Brand };
                    monitor.Brand = dbBrand;

                    var dbDisplaySize = this.dbContext.DisplaySizes.FirstOrDefault(ds => ds.Value == monitorInputModel.DisplaySize);
                    dbDisplaySize ??= new DisplaySize { Value = monitorInputModel.DisplaySize };
                    monitor.DisplaySize = dbDisplaySize;

                    var dbType = this.dbContext.Types.FirstOrDefault(t => t.Name == monitorInputModel.Type);
                    dbType ??= new Type { Name = monitorInputModel.Type };
                    monitor.Type = dbType;

                    var dbDisplayCoverage = this.dbContext.DisplayCoverages.FirstOrDefault(dc => dc.Name == monitorInputModel.DisplayCoverage);
                    dbDisplayCoverage ??= new DisplayCoverage { Name = monitorInputModel.DisplayCoverage };
                    monitor.DisplayCoverage = dbDisplayCoverage;

                    var dbDisplayTechnology = this.dbContext.DisplayTechnologies.FirstOrDefault(dt => dt.Name == monitorInputModel.DisplayTechnology);
                    dbDisplayTechnology ??= new DisplayTechnology { Name = monitorInputModel.DisplayTechnology };
                    monitor.DisplayTechnology = dbDisplayTechnology;

                    var dbResolution = this.dbContext.Resolutions.FirstOrDefault(r => r.Value == monitorInputModel.Resolution);
                    dbResolution ??= new Resolution { Value = monitorInputModel.Resolution };
                    monitor.Resolution = dbResolution;

                    var dbRefreshRate = this.dbContext.RefreshRates.FirstOrDefault(rr => rr.Value == monitorInputModel.RefreshRate);
                    dbRefreshRate ??= new RefreshRate { Value = monitorInputModel.RefreshRate };
                    monitor.RefreshRate = dbRefreshRate;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == monitorInputModel.Color);
                    dbColor ??= new Color { Name = monitorInputModel.Color };
                    monitor.Color = dbColor;

                    this.dbContext.Monitors.Add(monitor);

                    this.dbContext.SaveChanges();
                }
            }
        }

        private void SeedKeyboards(string keyboardsSourcePath)
        {
            string keyboardsAsString = File.ReadAllText(keyboardsSourcePath);

            var keyboardInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Keyboard>>(keyboardsAsString);

            if (keyboardInputModels is not null)
            {
                foreach (var keyboardInputModel in keyboardInputModels)
                {
                    var keyboard = new Keyboard()
                    {
                        ImageUrl = keyboardInputModel.ImageUrl,
                        Warranty = keyboardInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(KeyboardPriceMinValue, KeyboardPriceMaxValue),
                        IsWireless = this.random.Next() % 2 == 1 ? true : false,
                        Quantity = this.random.Next(KeyboardQuantityMinValue, KeyboardQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == keyboardInputModel.Brand);
                    dbBrand ??= new Brand { Name = keyboardInputModel.Brand };
                    keyboard.Brand = dbBrand;

                    var dbFormat = this.dbContext.Formats.FirstOrDefault(f => f.Name == keyboardInputModel.Format);
                    dbFormat ??= new Format { Name = keyboardInputModel.Format };
                    keyboard.Format = dbFormat;

                    var dbType = this.dbContext.Types.FirstOrDefault(t => t.Name == keyboardInputModel.Type);
                    dbType ??= new Type { Name = keyboardInputModel.Type };
                    keyboard.Type = dbType;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == keyboardInputModel.Color);
                    dbColor ??= new Color { Name = keyboardInputModel.Color };
                    keyboard.Color = dbColor;

                    this.dbContext.Keyboards.Add(keyboard);

                    this.dbContext.SaveChanges();
                }
            }
        }

        private void SeedMice(string miceSourcePath)
        {
            string miceAsString = File.ReadAllText(miceSourcePath);

            var mouseInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Mouse>>(miceAsString);

            if (mouseInputModels is not null)
            {
                foreach (var mouseInputModel in mouseInputModels)
                {
                    var mouse = new Mouse()
                    {
                        ImageUrl = mouseInputModel.ImageUrl,
                        Warranty = mouseInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(MousePriceMinValue, MousePriceMaxValue),
                        IsWireless = this.random.Next() % 2 == 1 ? true : false,
                        Quantity = this.random.Next(MouseQuantityMinValue, MouseQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == mouseInputModel.Brand);
                    dbBrand ??= new Brand { Name = mouseInputModel.Brand };
                    mouse.Brand = dbBrand;

                    var dbType = this.dbContext.Types.FirstOrDefault(t => t.Name == mouseInputModel.Type);
                    dbType ??= new Type { Name = mouseInputModel.Type };
                    mouse.Type = dbType;

                    var dbSensitivity = this.dbContext.Sensitivities.FirstOrDefault(s => s.Range == mouseInputModel.Sensitivity);
                    dbSensitivity ??= new Sensitivity { Range = mouseInputModel.Sensitivity };
                    mouse.Sensitivity = dbSensitivity;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == mouseInputModel.Color);
                    dbColor ??= new Color { Name = mouseInputModel.Color };
                    mouse.Color = dbColor;

                    this.dbContext.Mice.Add(mouse);

                    this.dbContext.SaveChanges();
                }
            }
        }

        private void SeedHeadphones(string headphonesSourcePath)
        {
            string headphonesAsString = File.ReadAllText(headphonesSourcePath);

            var headphoneInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Headphone>>(headphonesAsString);

            if (headphoneInputModels is not null)
            {
                foreach (var headphoneInputModel in headphoneInputModels)
                {
                    var headphone = new Headphone()
                    {
                        ImageUrl = headphoneInputModel.ImageUrl,
                        Warranty = headphoneInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(HeadphonePriceMinValue, HeadphonePriceMaxValue),
                        IsWireless = this.random.Next() % 2 == 1 ? true : false,
                        HasMicrophone = this.random.Next() % 2 == 1 ? true : false,
                        Quantity = this.random.Next(HeadphoneQuantityMinValue, HeadphoneQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == headphoneInputModel.Brand);
                    dbBrand ??= new Brand { Name = headphoneInputModel.Brand };
                    headphone.Brand = dbBrand;

                    var dbType = this.dbContext.Types.FirstOrDefault(t => t.Name == headphoneInputModel.Type);
                    dbType ??= new Type { Name = headphoneInputModel.Type };
                    headphone.Type = dbType;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == headphoneInputModel.Color);
                    dbColor ??= new Color { Name = headphoneInputModel.Color };
                    headphone.Color = dbColor;

                    this.dbContext.Headphones.Add(headphone);

                    this.dbContext.SaveChanges();
                }
            }
        }

        private void SeedMicrophones(string microphonesSourcePath)
        {
            string microphonesAsString = File.ReadAllText(microphonesSourcePath);

            var microphoneInputModels = JsonConvert.DeserializeObject<IEnumerable<DataGenerator.Classes.Microphone>>(microphonesAsString);

            if (microphoneInputModels is not null)
            {
                foreach (var microphoneInputModel in microphoneInputModels)
                {
                    var microphone = new Microphone()
                    {
                        ImageUrl = microphoneInputModel.ImageUrl,
                        Warranty = microphoneInputModel.Warranty,

                        IsDeleted = false,

                        Price = this.random.Next(MicrophonePriceMinValue, MicrophonePriceMaxValue),
                        Quantity = this.random.Next(MicrophoneQuantityMinValue, MicrophoneQuantityMaxValue),
                        AddedOn = DateTime.UtcNow.Date,
                    };

                    var dbBrand = this.dbContext.Brands.FirstOrDefault(b => b.Name == microphoneInputModel.Brand);
                    dbBrand ??= new Brand { Name = microphoneInputModel.Brand };
                    microphone.Brand = dbBrand;

                    var dbColor = this.dbContext.Colors.FirstOrDefault(c => c.Name == microphoneInputModel.Color);
                    dbColor ??= new Color { Name = microphoneInputModel.Color };
                    microphone.Color = dbColor;

                    this.dbContext.Microphones.Add(microphone);

                    this.dbContext.SaveChanges();
                }
            }
        }
    }
}
