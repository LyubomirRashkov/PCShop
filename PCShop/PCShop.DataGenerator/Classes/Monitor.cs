using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
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
