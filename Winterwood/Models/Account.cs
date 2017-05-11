using System;
using System.Collections.Generic;

namespace Winterwood.Models
{
    public partial class Account
    {
        public Account()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
