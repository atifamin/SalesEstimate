using SalesEstimate.Models;

namespace SalesEstimate.ViewModels
{
    public class OrderViewModel
    {

        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public int OrderLine { get; set; }

    }
}
