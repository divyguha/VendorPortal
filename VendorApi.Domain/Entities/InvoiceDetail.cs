using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class InvoiceDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceDetailId { get; set; }
        public int INVId { get; set; }
        public int NoOfPKTS { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public int TotalQuantityDespatched { get; set; }
        public int PricePerUnit { get; set; }
        public int InvoiceAmount { get; set; }
        public string EntereDate { get; set; }
        public string EnteredBy { get; set; }
       
        public string PlantCode { get; set; }
        public string TaxCode { get; set; }
        public int TotalInvoiceAmount { get; set; }
        public int MCenvat { get; set; }
        public int MEDCess { get; set; }
        public int MSHECess { get; set; }
        public int MSTax { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Packaging { get; set; }
        public int Freight { get; set; }
        public int Others { get; set; }
        public int MServiceTax { get; set; }
        public int MCgst { get; set; }
        public int MSgst { get; set; }
        public int MIgst { get; set; }
        public int MCgstPercent { get; set; }
        public int MSgstPercent { get; set; }
        public int MIgstPercent { get; set; }
        public virtual InvoiceMain InvoiceMain { get; set; }
    }
}
