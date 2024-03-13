using AutoMapper;
using BlazorFullStackCRUD_Patrick.Server.Entity;
using BlazorFullStackCRUD_Patrick.Server.Repository.Interface;
using BlazorFullStackCRUD_Patrick.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCRUD_Patrick.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComicController : ControllerBase
	{
		IMapper _mapper;
		IComicRepository _comicRepository;

		public ComicController(IMapper mapper, IComicRepository comicRepository)
		{
			_mapper = mapper;
			_comicRepository = comicRepository;
		}

		[HttpGet("GetComics")]
		public async Task<ActionResult<List<ComicDTO>>> GetComics()
		{
			IEnumerable<Comic> comicList = await _comicRepository.GetComics();
			return Ok(comicList.Select(comic => _mapper.Map<ComicDTO>(comic)).ToList());
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<Comic>> GetComic(int id)
		{
			Comic comic = await _comicRepository.GetComic(id);
			if (comic == null)
			{
				return NotFound("Sorry Comic not found");
			}
			return Ok(_mapper.Map<ComicDTO>(comic));
		}
	}
}
