using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Marked.Pages.Items
{
    [BindProperties]
    public class DeleteConfirmationModel : PageModel
    {
        private IItemRepo _repo; 
        public DeleteConfirmationModel(IItemRepo repo)
        {
            _repo = repo;
        }

        public int ID {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string NutritionalContent { get; set; }
        public string Imagepath { get; set; }
        
        public void OnGet(int id)
        {
            Item? item = _repo.GetItem(id);
            Console.WriteLine($"Found item: {item}");
        }

        public IActionResult OnPostItemToDelete(int id)
        {
            Console.WriteLine($"do you want to delete item? {_repo.GetItem(id).ToString()}");
            return RedirectToPage();
        }
    }
}
