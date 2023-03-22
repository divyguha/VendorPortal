
using System;

namespace VendorApi.Infrastructure.Dto
{
    public class PODetailDto
    {
		public int PODetailId { get; set; }
		public int ItemNo { get; set; }
		public int POMainId { get; set; }
		public string MaterialCode { get; set; }
		public string MaterialDescription { get; set; }
		public int Qty { get; set; }
		public int Unit { get; set; }
		public int PricePerUnit { get; set; }
		public int GrossValue { get; set; }
		public string SAPCode { get; set; }	
		public string PONumber { get; set; }
		public string PlantCode { get; set; }
		public string PlantName { get; set; }
		public string TaxCode { get; set; }
		public int NetValue { get; set; }
		public int LockStatus { get; set; }
	}
}
