using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using static WebAPI.Model.DTO.Organisation;

namespace WebAPI.Model.Services
{
    public class Organisationsvr : IOrganisationsvr
    {
        private readonly IdealERPContext dbContext;

        public Organisationsvr(IdealERPContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Organisations> CreateOrganisationAsync(CreateOrganisation dto)
        {
            var nwOrg = new TblOrganisation
            {
                LegalName = dto.Legal_name,
                Country = dto.CountryName,
                Currency = dto.CurrencyType,
                Industry = dto.Industry,
                BusinessEmail = dto.Business_Email,
                AcceptTerms = dto.AcceptTerms
            };
            //RegistrationStage = (dto.Registration_stage == "Active") ? 1 : (dto.Registration_stage == "Suspended") ? 2: 3,
            await dbContext.TblOrganisations.AddAsync(nwOrg);
            await dbContext.SaveChangesAsync();
            return MapToOrg(nwOrg);

        }

        private Organisations MapToOrg(TblOrganisation dbOrg)
        {
            var dto = new Organisations
            {
                Id = dbOrg.Id,
                Legal_name = dbOrg.LegalName,
                CountryName = dbOrg.Country,
                CurrencyType = dbOrg.Currency,
                Industry = dbOrg.Industry,
                Business_Email = dbOrg.BusinessEmail
                
            };
            return dto;
        }

        public async Task<List<Organisations>> GetAllOrganisationAsync()
        {

           var dbOrganisations = await dbContext.TblOrganisations.ToListAsync();
           return dbOrganisations.Select(MapToOrg).ToList();
           

        }

        public Task<bool> UpdateOrganisationAsync(UpdateOrganisation dto)
        {
            throw new NotImplementedException();
        }
    }
}
