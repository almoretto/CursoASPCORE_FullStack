using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.DataModels;
using ProAgil.Repository;

namespace ProAgilWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {
        private readonly IProAgilRepository _repository;
        public EventController(IProAgilRepository repository)
        { _repository = repository; }

        #region --== HTTP Get (Read) ==--
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetEventsAsync(true);

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }
        [HttpGet("{id}")] //Parameter have to be same as DB
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _repository.GetEventByIdAsync(id, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }

        [HttpGet("getBySubject/{subject}")] //Parameter have to be same as DB
        public async Task<IActionResult> Get(string subject)
        {
            try
            {
                var results = await _repository.GetEventsBySubjectAsync(subject, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }
        #endregion

        #region --== HTTP Post (Create) ==--
        [HttpPost]
        public async Task<IActionResult> Post(Event eventToAdd)
        {
            try
            {
                _repository.Add(eventToAdd);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{eventToAdd.Id}", eventToAdd);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
            return BadRequest();
        }
        #endregion

        #region --== HTTP Put (Update) ==--
        [HttpPut]
        public async Task<IActionResult> Put(int eventId, Event eventToUpdate)
        {
            try
            {
                var eventToFind = await _repository.GetEventByIdAsync(eventId, false);

                if (eventToFind == null) { return NotFound(); }

                _repository.Update(eventToUpdate);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{eventToUpdate.Id}", eventToUpdate);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
            return BadRequest();
        }
        #endregion

        #region --== HTTP Delete (Delete) ==--
        [HttpDelete]
        public async Task<IActionResult> Delete(int eventId)
        {
            try
            {
                var eventToDelete = await _repository.GetEventByIdAsync(eventId, false);

                if (eventToDelete == null) { return NotFound(); }

                _repository.Delete(eventToDelete);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
            return BadRequest();
        }
        #endregion
    }
}