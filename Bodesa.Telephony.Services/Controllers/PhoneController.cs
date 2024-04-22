using Bodesa.Telephony.Services.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Bodesa.Telephony.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly ApplicationdbContext context;

        public PhoneController(ApplicationdbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.cnf_PhoneNumber>>> GetAllPhones()
        {
            try
            {
                var result = await context.cnf_PhoneNumber.ToListAsync();  
                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
               return BadRequest(StatusCodes.Status500InternalServerError);               
            }
        }

        [HttpGet("{phoneNumber}")]
        public async Task<ActionResult<Models.cnf_PhoneNumber>> GetPhoneByNumber(string phoneNumber)
        {
            try
            {               
                var result = await context.cnf_PhoneNumber.Where(phone => phone.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{phoneNumber}")]
        public async Task<ActionResult<bool>> DeletePhoneNumber(string phoneNumber)
        {
            try
            {
                var result = await context.cnf_PhoneNumber.FindAsync(phoneNumber);
                if (result == null)
                {
                    return NotFound();
                }

                context.cnf_PhoneNumber.Remove(result);
                await context.SaveChangesAsync();

                return Ok(true);

            }
            catch (Exception)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);                
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddPhoneNumber(Models.cnf_PhoneNumber obj)
        {
            try
            {
                var phoneNumer = await context.cnf_PhoneNumber.FindAsync(obj.PhoneNumber);
                if (phoneNumer != null)
                {
                    return Ok(phoneNumer);
                }

                await context.cnf_PhoneNumber.AddAsync(obj);
                await context.SaveChangesAsync();

                return Ok(true);
            }
            catch(DbUpdateException dbEx)
            {
                return BadRequest(dbEx.InnerException);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);                
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdatePhone(Models.cnf_PhoneNumber phoneNumber)
        {
            try
            {
                var dbPhone = await context.cnf_PhoneNumber.FindAsync(phoneNumber.PhoneNumber);
                if (dbPhone == null)
                {
                    return NotFound();
                }

                dbPhone.Region = phoneNumber.Region;
                dbPhone.Status = phoneNumber.Status;

                await context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);                
            }
        }
    }
}
