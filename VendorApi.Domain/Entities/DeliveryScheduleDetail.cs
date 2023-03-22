using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class DeliveryScheduleDetail
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryScheduleDetailId { get; set; }
        public int DeliveryScheduleMainId { get; set; }
        public string MaterialDescription { get; set; }
        public string SAPCode { get; set; }
        public int Week1 { get; set; }
        public int Week2 { get; set; }
        public int Week3 { get; set; }
        public int Week4 { get; set; }
        public int Total { get; set; }
        public int TentativeMonth1 { get; set; }
        public int TentativeMonth2 { get; set; }
        public string venMaterialDescription { get; set; }
        public int venSAPCode { get; set; }
        public int vendorWeek1 { get; set; }
        public int vendorWeek2 { get; set; }
        public int vendorWeek3 { get; set; }
        public int vendortotal { get; set; }
        public int venTentativeMonth1 { get; set; }
        public int venTentativeMonth2 { get; set; }
        public int DailyDeliveryQty { get; set; }
        public int DailyReceivedQty { get; set; }
        public int Gap { get; set; }
        public int CarryForward { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Unit { get; set; }
        public string DeliveryScheduleType { get; set; }
        public DateTime DeliveryScheduleDate { get; set; }



        public virtual DeliveryScheduleMain DeliveryScheduleMain { get; set; }
       
    }
}
