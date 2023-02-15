using System.Runtime.CompilerServices;
using democloudrobin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace democloudrobin.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HeroController : ControllerBase
	{

		private static List<Hero> _heroes = new List<Hero>()
		{
			new Hero(){Id=1, Name = "Tony Stark", Team = "Avengers", SuperHeroName = "Iron Man"},
			new Hero(){Id=2, Name = "Bruce Wayne", Team = "Justice League", SuperHeroName = "Batman"}
		};

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_heroes);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok(_heroes.FirstOrDefault(x => x.Id.Equals(id)));
		}

		[HttpPost]
		public IActionResult Add(Hero hero)
		{
			_heroes.Add(hero);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Update(Hero hero)
		{
			var heroToUpdate = _heroes.FirstOrDefault(x => x.Id == hero.Id);
			if (heroToUpdate == null)
			{
				return NotFound();
			}

			heroToUpdate.Name = hero.Name;
			heroToUpdate.Team = hero.Team;
			heroToUpdate.SuperHeroName = hero.SuperHeroName;
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var heroToDelete = _heroes.FirstOrDefault(x => x.Id == id);
			if (heroToDelete == null)
			{
				return NotFound();
			}

			_heroes.Remove(heroToDelete);
			return Ok();
		}
	}
}
