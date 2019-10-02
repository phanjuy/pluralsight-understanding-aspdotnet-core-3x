using System.Threading.Tasks;
using GlobomanticsRazorPages.Models;
using GlobomanticsRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlobomanticsRazorPages.Pages
{
    public class AddProposalModel : PageModel
    {
        private readonly IProposalService proposalService;

        [BindProperty]
        public ProposalModel Proposal { get; set; }

        public AddProposalModel(IProposalService proposalService)
        {
            this.proposalService = proposalService;
        }

        public async Task<IActionResult> OnPost(int conferenceId)
        {
            Proposal.ConferenceId = conferenceId;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await proposalService.Add(Proposal);

            return RedirectToPage("ProposalList", new { conferenceId = conferenceId });
        }
    }
}