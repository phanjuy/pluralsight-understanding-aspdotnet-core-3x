using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobomanticsRazorPages.Models;
using GlobomanticsRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlobomanticsRazorPages.Pages
{
    public class ProposalListModel : PageModel
    {
        private readonly IProposalService proposalService;

        public IEnumerable<ProposalModel> Proposals { get; private set; }

        public ProposalListModel(IProposalService proposalService)
        {
            this.proposalService = proposalService;
        }

        public async Task OnGet(int conferenceId)
        {
            Proposals = await proposalService.GetAll(conferenceId);
            ViewData["ConferenceId"] = conferenceId;
        }

        public async Task<IActionResult> OnGetApprove(int proposalId, int conferenceId)
        {
            await proposalService.Approve(proposalId);
            return RedirectToPage("ProposalList", new { conferenceId = conferenceId });
        }
    }
}