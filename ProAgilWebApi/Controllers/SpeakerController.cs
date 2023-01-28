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

    public class SpeakerController : ControllerBase
    {
        private readonly IProAgilRepository _repository;
        public SpeakerController(IProAgilRepository repository)
        { _repository = repository; }

        #region --== HTTP Get (Read) ==--
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetSpeakersAsync(true);
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
                var results = await _repository.GetSpeakerByIdAsync(id, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }
        #endregion

        #region --== HTTP Put (Update) ==--
        [HttpPut]
        public async Task<IActionResult> Put(int speakerId, Speaker speakerToUpdate)
        {
            try
            {
                var speakerToFind = await _repository.GetSpeakerByIdAsync(speakerId, false);

                if (speakerToFind == null) { return NotFound(); }

                _repository.Update(speakerToUpdate);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{speakerToUpdate.Id}", speakerToUpdate);
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
        public async Task<IActionResult> Delete(int speakerId)
        {
            try
            {
                var speakerToDelete = await _repository.GetSpeakerByIdAsync(speakerId, false);

                if (speakerToDelete == null) { return NotFound(); }

                _repository.Delete(speakerToDelete);

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