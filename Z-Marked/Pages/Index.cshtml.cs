using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Lib.Model;
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

        public List<ItemCategory.Category> Categories { get; set; }

        public double Total {  get; set; }  

        public Dictionary<Item, int> ItemsPerPage { get; set; } 
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

        public IActionResult OnPostReset()
        {
            Items = _itemRepo.GetItems();
            Categories = Categories = Enum.GetValues<ItemCategory.Category>().ToList();
            return RedirectToPage(); 
        }

        public void OnPostSort(string category)
        {

            if (string.IsNullOrEmpty(category))
            {
                Items = _itemRepo.GetItems();
            }
            else
            {
                Items = _itemRepo.GetItems().Where(item => item.Category == category).ToList();
                ItemsPerPage = _order.GetItemsDictionary();   
            }
            Categories = Enum.GetValues<ItemCategory.Category>().ToList();
        }

        public void OnGet()
        {
            Items = _itemRepo.GetItems();
            if (Categories == null)
            {
                Categories = new List<ItemCategory.Category>();
            }
            Categories = Categories = Enum.GetValues<ItemCategory.Category>().ToList();

            ItemsPerPage = _order.GetItemsDictionary();

            Total = _order.SumOfAllItemsDic();

        }
    }
}