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
    public class GenPostingGroupsvr : IGenPostingGroups
    {

        private readonly IdealERPContext dbContext;
      

        public GenPostingGroupsvr(IdealERPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GenPostingGroups.GenPostingGroup> CreateGenBusPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto)
        {

            var nwpostinggroup = new TblGenBusinessPostingGroup
            {
                OrganisationId = dto.OrganisationID,
                CompanyId = dto.CompanyID,
                Code = dto.Code,
                Description = dto.Description,
                VatId = dto.VatID
            };


            try
            {
                await dbContext.TblGenBusinessPostingGroups.AddAsync(nwpostinggroup);
                await dbContext.SaveChangesAsync();

                return MapToObj(nwpostinggroup, null);

            }
            catch
            {
                return null;
            }

        }


        private static GenPostingGroups.GenPostingGroup MapToObj(TblGenBusinessPostingGroup genbpg, TblGenProductPostingGroup genppg)
        {
            if (genbpg != null)
            {
                var genPostingGroupObj = new GenPostingGroups.GenPostingGroup
                {
                    Id = genbpg.Id,
                    Code = genbpg.Code,
                    Description = genbpg.Description,
                    CompanyID = genbpg.CompanyId,
                    OrganisationID = genbpg.OrganisationId,
                    VatID = genbpg.VatId

                };
                return genPostingGroupObj;
            }
            else if (genppg != null)
            {
                var genPostingGroupObj = new GenPostingGroups.GenPostingGroup
                {
                    Id = genppg.Id,
                    Code = genppg.Code,
                    Description = genppg.Description,
                    CompanyID = genppg.CompanyId,
                    OrganisationID = genppg.OrganisationId,
                    VatID = genppg.VatId
                };
                return genPostingGroupObj;
            }

            return null;

        }


        public async Task<GenPostingGroups.GenPostingGroup> CreateGenProdPostingGroupsAsync(GenPostingGroups.CreateGenPostingGroup dto)
        {
            var nwpostinggroup = new TblGenProductPostingGroup
            {
                OrganisationId = dto.OrganisationID,
                CompanyId = dto.CompanyID,
                Code = dto.Code,
                Description = dto.Description,
                VatId = dto.VatID
            };

            try
            {
                await dbContext.TblGenProductPostingGroups.AddAsync(nwpostinggroup);
                await dbContext.SaveChangesAsync();

                return MapToObj(null, nwpostinggroup);

            }
            catch
            {
                return null;
            }

        }

        public async Task<List<GenPostingGroups.GenPostingGroup>> GetGenBusPostingGroupsAsync(string orgid, string coyid)
        {

            var lstvbpg = new List<GenPostingGroups.GenPostingGroup>();
            var postinggroups = await dbContext.TblGenBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString()).ToListAsync();

            foreach (var gpg in postinggroups)
            {
                lstvbpg.Add(MapToObj(gpg, null));
            }

            return lstvbpg;

        }

        public async Task<List<GenPostingGroups.GenPostingGroup>> GetGenProdPostingGroupsAsync(string orgid, string coyid)
        {
            var lstvppg = new List<GenPostingGroups.GenPostingGroup>();
            var postinggroups = await dbContext.TblGenProductPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString()).ToListAsync();

            foreach (var gpg in postinggroups)
            {
                lstvppg.Add(MapToObj(null, gpg));
            }

            return lstvppg;
        }


        public async Task<GenPostingGroups.GenPostingGroup> GetGenBusPostingGroupsAsync(string orgid, string coyid, string id)
        {
            var postinggroup = await dbContext.TblGenBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString() && x.Id.ToString() == id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {
                return MapToObj(postinggroup, null);
            }

            return null;
        }

        public async Task<GenPostingGroups.GenPostingGroup> GetGenProdPostingGroupsAsync(string orgid, string coyid, string id)
        {
            var postinggroup = await dbContext.TblGenProductPostingGroups.Where(x => x.OrganisationId.ToString() == orgid.ToString() && x.CompanyId.ToString() == coyid.ToString() && x.Id.ToString() == id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {
                return MapToObj(null, postinggroup);
            }

            return null;

        }


        public async Task<bool> UpdateGenBusPostingGroupsAsync(GenPostingGroups.GenPostingGroup dto)
        {

            var postinggroup = await dbContext.TblGenBusinessPostingGroups.Where(x => x.OrganisationId.ToString() == dto.OrganisationID.ToString() && x.CompanyId.ToString() == dto.CompanyID.ToString() && x.Id.ToString() == dto.Id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {

                postinggroup.Code = dto.Code;
                postinggroup.Description = dto.Description;
                postinggroup.VatId = dto.VatID;

                dbContext.Update(postinggroup);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;

        }

        public async Task<bool> UpdateGenProdPostingGroupsAsync(GenPostingGroups.GenPostingGroup dto)
        {

            var postinggroup = await dbContext.TblGenProductPostingGroups.Where(x => x.OrganisationId.ToString() == dto.OrganisationID.ToString() && x.CompanyId.ToString() == dto.CompanyID.ToString() && x.Id.ToString() == dto.Id.ToString()).FirstOrDefaultAsync();

            if (postinggroup != null)
            {

                postinggroup.Code = dto.Code;
                postinggroup.Description = dto.Description;
                postinggroup.VatId = dto.VatID;


                dbContext.Update(postinggroup);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;

        }
    }
}
