namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Display size model
    /// </summary>
    public class DisplaySize
    {
        /// <summary>
        /// Constructor of DisplaySize class
        /// </summary>
        public DisplaySize()
        {
            this.DisplaySizeLaptops = new HashSet<Laptop>();
            this.DisplaySizeMonitors = new HashSet<Monitor>();
        }

        /// <summary>
        /// Property that represents displaySize unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents displaySize value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplaySizeLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplaySizeMonitors { get; set; }
    }
}
