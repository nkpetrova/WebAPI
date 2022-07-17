using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route( "rest/{controller}")]
    public class TurfirmaController : ControllerBase
    {
        private readonly ITurfirmaService _turfirmaService;

        public TodoController(ITurfirmaService turfirmaService)
        {
            _turfirmaService = turfirmaService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetTurfirmas()
        {
            try
            {
                return Ok( _turfirmaService.GetTurfirmas()
                    .ConvertAll( t => t.ConvertToTurfirmaDto() ) );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpGet]
        [Route( "{turfirmaId}" )]
        public IActionResult GetTurfirmaById( int turfirmaId )
        {
            try
            {
                return Ok( _turfirmaService.GetTurfirmaById(turfirmaId).ConvertToTurfirmaDto() );
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpPost]
        [Route( "create" )]
        public IActionResult CreateTurfirma( [FromBody] TurfirmaDto turfirma )
        {
            try
            {
                return Ok( _turfirmaService.CreateTurfirma(turfirma) );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpDelete]
        [Route( "{turfirmaId}/delete" )]
        public IActionResult DeleteTodo( int turfirmaId )
        {
            try
            {
                _turfirmaService.DeleteTurfirma(turfirmaId);
                return Ok();
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateTurfirma([FromBody] TurfirmaDto turfirma)
        {
            try
            {
                return Ok( _turfirmaService.UpdateTurfirma(turfirma));
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpGet]
        [Route("count_by_address")]
        public IActionResult GroupByAddress()
        {
            try
            {
                return Ok(_turfirmaService.GroupByAddress());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
