namespace ThuVienOnline.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        [Key]
        public int MaTheLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTheLoai { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }
    }
}
