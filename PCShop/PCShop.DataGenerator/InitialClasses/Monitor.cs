using PCShop.DataGenerator.InitialClasses.BaseClass;

namespace PCShop.DataGenerator.InitialClasses
{
    public class Monitor : Product
    {
        public double DisplaySize { get; set; }

        public string DisplayTechnology { get; set; } = null!;

        public string DisplayCoverage { get; set; } = null!;

        public string Resolution { get; set; } = null!;

        public int RefreshRate { get; set; }
    }
}
