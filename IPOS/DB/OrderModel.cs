using System;

namespace IPOS_VN.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public bool IsTakeAway { get; set; }
        public int? TableId { get; set; }
    }
}
