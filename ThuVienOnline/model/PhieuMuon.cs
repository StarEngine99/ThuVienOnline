namespace ThuVienOnline.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuon")]
    public partial class PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            ChiTietPhieuMuon = new HashSet<ChiTietPhieuMuon>();
        }

        [Key]
        public int MaPhieuMuon { get; set; }

        public int MaNguoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayHenLay { get; set; }

        public DateTime? NgayHenTra { get; set; }

        public int? TrangThai { get; set; }

        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuon { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
