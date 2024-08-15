using System.ComponentModel.DataAnnotations.Schema;

namespace SalesEstimate.Models
{
    public class LookupValue
    {
        public int Id { get; set; }

        [ForeignKey("LookupType")]
        public int? LookupTypeId { get; set; }
        public LookupType? LookupType { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string? CustomField1 { get; set; } 
        public string? CustomField2 { get; set; }
        public float? CustomField3 { get; set; }
        public float? CustomField4 { get; set; }
    }
}
