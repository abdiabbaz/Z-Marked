using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;

namespace Z_Marked.Pages.OrderFiles
{
    public class OrderPageModel : PageModel
    {
        private readonly Order _order;

        public OrderPageModel(Order order)
        {
            _order = order;
        }

        public double TotalAmount { get; set; }

        public int quantity { get; set; }
        public Dictionary<Item, int> ItemsPerPage { get; set; }

        public void OnGet()
        {
            ItemsPerPage = _order.GetItemsDictionary();
            TotalAmount = _order.SumOfAllItemsDic();
        }

        public IActionResult OnPost(int itemId, int quantity)
        {
            Item item = _order.GetItemById(itemId)!;
            _order.AddItemsToDic(item, quantity);
            return RedirectToPage();
        }

        public IActionResult OnPostSletKurv(int id, int random)
        {
            Item item = _order.GetItemById(id)!;
            if (item != null)
            {
                _order.RemoveItem(item,random);

            }
            return RedirectToPage();
        }

    }
}

    

