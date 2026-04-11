using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DTO;

namespace WebAPI.Model.Services.Interface
{
    public interface IGenPostingGroups
    {
        public Task<GenPostingGroups.GenPostingGroup> CreateGenProdPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto);

        public Task<GenPostingGroups.GenPostingGroup> CreateGenBusPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto);

        public Task<bool> UpdateGenProdPostingGroupsAsync(GenPostingGroups.GenPostingGroup dto);

        public Task<bool> UpdateGenBusPostingGroupsAsync(GenPostingGroups.GenPostingGroup dto);

        public Task<List<GenPostingGroups.GenPostingGroup>> GetGenProdPostingGroupsAsync(string orgid, string coyid);

        public Task<List<GenPostingGroups.GenPostingGroup>> GetGenBusPostingGroupsAsync(string orgid, string coyid);

        public Task<GenPostingGroups.GenPostingGroup> GetGenProdPostingGroupsAsync(string orgid, string coyid, string id);

        public Task<GenPostingGroups.GenPostingGroup> GetGenBusPostingGroupsAsync(string orgid, string coyid, string id);
    }
}
