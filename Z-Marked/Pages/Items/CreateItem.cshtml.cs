using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Lib.Model;
using Z_Marked.Model;
using Z_Marked.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Z_Marked.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly IItemSource _itemRepo;

        public IndexModel(IItemSource repo)
        {
            _itemRepo = repo;

        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]

        public double Price { get; set; }
        [BindProperty]
        public string Category { get; set; }
        [BindProperty]
        public string? Description { get; set; }
        [BindProperty]
        public string? NutritionalContent { get; set; }
        [BindProperty]
        public string? Picture { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }
        [BindProperty]
        public List<ItemCategory.Category> Categories { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ImageFile.Length > 0)
            {
                string folderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory + "\\wwwroot\\", "Uploads"));
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                Picture = ImageFile.FileName;
                using (var fileStream = new FileStream(Path.Combine(folderPath, ImageFile.FileName), FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);

                }
            }
            var Photo = $"/Uploads/{Picture}";

            var food = new Item(Id, Name, Price, Description, Category, NutritionalContent, Photo);

             _itemRepo.AddItem(food);
            return RedirectToPage("/Index");
        }

        public void OnGet()
        {
            Categories = Enum.GetValues<ItemCategory.Category>().ToList();

        }
    }
}
