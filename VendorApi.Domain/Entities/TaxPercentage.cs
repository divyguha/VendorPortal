using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    /// <summary>
    /// Data inserted in to table 'TaxPercentage'  using SAP  
    /// </summary>
    public class TaxPercentage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxId { get; set; }
        public string TaxCode { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string ConditionType { get; set; }
        public string ConditionTypeDescription { get; set; }

        [Column(TypeName = "decimal(5,3)")]
        public decimal TaxRate { get; set; }

        public string SAPPONo { get; set; }
        public string MaterialCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

