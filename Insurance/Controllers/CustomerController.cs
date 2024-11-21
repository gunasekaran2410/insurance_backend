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
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
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

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerModel(Guid id)
        {
            var customerModel = await _context.Customers.FindAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return customerModel;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerModel(string id, CustomerModel customerModel)

        {
            var UpdateCustomerData = await _context.Customers.Where(x => x.customerId == id).FirstOrDefaultAsync();

            if (UpdateCustomerData != null)
            {
                UpdateCustomerData.customerId = id;
                UpdateCustomerData.name = customerModel.name;
                UpdateCustomerData.fatherName = customerModel.fatherName;
                UpdateCustomerData.motherName = customerModel.motherName;
                UpdateCustomerData.dateofBirth = customerModel.dateofBirth;
                UpdateCustomerData.qualification = customerModel.qualification;
                UpdateCustomerData.gender = customerModel.gender;
                UpdateCustomerData.graduation = customerModel.graduation;
                UpdateCustomerData.mobileNumber = customerModel.mobileNumber;
                UpdateCustomerData.EmailId = customerModel.EmailId;
                UpdateCustomerData.alternativeNo = customerModel.alternativeNo;
                UpdateCustomerData.aadharNo = customerModel.aadharNo;
                UpdateCustomerData.permanent_address_street = customerModel.permanent_address_street;
                UpdateCustomerData.permanent_address_area = customerModel.permanent_address_area;
                UpdateCustomerData.permanent_location = customerModel.permanent_location;
                UpdateCustomerData.permanent_city = customerModel.permanent_city;
                UpdateCustomerData.same_as_permanent_address = customerModel.same_as_permanent_address;
                UpdateCustomerData.present_address_street = customerModel.present_address_street;
                UpdateCustomerData.present_address_area = customerModel.present_address_area;
                UpdateCustomerData.present_location = customerModel.present_location;
                UpdateCustomerData.present_city = customerModel.present_city;
                UpdateCustomerData.dateofWedding = customerModel.dateofWedding;
                UpdateCustomerData.spouse_name = customerModel.spouse_name;
                UpdateCustomerData.spouse_dateofbirth = customerModel.spouse_dateofbirth;
                UpdateCustomerData.children = customerModel.children;
                UpdateCustomerData.GroupId = customerModel.GroupId;
                _context.Customers.Update(UpdateCustomerData);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Updated Successfully"));
            }
            else
            {

                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Date Not Found"));
            }
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerModel(CustomerModel customerModel)

        {
            var result = await _context.Customers.Select(x => new { x.aadharNo, x.EmailId, x.mobileNumber}).ToListAsync();



            foreach(var j in result)
            {
                if (j.aadharNo == customerModel.aadharNo && !string.IsNullOrEmpty(customerModel.aadharNo)) { 

                    return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Aadhar Number already exite"));
                }
                if (j.EmailId == customerModel.EmailId)
                {

                    return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Email Id already exite"));
                }
                if (j.mobileNumber == customerModel.mobileNumber)
                {

                    return new OkObjectResult(await ErrorModel.ErrorMessage("0", "MobileNumber already exite"));
                }

                

            }

            CustomerModel customerData = new CustomerModel();
                customerData.name = customerModel.name;
                customerData.fatherName = customerModel.fatherName;
                customerData.motherName = customerModel.motherName;
                customerData.dateofBirth = customerModel.dateofBirth;
                customerData.qualification = customerModel.qualification;
                customerData.gender = customerModel.gender;
                customerData.graduation=customerModel.graduation;
                customerData.mobileNumber = customerModel.mobileNumber;
                customerData.EmailId = customerModel.EmailId;
                customerData.alternativeNo = customerModel.alternativeNo;
                customerData.aadharNo = customerModel.aadharNo;
                customerData.permanent_address_street = customerModel.permanent_address_street;
                customerData.permanent_address_area = customerModel.permanent_address_area;
                customerData.permanent_location = customerModel.permanent_location;
                customerData.permanent_city = customerModel.permanent_city;
                customerData.same_as_permanent_address=customerModel.same_as_permanent_address;
                customerData.present_address_street=customerModel.present_address_street;
                customerData.present_address_area=customerModel.present_address_area;
                customerData.present_location = customerModel.present_location;
                customerData.present_city = customerModel.present_city;
                customerData.dateofWedding = customerModel.dateofWedding;
                customerData.spouse_name = customerModel.spouse_name;
                customerData.spouse_dateofbirth = customerModel.spouse_dateofbirth;
                customerData.children = customerModel.children;
            customerData.GroupId = customerModel.GroupId;

            _context.Customers.Add(customerData);
            await _context.SaveChangesAsync();

            return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Inserted Successfully"));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerModel(string id)
        {
            var customerModel = await _context.Customers.FindAsync(id);
            if (customerModel == null)
            {
                return new OkObjectResult(await ErrorModel.ErrorMessage("0", "Delete Failed"));
            }
            else
            {
                _context.Customers.Remove(customerModel);
                await _context.SaveChangesAsync();

                return new OkObjectResult(await ErrorModel.ErrorMessage("1", "Deleted Successfully"));
            }
        }

        private bool CustomerModelExists(string id)
        {
            return _context.Customers.Any(e => e.customerId == id);
        }
    }
}
