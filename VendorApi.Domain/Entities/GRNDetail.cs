using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class GRNDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GRNDetailsID { get; set; }
        public int GRNMainId { get; set; }
        public int InvoiceMainId { get; set; }
         public int VendorId { get; set; }
         public int POId { get; set; }
        public int GRNQty { get; set; }
        public int RecievedQty { get; set; }
        public int AcceptQty { get; set; }
        public int RejectQty { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string Unit { get; set; }
        public string RejectReason { get; set; }
        public string GRNNo { get; set; }
        public string VendorCode { get; set; }
        public string SAPPONo { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Int64 POMainPOId { get; set; }
        public virtual GRNMain GRNMain { get; set; }
    }
}
