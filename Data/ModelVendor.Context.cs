﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAP_Vendor.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VendorEntities : DbContext
    {
        public VendorEntities()
            : base("name=VendorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Vendor_Attachment> Vendor_Attachment { get; set; }
        public virtual DbSet<VendorFlow> VendorFlows { get; set; }
        public virtual DbSet<SAP_VendorCreation> SAP_VendorCreation { get; set; }
    }
}