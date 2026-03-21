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
    public class AccountChart : IAccountChart
    {
        private readonly IdealERPContext dbContext;

        public AccountChart(IdealERPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ChartLedgerAccount.LedgerAccount> CreateAsync(ChartLedgerAccount.CreateLedgerAccount dto)
        {
            var nwledgeraccount = new TblChartOfAccount
            {
                No = dto.AccountNo,
                AccountCategory = dto.AccountCategory,
                AccountSubCategory = dto.AccountSubCategory,
                AccountType = Convert.ToInt32(dto.AccountType),
                Balance = dto.Balance,
                Blocked = dto.Blocked,
                DebitCredit = dto.DebitCredit,
                DirectPosting = dto.DirectPosting,
                GenBusPostingGroup = dto.GeneralBusinessPostingGroup,
                GenPostingType = dto.GeneralPostingType,
                GenProdPostingGroup = dto.GeneralProductPostingGroup,
                IncomeBalance = Convert.ToInt32(dto.IncomeBalance),
                VatPostingGroup = dto.VatPostingGroup,
                VatProdPostingGroup = dto.VatProductPostingGroup,
                Name = dto.Name,
                CompanyId = dto.CompanyID,
                OrganisationId = dto.OrganisationID
            };

           await dbContext.TblChartOfAccounts.AddAsync(nwledgeraccount);
           await dbContext.SaveChangesAsync();

           return MapToObj(nwledgeraccount);

        }

        public async Task<List<ChartLedgerAccount.LedgerAccount>> GetLedgerAccountsAsync(string orgid, string coyid)
        {

            var accountledger = await dbContext.TblChartOfAccounts.Where(x => x.OrganisationId.ToString() == orgid && x.CompanyId.ToString() == coyid).ToListAsync();
            return accountledger.Select(MapToObj).ToList();

        }

        private ChartLedgerAccount.LedgerAccount MapToObj(TblChartOfAccount coa) 
        {
            var ledgeraccountObj = new ChartLedgerAccount.LedgerAccount
            {

                CompanyID = coa.CompanyId,
                OrganisationID = coa.OrganisationId,
                AccountCategory = coa.AccountCategory,
                AccountNo = coa.No,
                Name = coa.Name,
                AccountType = coa.AccountType.ToString(),
                Balance = coa.Balance,
                Blocked = coa.Blocked,
                DebitCredit = coa.DebitCredit,
                DirectPosting = coa.DirectPosting,
                GeneralBusinessPostingGroup = coa.GenBusPostingGroup,
                GeneralPostingType = coa.GenPostingType,
                GeneralProductPostingGroup =coa.GenProdPostingGroup,
                IncomeBalance = coa.IncomeBalance.ToString(),
                AccountSubCategory = coa.AccountSubCategory,
                VatPostingGroup = coa.VatPostingGroup,
                VatProductPostingGroup = coa.VatProdPostingGroup,
                LedgerID = coa.Id

            };
            return ledgeraccountObj;
        }

        public async Task<ChartLedgerAccount.LedgerAccount> UpdateAsync(ChartLedgerAccount.LedgerAccount dto)
        {
            var dbledgerAccount = await dbContext.TblChartOfAccounts.Where(x => x.OrganisationId.ToString() == dto.OrganisationID.ToString() && x.CompanyId.ToString() == dto.CompanyID.ToString() && x.Id.ToString() == dto.LedgerID.ToString()).FirstOrDefaultAsync();

            if (dbledgerAccount != null)
            {

                dbledgerAccount.Name = dto.Name;
                dbledgerAccount.No = dto.AccountNo;
                dbledgerAccount.VatPostingGroup = dto.VatPostingGroup;
                dbledgerAccount.VatProdPostingGroup = dto.VatProductPostingGroup;
                dbledgerAccount.AccountCategory = dto.AccountCategory;
                dbledgerAccount.AccountSubCategory = dto.AccountSubCategory;
                dbledgerAccount.AccountType = Convert.ToInt32(dto.AccountType);
                dbledgerAccount.Balance = dto.Balance;
                dbledgerAccount.Blocked = dto.Blocked;
                dbledgerAccount.DebitCredit = dto.DebitCredit;
                dbledgerAccount.DirectPosting = dto.DirectPosting;
                dbledgerAccount.IncomeBalance = Convert.ToInt32(dto.IncomeBalance);

                dbContext.Update(dbledgerAccount);
                await dbContext.SaveChangesAsync();

                return MapToObj(dbledgerAccount);

            }
            else
            {

                return new ChartLedgerAccount.LedgerAccount();

            }

        }

        public async Task<ChartLedgerAccount.LedgerAccount> GetLedgerAccountsAsync(string orgid, string coyid, string ledgerid)
        {
            var dbledgerAccount = await dbContext.TblChartOfAccounts.Where(x => x.OrganisationId.ToString() == orgid && x.CompanyId.ToString() == coyid && x.Id.ToString() == ledgerid.ToString()).FirstOrDefaultAsync();

            return MapToObj(dbledgerAccount);

            

        }
    }
}
