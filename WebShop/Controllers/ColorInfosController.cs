using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebShop.Contracts;
using WebShop.Data;
using WebShop.Models.ColorInfo;
using WebShop.Repository;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorInfosController : ControllerBase
    {
        private readonly IColorInfosRepository _colorInfosRepository;
        private readonly IArticlesRepository _articlesRepository;
        private readonly IMapper _mapper;

        public ColorInfosController( IColorInfosRepository colorInfosRepository, IArticlesRepository articlesRepository, IMapper mapper)
        {
            _colorInfosRepository = colorInfosRepository;
            _articlesRepository = articlesRepository;
            _mapper = mapper;
        }

        // GET: api/ColorInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorInfoDto>>> GetColorInfos()
        {
            var colorInfos = await _colorInfosRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ColorInfoDto>>(colorInfos));
        }

        // GET: api/ColorInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorInfoDto>> GetColorInfo(int id)
        {
            var colorInfo = await _colorInfosRepository.GetDetails(id); ;

            if (colorInfo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ColorInfoDto>(colorInfo));
        }

        // PUT: api/ColorInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutColorInfo(int id, UpdateColorInfoDto colorInfoDto)
        {
            if (id != colorInfoDto.Id)
            {
                return BadRequest();
            }

            var colorInfo = await _colorInfosRepository.GetAsync(id);
            if (colorInfo == null)
            {
                return NotFound();
            }

            _mapper.Map(colorInfoDto, colorInfo);

            try
            {
                await _colorInfosRepository.UpdateAsync(colorInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ColorInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ColorInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ColorInfo>> PostColorInfo(CreateColorInfoDto colorInfoDto)
        {
            var article = await _articlesRepository.GetAsync(colorInfoDto.ArticleId);

            if (article == null)
            {
                return NotFound("Article not found.");
            }

            var colorInfo = _mapper.Map<ColorInfo>(colorInfoDto);
            await _colorInfosRepository.AddAsync(colorInfo);

            return CreatedAtAction("GetColorInfo", new { id = colorInfo.Id }, colorInfo);
        }

        // DELETE: api/ColorInfoes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteColorInfo(int id)
        {
            var colorInfo = await _colorInfosRepository.GetAsync(id);
            if (colorInfo == null)
            {
                return NotFound();
            }

            await _colorInfosRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ColorInfoExists(int id)
        {
            return await _colorInfosRepository.Exists(id);
        }
    }
}
