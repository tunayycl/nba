// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace NbaLibrary.Models
{
    public partial class purchase
    {
        public purchase()
        {
            Cart = new HashSet<Cart>();
        }

        public int purchaseID { get; set; }
        public int? jerseyid { get; set; }
        public int? shortsid { get; set; }
        public double? price { get; set; }
        public int? CustomerID { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Jersey jersey { get; set; }
        public virtual Shorts shorts { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}