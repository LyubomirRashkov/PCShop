namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Sensitivity
    {
        public Sensitivity()
        {
            this.MouseSensitivities = new List<string>();
        }

        public IEnumerable<string> MouseSensitivities { get; set; }
    }
}
