using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compulsory1.Petshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        
        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Owner owner)
            {
                var createdOwner = _ownerService.AddOwner(owner.FirstName, owner.LastName, owner.Address, owner.PhoneNumber, owner.Email);
                return Created($"https://localhost/api/pets/{createdOwner.Id}",createdOwner);
            }
        
        
        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_ownerService.GetOwners());
        }
        
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Owner owner)
        {
            owner.Id = id;
            _ownerService.UpdateOwner(id, owner);
        }
        
        [HttpDelete]
        public void Remove(int? ownerId)
        {
            _ownerService.RemoveOwner(ownerId);
        }
    }
}