using System.Collections.Generic;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Compulsory1.Petshop.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController
    {
        private readonly IPetTypeService _service;

        public PetTypeController(IPetTypeService service)
        {
            _service = service;
        }
        /*
        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_service.AllPetTypes());
        }
        */
    }
}