using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
 {
    /// <summary>
    /// Data inserted in to table 'POMain' using SAP   
    /// </summary>
    public class POMain
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int POId { get; set; }
        public string SAPPONo { get; set; }
        public string PODate { get; set; }
        public string TINNo { get; set; }
        public string ECCNo { get; set; }
        public string PANNo { get; set; }
        public string SRVTaxNo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal POValue { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string TermsConditions { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public string Currency { get; set; }
        public string SAPVendorCode { get; set; }
        public DateTime? UnapprovedDate { get; set; }
        public string UnApprovedStatus { get; set; }

        public string UnapprovedBy { get; set; }
        public  DateTime? ApprovedDate { get; set; }
        public string ReleaseStatus { get; set; }
        public string POHeaderText { get; set; }
        public string POStatus { get; set; }
        public string Plant { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int VendorId { get; set; }


        public virtual ICollection<PODetail> PODetails { get; set; }

        public virtual ICollection<InvoiceMain> InvoiceMains { get; set; }

        public virtual ICollection<GRNMain> GRNMains { get; set; }
      
        public virtual ICollection<DeliveryScheduleMain> DeliveryScheduleMain { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}
