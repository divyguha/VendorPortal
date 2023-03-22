
using System;
using System.Collections.Generic;

namespace VendorApi.Infrastructure.Dto
{
    public class POMainDto
    {
		public int POMainId { get; set; }
		public string SAPPONo { get; set; }
		public string PODate { get; set; }
		public int VendorId { get; set; }
		public string TINNo { get; set; }
		public string ECCNo { get; set; }
		public string PANNo { get; set; }
		public string SRVTaxNo { get; set; }
		public int POValue { get; set; }
		public string ValidFrom { get; set; }
		public string ValidTo { get; set; }
		public string TermsConditions { get; set; }
		public string ApprovedBy { get; set; }
		public int ApprovedStatus { get; set; }
		public int Currency { get; set; }
		public string VendorCode { get; set; }
		public string UnapprovedDate { get; set; }
		public string UnapprovedBy { get; set; }
		public string ApprovedDate { get; set; }
		public int ReleaseStatus { get; set; }
		public string POHeaderText { get; set; }
		public int POStatus { get; set; }
		public string Plant { get; set; }
		public string EnteredDate { get; set; }
		public string ModifiedDate { get; set; }

		public List<PODetailDto> PODetailDtos { get; set; }

	}
}
