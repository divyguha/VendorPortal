using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class CircularDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CircularDetailId { get; set; }
		public string MaterialCode { get; set; }
		public string MaterialDescription { get; set; }
		public int VendorId { get; set; }
		public int CricularId { get; set; }
		public int Status { get; set; }
		public int Viewed { get; set; }



		public virtual Vendor Vendor { get; set; }
		public virtual Circular Circular { get; set; }
	}
}
