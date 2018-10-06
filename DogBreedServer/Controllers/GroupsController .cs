namespace DogBreedServer.Controllers
{
    using Contracts;
    using Entities.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public GroupsController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAllGroups()
        {
            try
            {
                var breeds = _repository.Groups.GetAllGroupss();

                _logger.LogInfo($"Returned all owners from database.");

                return Ok(breeds);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAl Groups action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetGroupsById(Guid id)
        {
            try
            {
                var owner = _repository.Groups.GetGroupsById(id);

                if (owner.GroupName == null)
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

        [HttpGet("{id}/group")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = _repository.Groups.GetGroupsWithDetails(id);

                if (owner.Groups.GroupName == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody]Groups owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Groups.CreateGroup(owner);

                return CreatedAtRoute("OwnerById", new { id = owner.GroupdId }, owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]Groups owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbOwner = _repository.Groups.GetGroupsById(id);
                if (dbOwner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Groups.UpdateGroup(dbOwner, owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(Guid id)
        {
            try
            {
                var owner = _repository.Groups.GetGroupsById(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repository.Breeds.BreedsByGroups(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repository.Groups.DeleteGroup(owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
