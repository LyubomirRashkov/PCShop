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

        public IList<string> LaptopTypes { get; set; }

        public IList<string> MonitorTypes { get; set; }

        public IList<string> KeyboardTypes { get; set; }
        
        public IList<string> MouseTypes { get; set; }
        
        public IList<string> HeadphoneTypes { get; set; }
    }
}
