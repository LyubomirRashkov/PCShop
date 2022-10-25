namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Format
    {
        public Format()
        {
            this.KeyboardFormats = new List<string>();
        }

        public IEnumerable<string> KeyboardFormats { get; set; }
    }
}
