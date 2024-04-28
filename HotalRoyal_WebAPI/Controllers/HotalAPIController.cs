using HotalRoyal_WebAPI.Data;
using HotalRoyal_WebAPI.Models;
using HotalRoyal_WebAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotalRoyal_WebAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class HotalAPIController : ControllerBase
    {
        private readonly ILogger<HotalAPIController> _logger;
        private readonly ApplicationDbContext _db;

        public HotalAPIController(ILogger<HotalAPIController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HotelDto>> GetHotels()
        {
            _logger.LogInformation("Getting all the Hotels");
            return Ok(_db.Hotels.ToList());
        }

        [HttpGet("Id",Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDto> GetHotel(int Id)
        {
            if(Id==0)
            {
                _logger.LogError("Get Hotel Error with Id = " + Id);
                return BadRequest();
            }
            var hotel = _db.Hotels.FirstOrDefault(u => u.Id == Id);
            if(hotel==null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HotelDto> CreateHotel(HotelDto hotelDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (hotelDto == null)
            {
                return BadRequest(hotelDto);
            }
            if (hotelDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Hotel model = new Hotel
            {
                Amenity = hotelDto.Amenity,
                Details = hotelDto.Details,
                Id = hotelDto.Id,
                ImageUrl = hotelDto.ImageUrl,
                Name = hotelDto.Name,
                Occupancy = hotelDto.Occupancy,
                Rate = hotelDto.Rate,
                Sqft = hotelDto.Sqft
            };
            _db.Hotels.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetHotel", new {id = hotelDto.Id},hotelDto);
        }

        [HttpDelete("Id",Name = "DeleteHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hotels.FirstOrDefault(u=>u.Id == id);  
            if (hotel == null)
            {
                return NotFound();
            }
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("Id", Name = "UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateHotel(int Id, [FromBody] HotelDto hotelDto)
        {
            if (hotelDto == null || Id != hotelDto.Id)
            {
                return BadRequest();
            }

            Hotel model = new Hotel
            {
                Amenity = hotelDto.Amenity,
                Details = hotelDto.Details,
                Id = hotelDto.Id,
                ImageUrl = hotelDto.ImageUrl,
                Name = hotelDto.Name,
                Occupancy = hotelDto.Occupancy,
                Rate = hotelDto.Rate,
                Sqft = hotelDto.Sqft
            };
            _db.Hotels.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("Id:int", Name = "UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialHotel(int Id, JsonPatchDocument<HotelDto> patchDto)
        {
            if (patchDto == null || Id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hotels.AsNoTracking().FirstOrDefault(u => u.Id == Id);

            HotelDto hotelDto = new()
            {
                Amenity = hotel.Amenity,
                Details = hotel.Details,
                Id = hotel.Id,
                ImageUrl = hotel.ImageUrl,
                Name = hotel.Name,
                Occupancy = hotel.Occupancy,
                Rate = hotel.Rate,
                Sqft = hotel.Sqft
            };
            if (hotel == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(hotelDto, ModelState);
            Hotel model = new Hotel
            {
                Amenity = hotelDto.Amenity,
                Details = hotelDto.Details,
                Id = hotelDto.Id,
                ImageUrl = hotelDto.ImageUrl,
                Name = hotelDto.Name,
                Occupancy = hotelDto.Occupancy,
                Rate = hotelDto.Rate,
                Sqft = hotelDto.Sqft,
            };
            _db.Hotels.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
