using JWT.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities
{
    public class OrderItem : BaseEntity<long>
    {
        public long ItemId {  get; set; }
        public long OrderId {  get; set; }
        public decimal SalesPrice {  get; set; }

        public decimal? ItemDiscount {  get; set; }
        public int Quantity { get; set; }

        public  Order Order { get; set; }
        public  Item Item { get; set; }
    }
}
