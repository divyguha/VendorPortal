using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    public class Circular
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CircularId { get; set; }
        public DateTime CircularDate { get; set; }
        public string CircularSubject { get; set; }
        public string CircularMessage { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }


        public virtual ICollection<CircularDetail> CircularDetails { get; set; }

      
    }
}
