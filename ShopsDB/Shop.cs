namespace ShopsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shop
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Building_number { get; set; }

        [StringLength(50)]
        public string Phone_number { get; set; }

        [StringLength(50)]
        public string Cellphone_number_1 { get; set; }

        [StringLength(50)]
        public string Cellphone_number_2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
