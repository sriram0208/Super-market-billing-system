﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupermarketWebAPIBilling.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class supermarketDBEntities2 : DbContext
    {
        public supermarketDBEntities2()
            : base("name=supermarketDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BilledProductsTb> BilledProductsTbs { get; set; }
        public virtual DbSet<BillingTable> BillingTables { get; set; }
        public virtual DbSet<CustomerTb> CustomerTbs { get; set; }
        public virtual DbSet<ProductTb> ProductTbs { get; set; }
        public virtual DbSet<StaffLoginTb> StaffLoginTbs { get; set; }
    }
}
