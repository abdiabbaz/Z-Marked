using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
using Z_Marked.Pages.services;
using Z_Marked.Services;

namespace Z_Marked.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IItemRepo _itemRepo;
        private readonly Order _order;


        [BindProperty]
        public IUserSource Repo { get; set; }
        [BindProperty]
        public List<Item> Items { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IUserSource repo, IItemRepo itemRepo, Order order)
        {
            _logger = logger;
            Repo = repo;
            _itemRepo = itemRepo;
            _order = order; 
        }

        public void AddItemToCart(Item item)
        {
            Items.Add(item);
        }

        public IActionResult OnPost(int itemId)
        {
            var item = _itemRepo.GetItem(itemId);

            AddItemToCart(item);

            return RedirectToPage();
        }

        public IActionResult OnPostGoTillCart() 
        {
            return RedirectToPage("OrderFiles/OrderPages");

        }

        public void OnGet()
        {
            Items = _itemRepo.GetItems();
        }
    }
}