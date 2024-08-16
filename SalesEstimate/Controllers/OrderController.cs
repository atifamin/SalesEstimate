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
                    Standard = model.Standard,
                    Fastlane = model.Fastlane,
                    Express = model.Express,
                    Turbo = model.Turbo,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            var states = await _lookupRepository.LookupSelectList(LookupTypes.LookupType.Types);
            return View(states);
        }
    }
}
