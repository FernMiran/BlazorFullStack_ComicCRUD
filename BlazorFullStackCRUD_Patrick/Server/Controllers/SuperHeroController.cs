using Microsoft.AspNetCore.Mvc;
using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Shared.DTO;
using AutoMapper;
using BlazorFullStackCRUD_Patrick.Server.Repository.Interface;

namespace BlazorFullStackCRUD_Patrick.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISuperHeroRepository _superHeroRepository;

        public SuperHeroController(IMapper mapper, ISuperHeroRepository superHeroRepository)
        {
            _mapper = mapper;
            _superHeroRepository = superHeroRepository;
        }

        [HttpGet("GetSuperHeroes")]
		public async Task<ActionResult<List<SuperHeroDTO>>> GetSuperHeroes()
        {
            IEnumerable<SuperHero> heroList = await _superHeroRepository.GetSuperHeroes();
            return Ok(heroList.Select(hero => _mapper.Map<SuperHeroDTO>(hero))
				.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHeroDTO>> GetSingleHero(int id)
        {
            SuperHero hero = await _superHeroRepository.GetSuperHeroById(id);
            if (hero == null)
            {
                return NotFound("Sorry SuperHero not found");
            }
            return Ok(_mapper.Map<SuperHeroDTO>(hero));
        }

		[HttpPost]
		public async Task<ActionResult<SuperHeroDTO>> CreateSuperHero(CreateSuperHeroDTO createSuperHeroDTO)
		{
			var superHero = _mapper.Map<SuperHero>(createSuperHeroDTO);
			await _superHeroRepository.CreateSuperHero(superHero);

			return Ok(_mapper.Map<SuperHeroDTO>(superHero));
		}

		[HttpPut("{id}")]
        public async Task<ActionResult<SuperHeroDTO>> UpdateSuperHero(SuperHeroDTO superHeroDTO, int id)
        {
            SuperHero dbSuperHero = await _superHeroRepository.GetSuperHeroById(id);
            if (dbSuperHero == null)
            {
                return NotFound("Sorry SuperHero not found");
            }
            var superHero = _mapper.Map<SuperHero>(superHeroDTO);
			//await _superHeroRepository.AddSuperHero(superHero);
			
            return Ok(_mapper.Map<SuperHeroDTO>(superHero));
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult<SuperHeroDTO>> DeleteSuperHero(int id)
		{
			SuperHero dbSuperHero = await _superHeroRepository.GetSuperHeroById(id);
			if (dbSuperHero == null)
			{
				return NotFound("Sorry SuperHero not found");
			}
            await _superHeroRepository.DeleteSuperHero(id);
			return Ok(_mapper.Map<SuperHeroDTO>(dbSuperHero));
		}
	}
}
