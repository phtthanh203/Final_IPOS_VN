using System;

namespace IPOS.Models
{
    public class DiscountCodeModel
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; } // "percent" or "fixed"
        public int DiscountValue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int MinOrderAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsUsed { get; set; }

        public override string ToString()
        {
            string value = DiscountType == "percent" ? $"{DiscountValue}%" : $"{DiscountValue:n0}đ";
            return $"{Code} - Giảm {value} (HSD: {ExpiryDate:dd/MM/yyyy})";
        }



    }
}
