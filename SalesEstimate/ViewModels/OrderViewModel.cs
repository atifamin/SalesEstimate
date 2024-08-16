namespace SalesEstimate.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int? ParentOrderId { get; set; }
        public int? RevisionNumber { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string JobSiteContactName { get; set; }
        public string JobSiteName { get; set; }
        public string QuotationRequest { get; set; }
        public string? OrderType { get; set; }
        public string? CustomerPurchaseOrder { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactFax { get; set; }
        public string? ContactEmail { get; set; }
        public bool? IsBuyAmericaActProject { get; set; }
        public bool? IsActivatePriceCalculation { get; set; }
        public bool? IsPurchaseOrderQuoted { get; set; }
        public decimal? ProjectTotalValue { get; set; }
        public string? QuoteNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? ShipToAddress { get; set; }
        public string? City { get; set; }
        public int? LookupStateId { get; set; }
        public string? ZipCode { get; set; }
        public string? Contractor { get; set; }
        public string? JobSiteContactPhone { get; set; }
        public decimal? Standard { get; set; }
        public decimal? Fastlane { get; set; }
        public decimal? Express { get; set; }
        public decimal? Turbo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
