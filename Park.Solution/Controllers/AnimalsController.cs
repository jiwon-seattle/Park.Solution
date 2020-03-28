using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Park.Models;
using Microsoft.EntityFrameworkCore;

namespace Park.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private ParkContext _db;

        public AnimalsController(ParkContext db)
        {
            _db = db;
        }

        //GET api/animals/
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(string species, string gender, string name)
        {
            var query = _db.Animals.AsQueryable();

            if (species != null)
            {
                query = query.Where(entry => entry.Species == species);
            }

            if (gender != null)
            {
                query = query.Where(entry => entry.Gender == gender);
            }
            
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }

            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}