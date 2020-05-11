namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlanetFilter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string PlanetName { get; set; }

        public bool? Moon0to5 { get; set; }

        public bool? Moon6to15 { get; set; }

        public bool? Moon16to30 { get; set; }

        public bool? Moon30plus { get; set; }

        public bool? TypeTerra { get; set; }

        public bool? TypeGas { get; set; }

        public bool? TypeIce { get; set; }

        public bool? SizeSmaller { get; set; }

        public bool? SizeEarthlike { get; set; }

        public bool? SizeLarger { get; set; }

        public bool? SizeMassive { get; set; }

        public bool? Orbit1Year { get; set; }

        public bool? Orbit1to10Year { get; set; }

        public bool? Orbit11to30Year { get; set; }

        public bool? Orbit30plusYear { get; set; }

        public bool? WaterIce { get; set; }

        public bool? WaterLiquid { get; set; }

        public bool? WaterVapor { get; set; }

        public bool? HumanContactTrue { get; set; }

        public bool? HumanContactFalse { get; set; }

        public bool? AtmoNone { get; set; }

        public bool? AtmoThin { get; set; }

        public bool? AtmoModerate { get; set; }

        public bool? AtmoHeavy { get; set; }

        public bool? AtmoIcy { get; set; }

        public bool? RingsTrue { get; set; }

        public bool? RingsFalse { get; set; }
    }
}
