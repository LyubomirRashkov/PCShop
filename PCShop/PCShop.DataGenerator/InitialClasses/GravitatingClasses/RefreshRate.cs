﻿namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class RefreshRate
    {
        public RefreshRate()
        {
            this.RefreshRates = new List<int>();
        }

        public IList<int> RefreshRates { get; set; }
    }
}