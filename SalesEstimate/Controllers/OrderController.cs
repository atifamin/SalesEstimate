using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.LookupState)
                .Include(o => o.OrderDetails)
                .ToListAsync();

            ViewBag.PageTitle = "All Orders";
            return View(orders);
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
        public async Task<IActionResult> Create(Order model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    ParentOrderId = model.ParentOrderId,
                    RevisionNumber = model.RevisionNumber,
                    QuotationRequest = model.QuotationRequest,
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

                return RedirectToAction(nameof(Index), "Order");
            }
            ViewBag.PageTitle = "Create Order";
            return View(model);
        }

        // GET: Load the form to create Add details
        [HttpGet]
        public async Task<IActionResult> AddOrderDetail(int orderLine)
        {
            await LoadLookupData();

            
            var model = new OrderDetail { OrderLine = orderLine };

           // ViewBag.LineNo = orderLine + 1;

            // Return the new OrderDetail as a partial view
            return PartialView("_OrderDetails", model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateOrderDetail(Order order)
        //{
        //    var existingOrder = await _context.Orders
        //        .Include(o => o.OrderDetails)
        //        .FirstOrDefaultAsync(o => o.Id == order.Id);

        //    if (existingOrder == null)
        //    {
        //        Create a new order if it doesn't exist
        //        _context.Orders.Add(order);
        //        await _context.SaveChangesAsync();

        //        foreach (var detail in order.OrderDetails)
        //        {
        //            detail.OrderId = order.Id;
        //            _context.OrderDetails.Add(detail);
        //        }
        //    }
        //    else
        //    {
        //        _context.Entry(existingOrder).CurrentValues.SetValues(order);

        //        foreach (var detail in order.OrderDetails)
        //        {
        //            var existingDetail = existingOrder.OrderDetails.FirstOrDefault(od => od.OrderLine == detail.OrderLine);
        //            if (existingDetail != null)
        //            {
        //                _context.Entry(existingDetail).CurrentValues.SetValues(detail);
        //            }
        //            else
        //            {
        //                detail.OrderId = order.Id;
        //                _context.OrderDetails.Add(detail);
        //            }
        //        }
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrderDetail(Order order)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                //int orderLineCounter = 0;
                foreach (var detail in order.OrderDetails)
                {
                    detail.OrderId = order.Id;
                    //detail.OrderLine = ++orderLineCounter;
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }
            await LoadLookupData();
            ViewBag.States = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.State);
            ViewBag.PageTitle = "Edit Order";
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrderDetail(Order order)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                return NotFound("Order not found.");
            }

            // Update the general information of the order
            existingOrder.QuotationRequest = order.QuotationRequest;
            existingOrder.OrderType = order.OrderType;
            existingOrder.CompanyName = order.CompanyName;
            existingOrder.ContactName = order.ContactName;
            existingOrder.ContactPhone = order.ContactPhone;
            existingOrder.ContactEmail = order.ContactEmail;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.RequiredDate = order.RequiredDate;
            existingOrder.IsActivatePriceCalculation = order.IsActivatePriceCalculation;
            existingOrder.IsBuyAmericaActProject = order.IsBuyAmericaActProject;
            existingOrder.IsPurchaseOrderQuoted = order.IsPurchaseOrderQuoted;
            existingOrder.StreetAddress = order.StreetAddress;
            existingOrder.City = order.City;
            existingOrder.ZipCode = order.ZipCode;
            existingOrder.LookupStateId = order.LookupStateId;
            existingOrder.OrderDetails = order.OrderDetails;


            // Update existing order details or add new ones
            foreach (var detail in existingOrder.OrderDetails)
            {
                var existingDetail = existingOrder.OrderDetails.FirstOrDefault(d => d.OrderLine == detail.OrderLine);
                if (existingDetail != null)
                {
                    // Update existing order detail
                    existingDetail.FrameQty = detail.FrameQty;
                    existingDetail.EstimatedSubTotal = detail.EstimatedSubTotal;
                    existingDetail.AdditionalCharges = detail.AdditionalCharges;
                    existingDetail.OtherCharges = detail.OtherCharges;
                    existingDetail.EstimatedFreight = detail.EstimatedFreight;
                    existingDetail.EstimatedTotal = detail.EstimatedTotal;
                    existingDetail.LookupTypeId = detail.LookupTypeId;
                    existingDetail.LookupXifPairId = detail.LookupXifPairId;
                    existingDetail.LookupOtherThanDoorId = detail.LookupOtherThanDoorId;
                    existingDetail.ElevationDrawing = detail.ElevationDrawing;
                    existingDetail.WidthFeet = detail.WidthFeet;
                    existingDetail.WidthInches = detail.WidthInches;
                    existingDetail.HeightFeet = detail.HeightFeet;
                    existingDetail.HeightInches = detail.HeightInches;
                    existingDetail.UnequalPairWidthFeet = detail.UnequalPairWidthFeet;
                    existingDetail.UnequalPairWidthInches = detail.UnequalPairWidthInches;
                    existingDetail.LookupHandingId = detail.LookupHandingId;
                    existingDetail.LookupSteelMaterialId = detail.LookupSteelMaterialId;
                    existingDetail.LookupFireLabelId = detail.LookupFireLabelId;
                    existingDetail.LookupSeriesId = detail.LookupSeriesId;
                    existingDetail.LookupProfileId = detail.LookupProfileId;
                    existingDetail.LookupProfileOptionId = detail.LookupProfileOptionId;
                    existingDetail.LookupReturnId = detail.LookupReturnId;
                    existingDetail.LookupGaugeId = detail.LookupGaugeId;
                    existingDetail.JambDepth = detail.JambDepth;
                    existingDetail.HingeJamb = detail.HingeJamb;
                    existingDetail.StrikeJamb = detail.StrikeJamb;
                    existingDetail.Head = detail.Head;
                    existingDetail.LookupAssemblyId = detail.LookupAssemblyId;
                    existingDetail.LookupAnchorsId = detail.LookupAnchorsId;
                    existingDetail.LookupAdditionalAnchorsId = detail.LookupAdditionalAnchorsId;
                    existingDetail.QTY = detail.QTY;
                    existingDetail.LookupHingesId = detail.LookupHingesId;
                    existingDetail.LookupAdditionaloptionOnHingeId = detail.LookupAdditionaloptionOnHingeId;
                    existingDetail.LookupHardwareLocationId = detail.LookupHardwareLocationId;
                    existingDetail.LookupHeadPrepId = detail.LookupHeadPrepId;
                    existingDetail.LookupStrikeId = detail.LookupStrikeId;
                    existingDetail.LookupAdditionalStrikeId = detail.LookupAdditionalStrikeId;
                    existingDetail.LookupCloserId = detail.LookupCloserId;
                    existingDetail.LookupFinishId = detail.LookupFinishId;
                    existingDetail.LookupOptions1Id = detail.LookupOptions1Id;
                    existingDetail.LookupOptions2Id = detail.LookupOptions2Id;
                    existingDetail.LookupOptions3Id = detail.LookupOptions3Id;
                    existingDetail.OtherCharges = detail.OtherCharges;
                    existingDetail.EstimatedTotal = detail.EstimatedTotal;
                    existingDetail.ModifiedBy = "CurrentUser";
                    existingDetail.ModifiedDate = DateTime.UtcNow;
                }
                else
                {
                    // Add new order detail
                    detail.OrderId = existingOrder.Id;
                    existingOrder.OrderDetails.Add(detail);
                }
            }

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.Id))
                {
                    return NotFound("Order not found.");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
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

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var order = _context.Orders.Include(x => x.OrderDetails).Where(o => o.Id == id).FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
    }
}
