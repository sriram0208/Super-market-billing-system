using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketBillingUI.Models
{
    public class BillingTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingTable()
        {
            this.BilledProductsTbs = new HashSet<BilledProductsTb>();
        }

        public int BillId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BilledProductsTb> BilledProductsTbs { get; set; }
        public virtual CustomerTb CustomerTb { get; set; }
    }
}