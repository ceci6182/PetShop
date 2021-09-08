using System;
using System.Collections.Generic;
using System.IO;
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
    public class PetsController : ControllerBase
    {
        private readonly IPetServices _service;
        public PetsController(IPetServices _petService)
        {
            _service = _petService;
        }

        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Pet pet)
        {
            var createdPet = _service.addPet(pet.Name, pet.Birthdate, pet.SoldDate, pet.Color, pet.Price, pet.PetType);
            return Created($"https://localhost/api/pets/{createdPet.Id}",createdPet);
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_service.GetPets());
        }

        /*
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            Pet pet = _service.GetPetFromId(id);
            return Ok(pet);
        }
        */


        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Pet pet)
        {
            pet.Id = id;
            _service.updatePet(id, pet);
        }
        
        [HttpDelete]
        public void Remove(int petId)
        {
            _service.RemovePet(petId);
        }
    }
}