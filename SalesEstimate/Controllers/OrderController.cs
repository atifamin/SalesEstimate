using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesEstimate.Data;
using SalesEstimate.Interface;
using SalesEstimate.Models;
using SalesEstimate.ViewModels;
using System.Threading.Tasks;

namespace SalesEstimate.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILookupRepository _lookupRepository;
        private readonly IConfiguration _configuration;

        public OrderController(ILookupRepository lookupRepository, ApplicationDbContext context, IConfiguration configuration)
        {
            _lookupRepository = lookupRepository;
            _context = context;
            _configuration = configuration;
        }
        // GET: Order/Create
        public async Task<IActionResult> Create()
        {
            var states = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.State);
            ViewBag.States = states;
            ViewBag.PageTitle = "Create Order";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    ParentOrderId = model.ParentOrderId,
                    RevisionNumber = model.RevisionNumber,
                    OrderDate = model.OrderDate,
                    RequiredDate = model.RequiredDate,
                    ContactName = model.ContactName,
                    CompanyName = model.CompanyName,
                    JobSiteContactName = model.JobSiteContactName,
                    JobSiteName = model.JobSiteName,
                    OrderType = model.OrderType,
                    CustomerPurchaseOrder = model.CustomerPurchaseOrder,
                    ContactPhone = model.ContactPhone,
                    ContactFax = model.ContactFax,
                    ContactEmail = model.ContactEmail,
                    IsBuyAmericaActProject = model.IsBuyAmericaActProject,
                    IsActivatePriceCalculation = model.IsActivatePriceCalculation,
                    IsPurchaseOrderQuoted = model.IsPurchaseOrderQuoted,
                    ProjectTotalValue = model.ProjectTotalValue,
                    QuoteNumber = model.QuoteNumber,
                    StreetAddress = model.StreetAddress,
                    ShipToAddress = model.ShipToAddress,
                    City = model.City,
                    LookupStateId = model.LookupStateId,
                    ZipCode = model.ZipCode,
                    Contractor = model.Contractor,
                    JobSiteContactPhone = model.JobSiteContactPhone,
                    AdditionalShippingInstructions = model.AdditionalShippingInstructions,
                    Standard = model.Standard,
                    Fastlane = model.Fastlane,
                    Express = model.Express,
                    Turbo = model.Turbo,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index),"Order");
            }
            ViewBag.PageTitle = "Create Order";
            return View(model);
        }

        // GET: Load the form to create order details
        public async Task<IActionResult> CreateOrderDetail(int orderLine)
        {
            await LoadLookupData();

            var model = new OrderDetailsViewModel
            {
                OrderLine = orderLine
            };

            return PartialView("_OrderDetails", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailsViewModel model,IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var orderDetail = new OrderDetail
                {
                    OrderLine = model.OrderLine,
                    FrameQty = model.FrameQty,
                    EstimatedSubTotal = model.EstimatedSubTotal,
                    AdditionalCharges = model.AdditionalCharges,
                    OtherCharges = model.OtherCharges,
                    EstimatedFreight = model.EstimatedFreight,
                    EstimatedTotal = model.EstimatedTotal,
                    ElevationDrawing = model.ElevationDrawing,
                    WidthFeet = model.WidthFeet,
                    WidthInches = model.WidthInches,
                    HeightFeet = model.HeightFeet,
                    HeightInches = model.HeightInches,
                    UnequalPairWidthFeet = model.UnequalPairWidthFeet,
                    UnequalPairWidthInches = model.UnequalPairWidthInches,
                    JambDepth = model.JambDepth,
                    HingeJamb = model.HingeJamb,
                    StrikeJamb = model.StrikeJamb,
                    Head = model.Head,
                    QTY = model.QTY,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = model.ModifiedBy,
                    ModifiedDate = model.ModifiedDate,
                    LookupTypeId = model.LookupTypeId,
                    LookupXifPairId = model.LookupXifPairId,
                    LookupOtherThanDoorId = model.LookupOtherThanDoorId,
                    LookupHandingId = model.LookupHandingId,
                    LookupSteelMaterialId = model.LookupSteelMaterialId,
                    LookupFireLabelId = model.LookupFireLabelId,
                    LookupSeriesId = model.LookupSeriesId,
                    LookupProfileId = model.LookupProfileId,
                    LookupProfileOptionId = model.LookupProfileOptionId,
                    LookupReturnId = model.LookupReturnId,
                    LookupGaugeId = model.LookupGaugeId,
                    LookupAssemblyId = model.LookupAssemblyId,
                    LookupAnchorsId = model.LookupAnchorsId,
                    LookupAdditionalAnchorsId = model.LookupAdditionalAnchorsId,
                    LookupHingesId = model.LookupHingesId,
                    LookupAdditionaloptionOnHingeId = model.LookupAdditionaloptionOnHingeId,
                    LookupHardwareLocationId = model.LookupHardwareLocationId,
                    LookupHeadPrepId = model.LookupHeadPrepId,
                    LookupStrikeId = model.LookupStrikeId,
                    LookupAdditionalStrikeId = model.LookupAdditionalStrikeId,
                    LookupCloserId = model.LookupCloserId,
                    LookupFinishId = model.LookupFinishId,
                    LookupOptions1Id = model.LookupOptions1Id,
                    LookupOptions2Id = model.LookupOptions2Id,
                    LookupOptions3Id = model.LookupOptions3Id
                };

                _context.OrderDetails.Add(orderDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            await LoadLookupData();
            return PartialView("_OrderDetails", model);
        }

        private async Task LoadLookupData()
        {

            ViewBag.XifPair = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.XifPair);
            ViewBag.OtherThan1or3 = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.OtherThan1or3);
            ViewBag.Types = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Types);
            ViewBag.Handing = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Handing);
            ViewBag.SteelMaterial = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.SteelMaterial);
            ViewBag.FireLabel = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.FireLabel);
            ViewBag.Series = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Series);
            ViewBag.Profile = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Profile);
            ViewBag.ProfileOption = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.ProfileOption);
            ViewBag.Return = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Return);
            ViewBag.Gauge = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Gauge);
            ViewBag.Assembly = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Assembly);
            ViewBag.Anchors = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Anchors);
            ViewBag.AdditionalAnchors = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.AdditionalAnchors);
            ViewBag.Hinges = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Hinges);
            ViewBag.AdditionalOptionOnHinge = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.AdditionalOptionOnHinge);
            ViewBag.HardwareLocation = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.HardwareLocation);
            ViewBag.HeadPrep = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.HeadPrep);
            ViewBag.Strike = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Strike);
            ViewBag.AdditionalStrike = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.AdditionalStrike);
            ViewBag.Closers = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Closers);
            ViewBag.Finish = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Finish);
            ViewBag.Options1 = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Options1);
            ViewBag.Options2 = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Options2);
            ViewBag.Options3 = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Options3);
        }

        public async Task<IActionResult> Index()
        {
            var states = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Types);
            ViewBag.PageTitle = "Order";
            return View(states);
        }
    }
}
