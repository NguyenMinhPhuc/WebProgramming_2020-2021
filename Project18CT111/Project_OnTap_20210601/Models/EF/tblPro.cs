namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPro")]
    public partial class tblPro
    {
        [Key]
        public int ProID { get; set; }

        [StringLength(50)]
        public string ProName { get; set; }

        public int? ProStatus { get; set; }

        [StringLength(50)]
        public string ProDescription { get; set; }

        public int? CatID { get; set; }

        public virtual tblCat tblCat { get; set; }
    }
}
