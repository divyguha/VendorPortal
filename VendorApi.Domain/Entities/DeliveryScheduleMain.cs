using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class DeliveryScheduleMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryScheduleMainId { get; set; }
        public int POId { get; set; }
        public int VendorId { get; set; }
        public string DSMonth { get; set; }
        public int DSYear { get; set; }
        public int DSWorkingdays { get; set; }
        public DateTime DSEnteredDate { get; set; }
        public string venSupplier { get; set; }
        public string venDSMonth { get; set; }
        public int venDSYear { get; set; }
        public int venDSWorkingDays { get; set; }
        public DateTime venModifiedDate { get; set; }
        public int venModifiedBy { get; set; }
        public int DApprovedBy { get; set; }
        public string DApprovedStatus { get; set; }
        public string UpdatedStatus { get; set; }
        public string DeliveryScheduleType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }



        public virtual POMain POMain { get; set; }
        public virtual ICollection<DeliveryScheduleDetail> DeliveryScheduleDetails { get; set; }
       
        
    }
}
