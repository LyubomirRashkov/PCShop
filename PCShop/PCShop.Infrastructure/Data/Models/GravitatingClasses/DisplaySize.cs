namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product display size model
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
        /// DisplaySize unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DisplaySize value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplaySizeLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplaySizeMonitors { get; set; }
    }
}
