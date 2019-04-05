using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketBillingUI.Models
{
    public class ProductTb
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ProductTb()
        //{
        //    this.BilledProductsTbs = new HashSet<BilledProductsTb>();
        //}

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public System.DateTime DateOfManufacture { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BilledProductsTb> BilledProductsTbs { get; set; }
    }
}