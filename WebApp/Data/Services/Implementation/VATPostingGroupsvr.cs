using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Models.Dto;
using WebApp.Utilities;
using WebApp.ViewModels;

namespace WebApp.Data.Services.Implementation
{
    public class VATPostingGroupsvr : IVATPostingGroups
    {
        private readonly APIGateway _apigateway;
        public VATPostingGroupsvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }
        public async Task<bool> CreateVATBusPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<VATPostingGroups.CreateVATPostingGroup>(dto, "VATPostingGroup/business/New");

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

        public async Task<bool> CreateVATProdPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto)
        {
            var result = await _apigateway.ApiPostAsync<VATPostingGroups.CreateVATPostingGroup>(dto, "VATPostingGroup/product/New");

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


        public async Task<List<VATPostingGroups.VATPostingGroup>> GetVATBusPostingGroupsAsync(string orgid, string coyid)
        {

            var result = await _apigateway.ApiGetAsync($"VATPostingGroup/business/{orgid}/{coyid}");

            try
            {
                var businessvatgroups = JsonSerializer.Deserialize<List<VATPostingGroups.VATPostingGroup>>(result);
                return businessvatgroups;
            }
            catch
            {
                return new List<VATPostingGroups.VATPostingGroup>();
            }

        }

        public async Task<List<VATPostingGroups.VATPostingGroup>> GetVATProdPostingGroupsAsync(string orgid, string coyid)
        {

            var result = await _apigateway.ApiGetAsync($"VATPostingGroup/product/{orgid}/{coyid}");

            try
            {
                var productvatgroups = JsonSerializer.Deserialize<List<VATPostingGroups.VATPostingGroup>>(result);
                return productvatgroups;
            }
            catch
            {
                return new List<VATPostingGroups.VATPostingGroup>();
            }

        }


        public async Task<VATPostingGroups.VATPostingGroup> GetVATBusPostingGroupsAsync(string orgid, string coyid, string groupid)
        {

            var result = await _apigateway.ApiGetAsync($"VATPostingGroup/business/{orgid}/{coyid}/{groupid}");

            try
            {
                var businessvatgroup = JsonSerializer.Deserialize<VATPostingGroups.VATPostingGroup>(result);
                return businessvatgroup;
            }
            catch
            {
                return new VATPostingGroups.VATPostingGroup();
            }

        }


        public async Task<VATPostingGroups.VATPostingGroup> GetVATProdPostingGroupsAsync(string orgid, string coyid, string groupid)
        {
            var result = await _apigateway.ApiGetAsync($"VATPostingGroup/product/{orgid}/{coyid}/{groupid}");

            try
            {
                var productvatgroup = JsonSerializer.Deserialize<VATPostingGroups.VATPostingGroup>(result);
                return productvatgroup;
            }
            catch
            {
                return new VATPostingGroups.VATPostingGroup();
            }
        }

        public async Task<bool> UpdateVATBusPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto)
        {

            var result = await _apigateway.ApiPostAsync<VATPostingGroups.VATPostingGroup>(dto, "VATPostingGroup/business/Edit");

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

        public async Task<bool> UpdateVATProdPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto)
        {

            var result = await _apigateway.ApiPostAsync<VATPostingGroups.VATPostingGroup>(dto, "VATPostingGroup/product/Edit");

            try
            {
                //var vatproductgroup = JsonSerializer.Deserialize<VATPostingGroups.VATPostingGroup>(result);
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
