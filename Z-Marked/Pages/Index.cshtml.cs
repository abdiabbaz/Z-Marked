using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
using Z_Marked.Services;


namespace Z_Marked.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IItemRepo _itemRepo;
        private readonly Order _order;



        //[BindProperty] - Problemer med denne
        public IUserSource Repo;
        public List<Item> Items { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IUserSource repo, IItemRepo itemRepo, Order order)
        {
            _logger = logger;
            Repo = repo;
            _itemRepo = itemRepo;
            _order = order;
        }

        public IActionResult OnPost(int itemId, int quantity)
        {
            Item item = _itemRepo.GetItem(itemId);
            for (int i = 0; i < quantity; i++)
            {
                AddItemToCart(item, i);
            }

            return RedirectToPage();
        }

        public void AddItemToCart(Item item, int i)
        {
            _order.AddItemsToDic(item,i);
        }


        public IActionResult OnPostGoTillCart()
        {
            return RedirectToPage("OrderFiles/OrderPage");

        }

        public void OnGet()
        {
            Items = _itemRepo.GetItems();
        }
    }
}