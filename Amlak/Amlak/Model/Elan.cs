//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amlak.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Elan
    {
        public int Id { get; set; }
        public Nullable<int> Amlakid { get; set; }
        public string Condition { get; set; }
        public string Request { get; set; }
        public Nullable<int> Areaid { get; set; }
        public Nullable<int> Personalid { get; set; }
        public string Client { get; set; }
        public Nullable<int> C_Telefon { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Room { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateIn { get; set; }
        public Nullable<System.DateTime> DateOut { get; set; }
        public string Buyer { get; set; }
        public Nullable<int> B_Telefon { get; set; }
    
        public virtual Amlak Amlak { get; set; }
        public virtual Area Area { get; set; }
        public virtual Personal Personal { get; set; }
    }
}
