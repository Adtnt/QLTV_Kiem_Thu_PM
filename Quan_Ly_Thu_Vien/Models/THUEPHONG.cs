//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_Ly_Thu_Vien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THUEPHONG
    {
        public string MaHV { get; set; }
        public string MaPH { get; set; }
        public System.DateTime NgayThue { get; set; }
        public int ThoiGian { get; set; }
        public int DonGia { get; set; }
    
        public virtual HOIVIEN HOIVIEN { get; set; }
        public virtual PHONGHOP PHONGHOP { get; set; }
    }
}