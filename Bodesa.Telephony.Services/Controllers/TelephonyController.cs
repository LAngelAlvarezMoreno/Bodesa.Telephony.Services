using Bodesa.Telephony.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bodesa.Telephony.Services.Controllers
{
    [ApiController]
    [Route("Customers/[controller]")]
    public class TelephonyController : ControllerBase
    {
        private readonly ApplicationdbContext context;

        public TelephonyController(ApplicationdbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.cnf_CustomerData>>> GetCustomers()
        {
            try
            {
                var result = await context.cnf_CustomerData.ToListAsync();

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Models.cnf_CustomerData>> GetCustomerById(string id)
        {
            try
            {
                // var result = await context.cnf_CustomerData.Where(customer => customer.PayrollNumber == id).FirstOrDefaultAsync();
                var result = await context.cnf_CustomerData.Where(customer => customer.PayrollNumber == id).FirstOrDefaultAsync();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ByPhoneNumber/{phoneNumber}")]
        public async Task<ActionResult<Models.cnf_CustomerData>> GetCustomerByPhoneNumber(string phoneNumber)
        {
            try
            {
                var result = await context.cnf_CustomerData.Where(customer => customer.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            { 
                return null;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddCustomer([FromBody] Models.cnf_CustomerData customer)
        {
            try
            {
                await context.cnf_CustomerData.AddAsync(customer);
                await context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception)
            {

                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCustomer([FromBody] Models.cnf_CustomerData customer)
        {
            try
            {
                var dbcustomer = await context.cnf_CustomerData.Where(c => c.PayrollNumber == customer.PayrollNumber).FirstOrDefaultAsync();
                if (dbcustomer == null)
                {
                    return NotFound();
                }

               
                dbcustomer.PhoneNumber = customer.PhoneNumber;
                dbcustomer.Name = customer.Name;
                dbcustomer.SecondName = customer.SecondName;
                dbcustomer.LastName = customer.LastName;
                dbcustomer.SecondLastName = customer.SecondLastName;
                dbcustomer.CECOS = customer.CECOS;
                dbcustomer.Department = customer.Department;
                dbcustomer.LeaderShip = customer.LeaderShip;

                await context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(string id)
        {
            var customer = await context.cnf_CustomerData.Where(customer => customer.PayrollNumber == id).FirstOrDefaultAsync();
            if (customer == null)
            {
                return NotFound();
            }

            context.cnf_CustomerData.Remove(customer);
            await context.SaveChangesAsync();

            return Ok(true);
        }
    }
}

