using Microsoft.AspNetCore.Mvc;
using Telerik.SolidPrinciples.Models;
using Telerik.SolidPrinciples.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Telerik.SolidPrinciples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactService.FindAllContactsAsync();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return null;
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] PersonalContact contact)
        {
            return await _contactService.CreateContactAsync(contact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] PersonalContact contact)
        {
            await _contactService.UpdateContactAsync(id, contact);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _contactService.DeleteContactAsync(id);
        }
    }
}
