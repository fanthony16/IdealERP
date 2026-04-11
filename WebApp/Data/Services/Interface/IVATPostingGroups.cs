using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using WebApp.ViewModels;

namespace WebApp.Data.Services.Interface
{
    public interface IVATPostingGroups
    {
        public Task<bool> CreateVATProdPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto);

        public Task<bool> UpdateVATProdPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto);

        public Task<bool> CreateVATBusPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto);

        public Task<bool> UpdateVATBusPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto);

        public Task<List<VATPostingGroups.VATPostingGroup>> GetVATProdPostingGroupsAsync(string orgid, string coyid);

        public Task<List<VATPostingGroups.VATPostingGroup>> GetVATBusPostingGroupsAsync(string orgid, string coyid);

        public Task<VATPostingGroups.VATPostingGroup> GetVATProdPostingGroupsAsync(string orgid, string coyid, string id);

        public Task<VATPostingGroups.VATPostingGroup> GetVATBusPostingGroupsAsync(string orgid, string coyid, string id);

    }
}
