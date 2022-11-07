namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Refresh rate model
    /// </summary>
    public class RefreshRate
    {
        /// <summary>
        /// Constructor of RefreshRate class
        /// </summary>
        public RefreshRate()
        {
            this.RefreshRateMonitors = new HashSet<Monitor>();
        }

        /// <summary>
        /// Property that represents refreshRate unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents refreshRate value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> RefreshRateMonitors { get; set; }
    }
}
