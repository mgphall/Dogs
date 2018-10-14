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
                var breeds = _repository.Groups.GetAllGroups();

                _logger.LogInfo($"Returned all groups from database.");

                return Ok(breeds);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAl Groups action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "GroupsById")]
        public IActionResult GetGroupsById(Guid id)
        {
            try
            {
                var group = _repository.Groups.GetGroupsById(id);

                if (group.GroupName == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned group with id: {id}");
                    return Ok(group);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetgroupById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/Breeds")]
        public IActionResult GetGroupWithDetails(Guid id)
        {
            try
            {
                var group = _repository.Groups.GetGroupsWithDetails(id);

                if (group.GroupName == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned group with details for id: {id}");
                    return Ok(group);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGroupWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody]Groups group)
        {
            try
            {
                if (group == null)
                {
                    _logger.LogError("group object sent from client is null.");
                    return BadRequest("group object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid group object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Groups.CreateGroup(group);

                return CreatedAtRoute("GroupsById", new { id = group.GroupdId }, group);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(Guid id, [FromBody]Groups group)
        {
            try
            {
                if (group == null)
                {
                    _logger.LogError("group object sent from client is null.");
                    return BadRequest("group object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid group object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbgroup = _repository.Groups.GetGroupsById(id);
                if (dbgroup == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Groups.UpdateGroup(dbgroup, group);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(Guid id)
        {
            try
            {
                var group = _repository.Groups.GetGroupsById(id);
                if (group == null)
                {
                    _logger.LogError($"group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repository.Breeds.BreedsByGroups(id).Any())
                {
                    _logger.LogError($"Cannot delete group with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete group. It has related breeds. Delete those accounts first");
                }

                _repository.Groups.DeleteGroup(group);

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
