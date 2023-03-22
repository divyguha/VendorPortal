using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class GRNMain
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GRNMainId { get; set; }
        public int POId { get; set; }
        public string GRNNo { get; set; }
        public string GRNDate { get; set; }
        public string StoreLocation { get; set; }
        public string PurchaseGroup { get; set; }
        public string Telephone { get; set; }
        public string J1IANo { get; set; }
        public string ExciseDocNo { get; set; }
        public string BillOfLading { get; set; }
        public string DocHeaderText { get; set; }
        public string DeliveryNote { get; set; }
        public int InspectionLot { get; set; }
        public string TruckNo { get; set; }
        public string InvoiceMainId { get; set; }
        public string InvoiceNum { get; set; }
        public string InvoiceDate { get; set; }
        public string PONum { get; set; }
        public string EnteredDate { get; set; }
        public string ModifiedDate { get; set; }



       public virtual ICollection<GRNDetail> GRNDetails { get; set; }
        public virtual POMain POMain { get; set; }
        public virtual InvoiceMain InvoiceMain { get; set; }

    }
}
