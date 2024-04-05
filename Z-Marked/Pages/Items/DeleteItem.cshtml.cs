using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Z_Marked.Pages.Items
{
    public class DeleteItemModel : PageModel
    {
        public DeleteItemModel() { }

        [BindProperty]
        public int ID { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() {
           
        }


    }
}
