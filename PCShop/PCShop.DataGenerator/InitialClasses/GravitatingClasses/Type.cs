namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Type
    {
        public Type()
        {
            this.LaptopTypes = new List<string>();
            this.MonitorTypes = new List<string>();
            this.KeyboardTypes = new List<string>();
            this.MouseTypes = new List<string>();
            this.HeadphoneTypes = new List<string>();
        }

        public IEnumerable<string> LaptopTypes { get; set; }

        public IEnumerable<string> MonitorTypes { get; set; }

        public IEnumerable<string> KeyboardTypes { get; set; }
        
        public IEnumerable<string> MouseTypes { get; set; }
        
        public IEnumerable<string> HeadphoneTypes { get; set; }
    }
}
