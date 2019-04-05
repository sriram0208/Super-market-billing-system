using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketBillingUI.Models
{
    public class BilledProductsTb
    {
        public int Id { get; set; }
        public Nullable<int> BillId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual BillingTable BillingTable { get; set; }
        public virtual ProductTb ProductTb { get; set; }

    }
}