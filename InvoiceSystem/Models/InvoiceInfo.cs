using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceSystem.Models
{
    public class InvoiceInfo
    {
        [Key] 
        public Guid Id { get; set; }= Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public List<ProductInfo> Prducts { get; set; }= new List<ProductInfo>();

       
    }
    public class ProductInfo 
    { 
        public string PrductName { get; set; }  
        public decimal UnitPrice { get; set; }   
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

    }
}