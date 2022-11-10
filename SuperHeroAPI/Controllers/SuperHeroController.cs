﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero> {
                new SuperHero {
                    Id=1,
                    Name= "Spiderman",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(heroes);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);

        }
    }
}
