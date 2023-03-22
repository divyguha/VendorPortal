using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{

    /// <summary>
    /// Data inserted in to table 'Vendor' using SAP  
    /// </summary>
    public class Vendor 
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int VendorId { get; set; }
        public string SAPVendorCode { get; set; }
        public string SAPVendorName { get; set; }
        public string LoginId { get; set; }
        public string VendorContactPerson { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PlantCode { get; set; }
        public bool? ProvidePortalAccess { get; set; }
        public bool? Status { get; set; }
        public bool? Disablestatus { get; set; }
        public bool? StatementofAccount { get; set; }
        public bool? showPrices { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PlantName { get; set; }
        public string Fax { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string VendorStatus { get; set; }
        public string Password { get; set; }
        public string CountryKey { get; set; }
        public string District { get; set; }
        public string POBox { get; set; }
        public string HouseNo { get; set; }
        //public int CircularDetailId { get; set; }

        //public virtual ICollection<GRNDetail> GRNDetails { get; set; }
        public virtual ICollection<POMain> POMains { get; set; }
        public virtual ICollection<CircularDetail> CircularDetails { get; set; }
        //public virtual ICollection<DeliveryScheduleMain> DeliveryScheduleMain { get; set; }
    }
}

