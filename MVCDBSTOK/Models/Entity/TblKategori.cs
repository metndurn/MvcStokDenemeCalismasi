//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDBSTOK.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKategori()
        {
            this.TblUrunler = new HashSet<TblUrunler>();
        }
    
        public short KategoriId { get; set; }

        [Required(ErrorMessage ="Kategori Adini Bos Birakamazsiniz...!")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakterlik Kategori ?smi Giriniz...!")]
        public string KategoriAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblUrunler> TblUrunler { get; set; }
    }
}
