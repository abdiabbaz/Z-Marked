using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;

namespace Z_Marked.Pages.OrderFiles
{
    public class OrderPageModel : PageModel
    {
        private readonly Order _order;

        public OrderPageModel( Order order)
        {
            _order = order;
        }

        public double TotalAmount { get; set; }

        public Dictionary<Item,int> ItemsPerPage { get; set; }

        public void OnGet()
        {
            ItemsPerPage = _order.GetItemsDictionary();
            TotalAmount =_order.SumOfAllItemsDic();
        }


    }
}
