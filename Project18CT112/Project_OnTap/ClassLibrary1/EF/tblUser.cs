namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Userpass { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        public int? Status { get; set; }

        public int? Systemright { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
