using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketBillingUI.Models
{
    public  class CustomerTb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerTb()
        {
            this.BillingTables = new HashSet<BillingTable>();
        }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Points { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingTable> BillingTables { get; set; }
    }
}