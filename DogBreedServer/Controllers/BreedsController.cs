namespace DogBreedServer.Controllers
{
    using Contracts;
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
        public IActionResult GetAllOwners()
        {
            try
            {
                var breeds = _repository.Breeds.GetAllBreeds();

                _logger.LogInfo($"Returned all owners from database.");

                return Ok(breeds);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAlbreeds action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBreedById(int id)
        {
            try
            {
                var owner = _repository.Breeds.GetBreedsById(id);

                if (owner.Breed == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
