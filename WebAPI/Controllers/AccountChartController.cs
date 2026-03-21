using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DTO;
using WebAPI.Model.Services;
using WebAPI.Model.Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountChartController : Controller
    {
        private readonly APIError apiError;
        private readonly ValidationErrors valErrors;
        private readonly IAccountChart _accountChart;

        public AccountChartController(APIError apiError, ValidationErrors valErrors, IAccountChart _accountChart)
        {
            this.apiError = apiError;
            this.valErrors = valErrors;
            this._accountChart = _accountChart;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("accounts/New")]
        public async Task<IActionResult> Create([FromBody] ChartLedgerAccount.CreateLedgerAccount dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "Company_Creation";
                return BadRequest(apiError);
            }

            var nwledgeraccount =  await _accountChart.CreateAsync(dto);
            return Ok(nwledgeraccount);

        }

        [HttpPost("accounts/Edit")]
        public async Task<IActionResult> Update([FromBody] ChartLedgerAccount.LedgerAccount dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "Ledger_Update";
                return BadRequest(apiError);
            }

            var nwledgeraccount = await _accountChart.UpdateAsync(dto);
            return Ok(nwledgeraccount);

        }

        [HttpGet("accounts/{orgid}/{coyid}")]
        public async Task<IActionResult> GetAccountLedgers(string orgid, string coyid )
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid))
            {

                var ledgeraccounts = await _accountChart.GetLedgerAccountsAsync(orgid, coyid);
                return Ok(ledgeraccounts);

            }

            return BadRequest("Organisation ID and Company ID is Required");

        }

        [HttpGet("accounts/{orgid}/{coyid}/{ledgerid}")]
        public async Task<IActionResult> GetAccountLedger(string orgid, string coyid, string ledgerid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid) && !string.IsNullOrEmpty(ledgerid))
            {

                var ledgeraccount = await _accountChart.GetLedgerAccountsAsync(orgid, coyid, ledgerid);
                return Ok(ledgeraccount);

            }

            return BadRequest("Organisation ID, Company ID and Account No is Required");

        }

    }
}
