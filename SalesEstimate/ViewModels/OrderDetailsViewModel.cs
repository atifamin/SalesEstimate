using System.ComponentModel.DataAnnotations;

namespace SalesEstimate.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Order Line")]
        public int? OrderLine { get; set; }

        [Display(Name = "Frame Quantity")]
        public int? FrameQty { get; set; }

        [Display(Name = "Estimated Total")]
        public int? EstimatedSubTotal { get; set; }

        [Display(Name = "Additional Charges If Needed")]
        public int? AdditionalCharges { get; set; }

        [Display(Name = "Others Charges")]
        public int? OtherCharges { get; set; }

        [Display(Name = "Estimated Freight")]
        public int? EstimatedFreight { get; set; }

        [Display(Name = "Estimated Total")]
        public int? EstimatedTotal { get; set; }

        [Display(Name = "Elevation Drawing If Not Three-Sided Frame")]
        public string? ElevationDrawing { get; set; }

        [Display(Name = "Door Opening Sizes Width Feet")]
        public int WidthFeet { get; set; }

        [Display(Name = "Door Opening Sizes Width Inches")]
        public decimal WidthInches { get; set; }

        [Display(Name = "Door Opening Sizes Height Feet")]
        public int HeightFeet { get; set; }

        [Display(Name = "Door Opening Sizes Height Inches")]
        public decimal HeightInches { get; set; }

        [Display(Name = "If Unequal Pair Width Feet")]
        public int UnequalPairWidthFeet { get; set; }

        [Display(Name = "If Unequal Pair Width Inches")]
        public decimal UnequalPairWidthInches { get; set; }

        [Display(Name = "Jamb Depth")]
        public decimal JambDepth { get; set; }

        [Display(Name = "Other than 2 Face On Hinge Jamb")]
        public decimal HingeJamb { get; set; }

        [Display(Name = "Other than 2 Face On Strike/Hinge Jamb")]
        public decimal StrikeJamb { get; set; }

        [Display(Name = "Other than 2 Face Head")]
        public decimal Head { get; set; }

        [Display(Name = "Hinges Quantity")]
        public int QTY { get; set; }

        [MaxLength(450)]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        [MaxLength(450)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Foreign key IDs for LookupValues
        public int? LookupTypeId { get; set; }
        public int? LookupXifPairId { get; set; }
        public int? LookupOtherThanDoorId { get; set; }
        public int? LookupHandingId { get; set; }
        public int? LookupSteelMaterialId { get; set; }
        public int? LookupFireLabelId { get; set; }
        public int? LookupSeriesId { get; set; }
        public int? LookupProfileId { get; set; }
        public int? LookupProfileOptionId { get; set; }
        public int? LookupReturnId { get; set; }
        public int? LookupGaugeId { get; set; }
        public int? LookupAssemblyId { get; set; }
        public int? LookupAnchorsId { get; set; }
        public int? LookupAdditionalAnchorsId { get; set; }
        public int? LookupHingesId { get; set; }
        public int? LookupAdditionaloptionOnHingeId { get; set; }
        public int? LookupHardwareLocationId { get; set; }
        public int? LookupHeadPrepId { get; set; }
        public int? LookupStrikeId { get; set; }
        public int? LookupAdditionalStrikeId { get; set; }
        public int? LookupCloserId { get; set; }
        public int? LookupFinishId { get; set; }
        public int? LookupOptions1Id { get; set; }
        public int? LookupOptions2Id { get; set; }
        public int? LookupOptions3Id { get; set; }
    }
}
