using Microsoft.AspNetCore.Mvc;
using PTVGroupRepository.Requests;
using PTVGroupService.Interfaces;
using PTVGroupsWebApi.Requests;

namespace PTVGroupsWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly IStreetService _streetService;

        public StreetController(IStreetService streetService)
        {
            this._streetService = streetService;
        }

        [HttpGet]
        [Route("GetStreets")]
        public IActionResult GetStreetDetails()
        {
            try
            {
                var streets =_streetService.GetStreetDetails();
                return Ok(streets);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetStreetById")]
        public IActionResult GetStreetById(int id)
        {
            try
            {
                var streets = _streetService.GetStreetById(id);
                return Ok(streets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostStreetData")]
        public IActionResult PostStreetData(StreetPostRequest streetModel)
        {
            try
            {
                _streetService.PostStreet(streetModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStreetData/{streetId}")]
        public IActionResult UpdateStreetData(StreetPutRequest streetModel, int streetId)
        {
            try
            {
                _streetService.UpdateStreetData(streetModel, streetId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStreetData/{id}")]
        public IActionResult DeleteStreetData(int id)
        {
            try
            {
                _streetService.DeleteStreet(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
