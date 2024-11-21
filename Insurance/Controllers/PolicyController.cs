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
    public class PolicyController : ControllerBase
    {
        private readonly DataContext _context;

        public PolicyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Policy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyModel>>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        // GET: api/Policy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyModel>> GetPolicyModel(Guid id)
        {
            var policyModel = await _context.Policies.FindAsync(id);

            if (policyModel == null)
            {
                return NotFound();
            }

            return policyModel;
        }

        // PUT: api/Policy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyModel(string id, PolicyModel policyModel)
        {
          var UpdatePolicyData = await _context.Policies.Where(x => x.policyId == id).FirstOrDefaultAsync();

            if (UpdatePolicyData != null) {
                UpdatePolicyData.policyId = id;
                UpdatePolicyData.policyName = policyModel.policyName;
                UpdatePolicyData.policyDescription = policyModel.policyDescription;
                UpdatePolicyData.policyActive = policyModel.policyActive;

                _context.Policies.Update(UpdatePolicyData);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Updated Successfully"));
            }



            else
            {

                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Date Not Found"));
            }




        }

        // POST: api/Policy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyModel>> PostPolicyModel(PolicyModel policyModel)
        {
            PolicyModel policyData = new PolicyModel();

            policyData.policyName = policyModel.policyName;
            policyData.policyDescription = policyModel.policyDescription;
            policyData.policyActive = policyModel.policyActive;

            _context.Policies.Add(policyData);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Insert Successfully"));
        }

        // DELETE: api/Policy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyModel(string id)
        {
            var policyModel = await _context.Policies.FindAsync(id);
            if (policyModel == null)
            {
                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Deleted Failed"));
            }

            _context.Policies.Remove(policyModel);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Deleted Successfully"));
        }

        private bool PolicyModelExists(string id)
        {
            return _context.Policies.Any(e => e.policyId == id);
        }
    }
}
