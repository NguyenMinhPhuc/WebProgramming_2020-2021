namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCat")]
    public partial class tblCat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCat()
        {
            tblProes = new HashSet<tblPro>();
        }

        [Key]
        public int CatID { get; set; }

        [StringLength(50)]
        public string CatName { get; set; }

        public int? CatStatus { get; set; }

        [StringLength(50)]
        public string CatDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPro> tblProes { get; set; }
    }
}
