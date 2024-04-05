using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using Z_Marked.Services;

namespace Z_Marked.Pages.Items
{
    public class DeleteConfirmationModel : PageModel
    {
        private IItemRepo _repo; 
        public DeleteConfirmationModel(IItemRepo repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostItemToDelete(int id)
        {
            Console.WriteLine($"do you want to delete item? {_repo.GetItem(id).ToString()}");
            return RedirectToPage();
        }
    }
}
