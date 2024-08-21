using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesEstimate.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int? ParentOrderId { get; set; }
        public int? RevisionNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobSiteContactName { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobSiteName { get; set; }

        [MaxLength(100)]
        public string QuotationRequest { get; set; }

        [MaxLength(50)]
        public string? OrderType { get; set; }

        [MaxLength(100)]
        public string? CustomerPurchaseOrder { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? ContactPhone { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? ContactFax { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? ContactEmail { get; set; }

        public bool? IsBuyAmericaActProject { get; set; }
        public bool? IsActivatePriceCalculation { get; set; }
        public bool? IsPurchaseOrderQuoted { get; set; }
        public decimal? ProjectTotalValue { get; set; }

        [MaxLength(50)]
        public string? QuoteNumber { get; set; }

        [MaxLength(200)]
        public string? StreetAddress { get; set; }

        [MaxLength(200)]
        public string? ShipToAddress { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [ForeignKey("LookupValue")]
        public int? LookupStateId { get; set; }
        public LookupValue? LookupState { get; set; }

        [MaxLength(10)]
        public string? ZipCode { get; set; }

        [MaxLength(100)]
        public string? Contractor { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? JobSiteContactPhone { get; set; }
        [MaxLength(255)]
        public string? AdditionalShippingInstructions { get; set; }

        public decimal? Standard { get; set; }
        public decimal? Fastlane { get; set; }
        public decimal? Express { get; set; }
        public decimal? Turbo { get; set; }

        [MaxLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(450)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
