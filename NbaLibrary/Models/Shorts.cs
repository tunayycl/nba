﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace NbaLibrary.Models
{
    public partial class Shorts
    {
        public Shorts()
        {
            purchase = new HashSet<purchase>();
        }

        public int ShortsID { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? TeamID { get; set; }
        public double? price { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<purchase> purchase { get; set; }
    }
}