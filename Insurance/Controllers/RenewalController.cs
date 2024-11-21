using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance.Data;
using Insurance.Models;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewalController : ControllerBase
    {
        private readonly DataContext _context;

        public RenewalController(DataContext context)
        {
            _context = context;
        }

        // group Id generate
        [HttpGet("GetGroupId")]
        public async Task<IActionResult> GetGroupId()
        {
            var result = new
            {
                groupId = Guid.NewGuid()
            };

            return Ok(result);
        }

        // GET: api/Renewal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RenewalModel>>> GetRenewalModel()
        {
            var reponseData = await Task.Run(() => (from a in _context.RenewalModel
                                                    join b in _context.Customers on a.customerId equals b.customerId
                                                    join c in _context.Policies on a.policyId equals c.policyId
                                                    select new
                                                    {
                                                        a.policyId,
                                                        a.renewalId,
                                                        a.companyId,
                                                        a.customer_name,
                                                        a.amount,
                                                        a.policy_no,
                                                        a.policy_for,
                                                        a.description,
                                                        a.duration_months,
                                                        a.next_renewal,
                                                        b.mobileNumber,
                                                        c.policyName,
                                                        a.renewal_date,
                                                        a.customerId,
                                                        a.GroupId
                                                    }
                                                    ).ToListAsync());

            return Ok(reponseData);
        }

        // GET: api/Renewal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RenewalModel>> GetRenewalModel(string id)
        {
            var renewalModel = await _context.RenewalModel.FindAsync(id);

            if (renewalModel == null)
            {
                return NotFound();
            }

            return renewalModel;
        }

        // GET: Filter Fromdate and Todate
        [HttpGet("fromdate_todate")]
        public async Task<ActionResult<RenewalModel>> Fromdate_toDateModel(DateTime fromddate, DateTime todate)
        {
            var filterDatedata = await Task.Run(() => (
                from a in _context.renewals where a.next_renewal >= fromddate && a.next_renewal <= todate select a
            ).ToListAsync());

            return Ok( filterDatedata );
        }

        // PUT: api/Renewal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenewalModel(string id, RenewalModel renewalModel)
        {
            var UpdateRenewalData = await _context.renewals.Where(x => x.renewalId == id).FirstOrDefaultAsync();

            if (UpdateRenewalData != null)
            {
                UpdateRenewalData.customerId = renewalModel.customerId;
                UpdateRenewalData.customer_name = renewalModel.customer_name;
                UpdateRenewalData.companyId = renewalModel.companyId;
                UpdateRenewalData.policyId = renewalModel.policyId;
                UpdateRenewalData.policy_no = renewalModel.policy_no;
                UpdateRenewalData.policy_for = renewalModel.policy_for;
                UpdateRenewalData.renewal_date = renewalModel.renewal_date;
                UpdateRenewalData.duration_months = renewalModel.duration_months;
                UpdateRenewalData.next_renewal = renewalModel.next_renewal;
                UpdateRenewalData.amount = renewalModel.amount;
                UpdateRenewalData.description = renewalModel.description;
                UpdateRenewalData.GroupId = renewalModel.GroupId;


                _context.renewals.Update(UpdateRenewalData);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Updated Successfully"));
            }
            else
            {

                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Date Not Found"));
            }
        }

        // POST: api/Renewal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RenewalModel>> PostRenewalModel(RenewalModel renewalModel)
        {
            RenewalModel renewalData = new RenewalModel();

            renewalData.customerId = renewalModel.customerId;
            renewalData.customer_name = renewalModel.customer_name;
            renewalData.companyId = renewalModel.companyId;
            renewalData.policyId = renewalModel.policyId;
            renewalData.policy_no = renewalModel.policy_no;
            renewalData.policy_for = renewalModel.policy_for;
            renewalData.renewal_date = renewalModel.renewal_date;
            renewalData.duration_months = renewalModel.duration_months;
            renewalData.next_renewal = renewalModel.next_renewal;
            renewalData.amount = renewalModel.amount;
            renewalData.description = renewalModel.description;
            renewalData.GroupId = renewalModel.GroupId;
            _context.renewals.Add(renewalData);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Insert Successfully"));
        }

        // DELETE: api/Renewal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenewalModel(string id)
        {
            var renewalModel = await _context.renewals.FindAsync(id);
            if (renewalModel == null)
            {
                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Deleted Failed"));
            }

            _context.renewals.Remove(renewalModel);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Deleted Successfully"));
        }

        private bool RenewalModelExists(string id)
        {
            return _context.RenewalModel.Any(e => e.renewalId == id);
        }
    }
}
