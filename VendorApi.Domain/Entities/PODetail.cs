using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VendorApi.Domain.Entities
{
    /// <summary>
    /// Data inserted in to table 'PODetail' using SAP  
    /// </summary>
    public class PODetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PODetailId { get; set; }
        public int POId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string Qty { get; set; }
        public string Unit { get; set; }
        public string PricePerUnit { get; set; }
        public string GrossValue { get; set; }
        public string SAPCode { get; set; }
        public string PONumber { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string TaxCode { get; set; }
        public string NetValue { get; set; }
        public string LockStatus { get; set; }
        public virtual ICollection<POMain> POMain { get; set; }
    }
}