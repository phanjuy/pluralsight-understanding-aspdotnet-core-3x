using System.Threading.Tasks;
using GlobomanticsRazorPages.Models;
using GlobomanticsRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlobomanticsRazorPages.Pages
{
    public class AddConferenceModel : PageModel
    {
        private readonly IConferenceService conferenceService;

        [BindProperty]
        public ConferenceModel Conference { get; set; }

        public AddConferenceModel(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await conferenceService.Add(Conference);
            return RedirectToPage("/Index");
        }
    }
}