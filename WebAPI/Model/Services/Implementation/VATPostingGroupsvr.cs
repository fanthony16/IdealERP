using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.DTO;
using WebAPI.Model.Services.Interface;

namespace WebAPI.Model.Services.Implementation
{
    public class VATPostingGroupsvr : IVATPostingGroup
    {
        private readonly IdealERPContext dbContext;

        public VATPostingGroupsvr(IdealERPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VATPostingGroups.VATPostingGroup> CreateVATBusPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto)
        {

            var nwpostinggroup = new TblVatBusinessPostingGroup
            {
                OrganisationId = dto.OrganisationID,
                CompanyId = dto.CompanyID,
                Code = dto.Code,
                Description = dto.Description
            };


            try
            {
                await dbContext.TblVatBusinessPostingGroups.AddAsync(nwpostinggroup);
                await dbContext.SaveChangesAsync();

               return MapToObj(nwpostinggroup, null);

            }
            catch 
            {
                return null;
            }
            

        }

        private static VATPostingGroups.VATPostingGroup MapToObj(TblVatBusinessPostingGroup vatbpg, TblVatProductPostingGroup vatppg)
        {
            if (vatbpg != null)
            {
                var vatPostingGroupObj = new VATPostingGroups.VATPostingGroup
                {
                    Id = vatbpg.Id,
                    Code = vatbpg.Code,
                    Description = vatbpg.Description,
                    CompanyID = vatbpg.CompanyId,
                    OrganisationID = vatbpg.OrganisationId

                };
                return vatPostingGroupObj;
            }
            else if (vatppg != null) 
            {
                var vatPostingGroupObj = new VATPostingGroups.VATPostingGroup
                {
                    Id = vatppg.Id,
                    Code = vatppg.Code,
                    Description = vatppg.Description,
                    CompanyID = vatppg.CompanyId,
                    OrganisationID = vatppg.OrganisationId

                };
                return vatPostingGroupObj;
            }

            return null;

        }

        public async Task<VATPostingGroups.VATPostingGroup> CreateVATProdPostingGroupsAsync(VATPostingGroups.CreateVATPostingGroup dto)
        {

            var nwpostinggroup = new TblVatProductPostingGroup
            {
                OrganisationId = dto.OrganisationID,
                CompanyId = dto.CompanyID,
                Code = dto.Code,
                Description = dto.Description
            };

            try 
            {
                await dbContext.TblVatProductPostingGroups.AddAsync(nwpostinggroup);
                await dbContext.SaveChangesAsync();

                return MapToObj(null, nwpostinggroup);
                
            }
            catch
            {
                return null;
            }

        }

        public async Task<List<VATPostingGroups.VATPostingGroup>> GetVATBusPostingGroupsAsync(string orgid, string coyid)
        {
            var lstvbpg = new List<VATPostingGroups.VATPostingGroup>();
            var postinggroups = await dbContext.TblVatBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString()).ToListAsync();

            foreach (var vpg in postinggroups)
            {
                lstvbpg.Add(MapToObj(vpg,null));
            }

            return lstvbpg;
        }




        public async Task<List<VATPostingGroups.VATPostingGroup>> GetVATProdPostingGroupsAsync(string orgid, string coyid)
        {
            var lstvppg = new List<VATPostingGroups.VATPostingGroup>();
            var postinggroups = await dbContext.TblVatProductPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString()).ToListAsync();

            foreach (var vpg in postinggroups)
            {
                lstvppg.Add(MapToObj(null, vpg));
            }

            return lstvppg;
        }

        public async Task<VATPostingGroups.VATPostingGroup> GetVATBusPostingGroupsAsync(string orgid, string coyid, string id)
        {
            
            var postinggroup = await dbContext.TblVatBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString() && x.Id.ToString() == id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {
                return MapToObj(postinggroup, null);
            }

            return null;

        }
        
        public async Task<VATPostingGroups.VATPostingGroup> GetVATProdPostingGroupsAsync(string orgid, string coyid, string id)
        {
            var postinggroup = await dbContext.TblVatProductPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString() && x.Id.ToString() == id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {
                return MapToObj(null, postinggroup);
            }

            return null;
        }

        public async Task<bool> UpdateVATBusPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto)
        {

            var postinggroup = await dbContext.TblVatBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == dto.OrganisationID.ToString() && x.CompanyId.ToString() == dto.CompanyID.ToString() && x.Id.ToString() == dto.Id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {

                postinggroup.Code = dto.Code;
                postinggroup.Description = dto.Description;

                dbContext.Update(postinggroup);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;

        }

        public async Task<bool> UpdateVATProdPostingGroupsAsync(VATPostingGroups.VATPostingGroup dto)
        {
            var postinggroup = await dbContext.TblVatProductPostingGroups.Where(x => x.OrganisationId.ToString() == dto.OrganisationID.ToString() && x.CompanyId.ToString() == dto.CompanyID.ToString() && x.Id.ToString() == dto.Id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {

                postinggroup.Code = dto.Code;
                postinggroup.Description = dto.Description;

                dbContext.Update(postinggroup);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

     
    }
}
