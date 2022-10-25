using PCShop.DataGenerator.InitialClasses.BaseClass;

namespace PCShop.DataGenerator.InitialClasses
{
    public class Laptop : Product
    {
        public string CPU { get; set; } = null!;

        public int RAM { get; set; }

        public int SSDCapacity { get; set; }

        public string VideoCard { get; set; } = null!;

        public double DisplaySize { get; set; }

        public string DisplayCoverage { get; set; } = null!;

        public string DisplayTechnology { get; set; } = null!;
    }
}
