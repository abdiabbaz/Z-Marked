using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
using Z_Marked.Services;


namespace Z_Marked.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IItemSource _itemRepo;
        private readonly Order _order;



        //[BindProperty] - Problemer med denne
        public IUserSource Repo;
        public List<Item> Items { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IUserSource repo, IItemSource itemRepo, Order order)
        {
            _logger = logger;
            Repo = repo;
            _itemRepo = itemRepo;
            _order = order;
        }

        public IActionResult OnPost(int itemId, int quantity)
        {
            Item item = _itemRepo.GetItem(itemId);
            _order.AddItemsToDic(item, quantity);
            return RedirectToPage();
        }

        public IActionResult OnPostGoTillCart()
        {
            return RedirectToPage("OrderFiles/OrderPage");

        }

        public IActionResult OnPostSletItem(int ItemID)
        {
            var item = _itemRepo.GetItem(ItemID);
            _itemRepo.Delete(item);
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
            Items = _itemRepo.GetItems();
        }
    }
}