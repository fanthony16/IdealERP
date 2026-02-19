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
    public class Companysvr : ICompany
    {

        private readonly IdealERPContext dbContext;
        public Companysvr(IdealERPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Companys.Company> CreateCompanyAsync(Companys.CreateCompany newCompany)
        {

            var nwCompany = new TblCompany
            {
                Address = newCompany.Address,
                Address2 = newCompany.Address2,
                BankAccountNo = newCompany.BankAccountNo,
                BankAccPostingGroup = newCompany.BankAccountPostingGroup,
                BankBranchNo = newCompany.BankBranchNo,
                BankName = newCompany.BankName,
                City = newCompany.City,
                ContactName = newCompany.ContactName,
                Country = newCompany.Country,
                County = newCompany.County,
                Email = newCompany.Email,
                FaxNo = newCompany.FaxNo,
                GiroNo = newCompany.GiroNo,
                Iban = newCompany.Iban,
                Name = newCompany.Name,
                OrganisationId = newCompany.OrganisationId,
                PaymentRoutingNo = newCompany.PaymentRoutingNo,
                PhoneNo = newCompany.PhoneNo,
                PictureUrl = newCompany.PictureUrl,
                PostCode = newCompany.PostCode,
                ShipToAddress = newCompany.ShipToAddress,
                ShipToAddress2 = newCompany.ShipToAddress2,
                ShipToCity = newCompany.ShipToCity,
                ShipToContact = newCompany.ShipToContact,
                ShipToCountry = newCompany.ShipToCountry,
                ShipToCounty = newCompany.ShipToCounty,
                ShipToLocation = newCompany.ShipToLocation,
                ShipToName = newCompany.ShipToName,
                ShipToPostCode = newCompany.ShipToPostCode,
                SwiftCode = newCompany.SwiftCode,
                VatRegNo = newCompany.VatRegNo,
                Website = newCompany.Website
                
            };
            try
            {
                await dbContext.TblCompanies.AddAsync(nwCompany);
                await dbContext.SaveChangesAsync();
                return MapToCoy(nwCompany);
            }
            catch(Exception ex)
            {
                var coyErr = new Companys.Company
                {
                    Err = new APIError
                    {
                        Message = ex.Message,
                        Detail = new List<string>(),
                        ErrorCode = "Company_Creating_Error",
                        
                    }
                };
                return coyErr;
            }
            

        }

        public async Task<Companys.Company> EditCompanyAsync(Companys.UpdateCompany editCompany)
        {

            var dbCoy = dbContext.TblCompanies.Where(x => x.Id == editCompany.CompanyID).SingleOrDefault();

            if (dbCoy != null)
            {
                dbCoy.Address = editCompany.Address;
                dbCoy.Address2 = editCompany.Address2;
                dbCoy.BankAccountNo = editCompany.BankAccountNo;
                dbCoy.BankAccPostingGroup = editCompany.BankAccountPostingGroup;
                dbCoy.BankBranchNo = editCompany.BankBranchNo;
                dbCoy.BankName = editCompany.BankName;
                dbCoy.City = editCompany.City;
                dbCoy.ContactName = editCompany.ContactName;
                dbCoy.Country = editCompany.Country;
                dbCoy.County = editCompany.County;
                dbCoy.Email = editCompany.Email;
                dbCoy.FaxNo = editCompany.FaxNo;
                dbCoy.GiroNo = editCompany.GiroNo;
                dbCoy.Iban = editCompany.Iban;
                dbCoy.Name = editCompany.Name;
                dbCoy.OrganisationId = editCompany.OrganisationId;
                dbCoy.PaymentRoutingNo = editCompany.PaymentRoutingNo;
                dbCoy.PhoneNo = editCompany.PhoneNo;
                dbCoy.PictureUrl = editCompany.PictureUrl;
                dbCoy.PostCode = editCompany.PostCode;
                dbCoy.ShipToAddress = editCompany.ShipToAddress;
                dbCoy.ShipToAddress2 = editCompany.ShipToAddress2;
                dbCoy.ShipToCity = editCompany.ShipToCity;
                dbCoy.ShipToContact = editCompany.ShipToContact;
                dbCoy.ShipToCountry = editCompany.ShipToCountry;
                dbCoy.ShipToCounty = editCompany.ShipToCounty;
                dbCoy.ShipToLocation = editCompany.ShipToLocation;
                dbCoy.ShipToName = editCompany.ShipToName;
                dbCoy.ShipToPostCode = editCompany.ShipToPostCode;
                dbCoy.SwiftCode = editCompany.SwiftCode;
                dbCoy.VatRegNo = editCompany.VatRegNo;
                dbCoy.Website = editCompany.Website;
            }

            try
            {
                dbContext.TblCompanies.Update(dbCoy);
                await dbContext.SaveChangesAsync();
                return MapToCoy(dbCoy);
            }

            catch(Exception ex)
            {

                var coyErr = new Companys.Company
                {
                    Err = new APIError
                    {
                        Detail = new List<string>(),
                        Message = ex.Message,
                        ErrorCode ="Company_Editing_Error",
                        
                    }
                };

                return coyErr;
            }
            
        }

        public async Task<Companys.Company> GetCompanyAsync(string id)
        {
            var dbCoy = await dbContext.TblCompanies.FindAsync(id);

            if (dbCoy is not null)
            {
                return MapToCoy(dbCoy);

            }

            return new Companys.Company { 
                    Err = new APIError
                    {
                        Message = "Company Not Found"
                    }
            };
        }

        public async Task<List<Companys.Company>> GetOrgCompanysAsync(string id)
        {

            var orgCoys = await dbContext.TblCompanies.Where(x => x.OrganisationId.ToString() == id).ToListAsync();

            //if(orgCoys != null)
            //{


            if (orgCoys != null) {

                return orgCoys.Select(MapToCoy).ToList();
                
            }
             
            throw new Exception("No Company Found");


            //}
            //return new List<Companys.Company>()
            //{
            //    new Companys.Company
            //    {
            //        Err = new APIError
            //        {
            //            Message= ""
            //        }
            //    }
            //};

        }

        private Companys.Company MapToCoy(TblCompany dbCoy)
        {
            var dto = new Companys.Company
            {
                CompanyID = dbCoy.Id,
                OrganisationId = dbCoy.OrganisationId,
                Address = dbCoy.Address,
                Address2 = dbCoy.Address,
                BankAccountNo =dbCoy.BankAccountNo,
                BankAccountPostingGroup = dbCoy.BankAccPostingGroup,
                BankBranchNo = dbCoy.BankBranchNo,
                BankName = dbCoy.BankName,
                City = dbCoy.City,
                ContactName = dbCoy.ContactName,
                Country = dbCoy.Country,
                County = dbCoy.County,
                Email = dbCoy.Email,
                FaxNo = dbCoy.FaxNo,
                GiroNo = dbCoy.GiroNo,
                Iban = dbCoy.Iban,
                Name = dbCoy.Name,
                PaymentRoutingNo = dbCoy.PaymentRoutingNo,
                PhoneNo = dbCoy.PhoneNo,
                PictureUrl = dbCoy.PictureUrl,
                PostCode = dbCoy.PostCode,
                ShipToAddress = dbCoy.ShipToAddress,
                ShipToAddress2 = dbCoy.ShipToAddress2,
                ShipToCity = dbCoy.ShipToCity,
                ShipToContact = dbCoy.ShipToContact,
                ShipToCountry= dbCoy.ShipToCountry,
                ShipToCounty= dbCoy.ShipToCounty,
                ShipToLocation = dbCoy.ShipToLocation,
                ShipToName = dbCoy.ShipToName,
                ShipToPostCode = dbCoy.ShipToPostCode,
                SwiftCode = dbCoy.SwiftCode,
                VatRegNo = dbCoy.VatRegNo,
                Website = dbCoy.Website
                
            };

            return dto;

        }


    }
}
