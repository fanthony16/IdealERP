using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Models.Dto;
using WebApp.Utilities;

namespace WebApp.Data.Services.Implementation
{
    public class GenPostingGroupsvr : IGenPostingGroups
    {

        private readonly APIGateway _apigateway;
        public GenPostingGroupsvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }

        public async Task<bool> CreateGenBusPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<GenPostingGroups.CreateGenPostingGroup>(dto, "GenPostingGroup/business/New");

            try
            {
                var createdpostinggroup = JsonSerializer.Deserialize<VATPostingGroups.CreateVATPostingGroup>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateGenProdPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<GenPostingGroups.CreateGenPostingGroup>(dto, "GenPostingGroup/product/New");

            try
            {
                var createdpostinggroup = JsonSerializer.Deserialize<GenPostingGroups.CreateGenPostingGroup>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<GenPostingGroups.GenPostingGroup> GetGenBusPostingGroupAsync(string orgid, string coyid, string groupid)
        {
            var result = await _apigateway.ApiGetAsync($"GenPostingGroup/business/{orgid}/{coyid}/{groupid}");

            try
            {
                var businessvatgroup = JsonSerializer.Deserialize<GenPostingGroups.GenPostingGroup>(result);
                return businessvatgroup;
            }
            catch
            {
                return new GenPostingGroups.GenPostingGroup();
            }
        }

        public async Task<GenPostingGroups.GenPostingGroup> GetGenProdPostingGroupAsync(string orgid, string coyid, string groupid)
        {
            var result = await _apigateway.ApiGetAsync($"GenPostingGroup/product/{orgid}/{coyid}/{groupid}");

            try
            {
                var genproductgroup = JsonSerializer.Deserialize<GenPostingGroups.GenPostingGroup>(result);
                return genproductgroup;
            }
            catch
            {
                return new GenPostingGroups.GenPostingGroup();
            }
        }

        public async Task<List<GenPostingGroups.GenPostingGroup>> GetGenBusPostingGroupsAsync(string orgid, string coyid)
        {
            var result = await _apigateway.ApiGetAsync($"GenPostingGroup/business/{orgid}/{coyid}");

            try
            {
                var genbusinessgroups = JsonSerializer.Deserialize<List<GenPostingGroups.GenPostingGroup>>(result);
                return genbusinessgroups;
            }
            catch
            {
                return new List<GenPostingGroups.GenPostingGroup>();
            }
        }

       

        public async Task<List<GenPostingGroups.GenPostingGroup>> GetGenProdPostingGroupsAsync(string orgid, string coyid)
        {
            var result = await _apigateway.ApiGetAsync($"GenPostingGroup/product/{orgid}/{coyid}");

            try
            {
                var genproductgroups = JsonSerializer.Deserialize<List<GenPostingGroups.GenPostingGroup>>(result);
                return genproductgroups;
            }
            catch
            {
                return new List<GenPostingGroups.GenPostingGroup>();
            }
        }


        public async Task<bool> UpdateGenProdPostingGroupAsync(GenPostingGroups.GenPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<GenPostingGroups.GenPostingGroup>(dto, "GenPostingGroup/product/Edit");

            try
            {
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateGenBusPostingGroupAsync(GenPostingGroups.GenPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<GenPostingGroups.GenPostingGroup>(dto, "GenPostingGroup/business/Edit");

            try
            {
                //var vatbusinessgroup = JsonSerializer.Deserialize<VATPostingGroups.VATPostingGroup>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
