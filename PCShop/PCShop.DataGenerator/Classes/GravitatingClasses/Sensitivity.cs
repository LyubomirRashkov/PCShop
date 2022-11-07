namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Sensitivity model
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
        /// Property that represents a collection of mouse sensitivities
        /// </summary>
        public IList<string> MouseSensitivities { get; set; }
    }
}
