using Crazy_Musicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Crazy_Musicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private static List<Musician> _musicians = new List<Musician>()
        {
        new Musician { Id = 1, Name = "Ahmet Çalgı", Career = "Famous Instrument Player", FunnyProperty = "He always plays the wrong note, but it's very entertaining" },
        new Musician { Id = 2, Name = "Zeynep Melodi", Career = "Popular Melody Writer", FunnyProperty = "Her songs are often misunderstood, but very popular" },
        new Musician { Id = 3, Name = "Cemil Akor", Career = "Crazy Chordist", FunnyProperty = "He frequently changes chords, but is surprisingly talented" },
        new Musician { Id = 4, Name = "Fatma Nota", Career = "Surprise Note Producer", FunnyProperty = "She always prepares surprises while producing notes" },
        new Musician { Id = 5, Name = "Hasan Ritim", Career = "Rhythm Monster", FunnyProperty = "He plays every rhythm in his own way, it's out of sync but funny" },
        new Musician { Id = 6, Name = "Elif Armoni", Career = "Master of Harmony", FunnyProperty = "Sometimes she plays harmonies wrong, but very creative" },
        new Musician { Id = 7, Name = "Ali Perde", Career = "Curtain Performer", FunnyProperty = "He plays every curtain differently, always surprising" },
        new Musician { Id = 8, Name = "Ayşe Rezonans", Career = "Resonance Expert", FunnyProperty = "An expert on resonance, but sometimes makes too much noise" },
        new Musician { Id = 9, Name = "Murat Ton", Career = "Tone Enthusiast", FunnyProperty = "The differences in his tones are sometimes funny, but quite interesting" },
        new Musician { Id = 10, Name = "Selin Akor", Career = "Chord Wizard", FunnyProperty = "When she changes chords, sometimes it creates a magical atmosphere" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_musicians);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            var musicians = _musicians.FirstOrDefault(x => x.Id == id);

            if (musicians is null)
                return NotFound();

            return Ok(musicians);
        }
        [HttpGet("search-by-name")]
        public IActionResult SearchMusicians([FromQuery] string name)
        {
            var filteredMusicians = _musicians.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(filteredMusicians);
        }

        [HttpPost("create-musician")]
        public IActionResult Create([FromBody] Musician musician)
        {
            var id = _musicians.Max(x => x.Id) + 1;
            musician.Id = id;

            _musicians.Add(musician);

            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }

        [HttpPut("update/{id:int:min(1)}/{newMusician}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician newMusician)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician is null)
                return NotFound();

            musician.Name = newMusician.Name;
            musician.Career = newMusician.Career;
            musician.FunnyProperty = newMusician.FunnyProperty;

            return NoContent();
        }

        [HttpDelete("delete/{id:int:min(1)}")]
        public IActionResult DeleteMusician(int id)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if(musician is null)
                return NotFound();

            _musicians.Remove(musician);

            return Ok(musician);
        }

        [HttpPatch("reschedule/{id:int:min(1)}/career")]
        public IActionResult NewCareerMusician(int id, [FromBody] JsonPatchDocument<Musician> patchDocument)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if(musician is null)
                return NotFound();

            patchDocument.ApplyTo(musician);

            return NoContent();
        }




    }
}
