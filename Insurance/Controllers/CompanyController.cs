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
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> GetCompanies()
        {
            /*var result = await Task.Run(() => (
            from a in _context.Companies 
            select new
            {

            }
            ));*/
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyModel(Guid id)
        {
            var companyModel = await _context.Companies.FindAsync(id);

            if (companyModel == null)
            {
                return NotFound();
            }

            return companyModel;
        }

        // PUT: api/Company/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyModel(string id, CompanyModel companyModel)
        {
            var UpdateCompanyData = await _context.Companies.Where(x => x.companyId == id).FirstOrDefaultAsync();

            if (UpdateCompanyData != null)
            {
                UpdateCompanyData.companyId = id;
                UpdateCompanyData.companyName = companyModel.companyName;
                UpdateCompanyData.companyDescription = companyModel.companyDescription;
                UpdateCompanyData.companyActive = companyModel.companyActive;

                _context.Companies.Update(UpdateCompanyData);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Updated Successfully"));
            }
            else
            {

                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Date Not Found"));
            }

        }

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyModel>> PostCompanyModel(CompanyModel companyModel)
        {

            CompanyModel companyData = new CompanyModel();

            companyData.companyName = companyModel.companyName;
            companyData.companyDescription = companyModel.companyDescription;
            companyData.companyActive = companyModel.companyActive;

            _context.Companies.Add(companyData);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Insert Successfully"));
        }


        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyModel(string id)
        {
            var companyModel = await _context.Companies.FindAsync(id);
            if (companyModel == null)
            {
                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Delete Failed"));
            }
            else
            {
                _context.Companies.Remove(companyModel);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Deleted Successfully"));
            }
        }

        private bool CompanyModelExists(string id)
        {
            return _context.Companies.Any(e => e.companyId == id);



        }
    }
}
