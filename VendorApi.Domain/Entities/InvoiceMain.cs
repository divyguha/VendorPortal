using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class InvoiceMain
	{
      

        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int INVId { get; set; }
        
        public int POId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Cenvat { get; set; }
        public string EDCess { get; set; }
        public string SHECess { get; set; }
        public string STax { get; set; }
        public string ModeOfTransport { get; set; }
        public string TransporterName { get; set; }
        public string VehicleNo { get; set; }
        public string NameOfConsignee { get; set; }
        public int VendorId { get; set; }
        public int TotalInvoiceAmount { get; set; }
        public string GRNNo { get; set; }
        public string GRNDate { get; set; }
        public string BarcodeGenerated { get; set; }
        public int TotalGrossAmount { get; set; }
        public string Form16 { get; set; }
        public string TripNo { get; set; }
        public string FormType { get; set; }
        public string DSID { get; set; }
        public  int PackagingTotalAmount { get; set; }
        public  int FreightTotalAmount { get; set; }
        public int OthersTotalAmount { get; set; }
        public  int Servicetax { get; set; }
        public string IssueYear { get; set; }
        public   int FormAmount { get; set; }
        public string FormNo { get; set; }
        public string EnteredDate { get; set; }
        public    int TotalCgst { get; set; }
        public  int TotalSgst { get; set; }
        public  int TotalIgst { get; set; }
        public   int GstImpl { get; set; }
        public int EwayNum { get; set; }
        public string BarcodeText { get; set; }





        public virtual POMain POMain { get; set; }

       public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual ICollection<GRNMain> GRNMains { get; set; }

    }
}
