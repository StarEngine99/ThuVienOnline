namespace ThuVienOnline.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YeuThich")]
    public partial class YeuThich
    {
        [Key]
        public int MaYeuThich { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaSach { get; set; }

        public DateTime? NgayThem { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
