namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Alias { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        public DateTime? CreateDate { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
