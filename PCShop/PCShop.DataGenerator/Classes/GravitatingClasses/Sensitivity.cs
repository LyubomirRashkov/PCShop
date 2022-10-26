namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of mouse sensitivities
    /// </summary>
    public class Sensitivity
    {
        /// <summary>
        /// Constructor of Sensitivity class
        /// </summary>
        public Sensitivity()
        {
            this.MouseSensitivities = new List<string>();
        }

        /// <summary>
        /// Collection of mouse sensitivities
        /// </summary>
        public IList<string> MouseSensitivities { get; set; }
    }
}
