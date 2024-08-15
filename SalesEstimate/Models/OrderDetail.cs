using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesEstimate.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Display(Name = "Frame Quantity")]
        public int FrameQty{ get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupTypeId { get; set; }
        public LookupValue? LookupType { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupXifPairId { get; set; }
        public LookupValue? LookupXifPair { get; set; }
        [ForeignKey("LookupValue")]
        public int?  LookupOtherThanDoorId { get; set; }
        public LookupValue? LookupOtherThanDoor { get; set; }
        [Display(Name = "Elevation Drawing If Not Three-Sided Frame")]
        public string? ElevationDrawing { get; set; }
        [Display(Name = "Door Opening Sizes Width Feet")]
        public int WidthFeet { get; set; }
        [Display(Name = "Door Opening Sizes Width Inches ")]
        public decimal WidthInches { get; set; }
        [Display(Name = "Door Opening Sizes Height Feet")]
        public int HeightFeet { get; set; }
        [Display(Name = "Door Opening Sizes Height Inches")]
        
        public decimal HeightInches { get; set; }
        [Display(Name = "If Unequal Pair InActive Leaf Nominal Width Feet")]
        public int UnequalPairWidthFeet { get; set; }
        [Display(Name = "If Unequal Pair InActive Leaf Nominal Width Inches")]
        public decimal UnequalPairWidthInches { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupHandingId { get; set; }
        public LookupValue? LookupHandingType { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupSteelMaterialId { get; set; }
        public LookupValue? LookupSteelMaterial { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupFireLabelId { get; set; }
        public LookupValue? LookupFireLabel { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupSeriesId { get; set; }
        public LookupValue? LookupSeries { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupProfileId { get; set; }
        public LookupValue? LookupProfile { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupProfileOptionId { get; set; }
        public LookupValue? LookupProfileOption { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupReturnId { get; set; }
        public LookupValue? LookupReturn { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupGaugeId { get; set; }
        public LookupValue? LookupGauge { get; set; }
        [Display(Name = "Jamb Depth")]
        public decimal JambDepth { get; set; }
        [Display(Name = "Other than 2 Face On Hinge Jamb")]
        public decimal HingeJamb { get; set; }
        [Display(Name = "Other than 2 Face On Strike/Hinge Jamb")]
        public decimal StrikeJamb { get; set; }
        [Display(Name = "Other than 2 Face Head")]
        public decimal Head { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupAssemblyId { get; set; }
        public LookupValue? LookupAssembly { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupAnchorsId { get; set; }
        public LookupValue? LookupAnchors { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupAdditionalAnchorsId { get; set; }
        public LookupValue? LookupAdditionalAnchors { get; set; }
        [Display(Name = "Hinges Quantity")]
        public int QTY { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupHingesId { get; set; }
        public LookupValue? LookupHinges { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupAdditionaloptionOnHingeId { get; set; }
        public LookupValue? LookupAdditionaloptionOnHinge { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupHardwareLocationId { get; set; }
        public LookupValue? LookupHardwareLocation { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupHeadPrepId { get; set; }
        public LookupValue? LookupHeadPrep { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupStrikeId { get; set; }
        public LookupValue? LookupStrike { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupAdditionalStrikeId { get; set; }
        public LookupValue? LookupAdditionalStrike { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupCloserId { get; set; }
        public LookupValue? LookupCloser { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupFinishId { get; set; }
        public LookupValue? LookupFinish { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupOptions1Id { get; set; }
        public LookupValue? LookupOptions1 { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupOptions2Id { get; set; }
        public LookupValue? LookupOptions2 { get; set; }
        [ForeignKey("LookupValue")]
        public int? LookupOptions3Id { get; set; }
        public LookupValue? LookupOptions3 { get; set; }
        [MaxLength(450)]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(450)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
