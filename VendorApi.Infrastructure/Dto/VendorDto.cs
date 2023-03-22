
namespace VendorApi.Infrastructure.Dto
{
    public class VendorDto
    {
		public int VendorId { get; set; }
		public string SAPVendorCode { get; set; }
		public string SAPVendorName { get; set; }
		public int LoginId { get; set; }
		public string VendorContactPerson { get; set; }
		public string EmailId { get; set; }
		public string ContactNumber { get; set; }
		public string MobileNumber { get; set; }
		public int Plantcode { get; set; }
		public string ProvidePortalAccess { get; set; }
		public int status { get; set; }
		public int Disablestatus { get; set; }
		public int StatementofAccount { get; set; }
		public int showPrices { get; set; }
		public string EnteredBy { get; set; }
		public string EnteredDate { get; set; }
		public string ModifiedBy { get; set; }
		public string ModifiedDate { get; set; }
		public string PlantName { get; set; }
		public string Fax { get; set; }
		public string city { get; set; }
		public string PostalCode { get; set; }
		public string Region { get; set; }
		public string Address { get; set; }
		public string AddressNumber { get; set; }
		public int VendorStatus { get; set; }
		public string Password { get; set; }
		public string CountryKey { get; set; }
		public string District { get; set; }
		public string POBox { get; set; }
		public string HouseNo { get; set; }
	}
}
