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
    
    public partial class GIAHAN
    {
        public string MaPhieu { get; set; }
        public int SoNgay { get; set; }
        public System.DateTime ThoiHan { get; set; }
    
        public virtual PHIEUMUONSACH PHIEUMUONSACH { get; set; }
    }
}
