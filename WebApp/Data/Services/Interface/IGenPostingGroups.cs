using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Dto;

namespace WebApp.Data.Services.Interface
{
    public interface IGenPostingGroups
    {
        public Task<bool> CreateGenProdPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto);

        public Task<bool> CreateGenBusPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto);

        public Task<List<GenPostingGroups.GenPostingGroup>> GetGenProdPostingGroupsAsync(string orgid, string coyid);

        public Task<List<GenPostingGroups.GenPostingGroup>> GetGenBusPostingGroupsAsync(string orgid, string coyid);

        public Task<GenPostingGroups.GenPostingGroup> GetGenProdPostingGroupAsync(string orgid, string coyid, string groupid);

        public Task<GenPostingGroups.GenPostingGroup> GetGenBusPostingGroupAsync(string orgid, string coyid, string groupid);

        public Task<bool> UpdateGenProdPostingGroupAsync(GenPostingGroups.GenPostingGroup dto);

        public Task<bool> UpdateGenBusPostingGroupAsync(GenPostingGroups.GenPostingGroup dto);

    }
}
