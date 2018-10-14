using System.Linq;

namespace DogBreedServer.Controllers
{
    using Contracts;
    using Entities.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
 

    [Route("api/breeds")]
    public class BreedsController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BreedsController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAllBreeds()
        {
            try
            {
                var breeds = _repository.Breeds.GetAllBreeds();

                _logger.LogInfo($"Returned all groups from database.");

                return Ok(breeds);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAlbreeds action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/group", Name = "BreedByGroupId")]
        public IActionResult GetBreedByGroupId(Guid id)
        {
            try
            {
                var breed = _repository.Breeds.BreedsByGroups(id);

                if (!breed.Any())
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned group with id: {id}");
                    return Ok(breed);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetgroupById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "BreedById")]
        public IActionResult GetBreedById(Guid id)
        {
            try
            {
                var breed = _repository.Breeds.GetBreedsById(id);
                if (breed.Breed == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned group with id: {id}");
                    return Ok(breed);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetgroupById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateBreed([FromBody]Breeds breed)
        {
            try
            {
                if (breed == null || breed.Breed == string.Empty)
                {
                    _logger.LogError("group object sent from client is null.");
                    return BadRequest("group object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid group object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Breeds.CreateBreed(breed);

                return CreatedAtRoute("BreedById", new { id = breed.Id }, breed);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create breed action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBreed(Guid id, [FromBody]Breeds breed)
        {
            try
            {
                if (breed == null)
                {
                    _logger.LogError("group object sent from client is null.");
                    return BadRequest("group object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid group object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbbreed = _repository.Breeds.GetBreedsById(id);
                if (dbbreed == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Breeds.UpdateBreed(dbbreed, breed);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Updategroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBreed(Guid id)
        {
            try
            {
                var breed = _repository.Breeds.GetBreedsById(id);
                if (breed == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                

                _repository.Breeds.DeleteBreed(breed);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Deletegroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
