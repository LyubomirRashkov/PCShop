namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product refresh rate model
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
        /// RefreshRate unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RefreshRate value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> RefreshRateMonitors { get; set; }
    }
}
