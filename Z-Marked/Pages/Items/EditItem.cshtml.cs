using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Lib.Model;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Marked.Pages.Items
{
    [BindProperties]
    public class EditItemModel : PageModel
    {
        private readonly IItemSource _repo;
        private Item item; 
        public EditItemModel(IItemSource repo
            )
        {
            _repo = repo;
        }

        


        
        public int Id { get; set; }
        
        public string? Name { get; set; }
        

        public double Price { get; set; }
        
        public string Category { get; set; }
        
        public string? Description { get; set; }
        
        public string? NutritionalContent { get; set; }
        
        public string? Picture { get; set; }
        
        

        public void OnGet(int id)
        {
            Id = id;
            item = _repo.GetItem(id); 
            Name = item.Name;
            Price = item.Price;
            Category = item.Category;
            Description = item.Description;
            NutritionalContent = item.NutritionalContent;
            Picture = item.ImagePath;
            
        }

        public IActionResult OnPost(int id) {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            item = _repo.GetItem(id);
            item.Name = Name;
            item.Price = Price;
            item.Category = Category;
            item.Description = Description;
            item.NutritionalContent = NutritionalContent;
            item.ImagePath = Picture; 
            _repo.Update(id, item);
            return Redirect("~/");
            
        }
    }
}
