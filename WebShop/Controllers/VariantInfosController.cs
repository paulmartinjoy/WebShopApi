using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Contracts;
using WebShop.Data;
using WebShop.Models.ColorInfo;
using WebShop.Models.VariantInfo;
using WebShop.Repository;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantInfosController : ControllerBase
    {
        private readonly IVariantInfosRepository _variantInfosRepository;
        private readonly IColorInfosRepository _colorInfosRepository;
        private readonly IMapper _mapper;

        public VariantInfosController(IVariantInfosRepository variantInfosRepository, IColorInfosRepository colorInfosRepository, IMapper mapper)
        {
            _variantInfosRepository = variantInfosRepository;
            _colorInfosRepository = colorInfosRepository;
            _mapper = mapper;
        }

        // GET: api/VariantInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariantInfoDto>>> GetVariantInfos()
        {
            var variantInfos = await _variantInfosRepository.GetAllAsync();
            return Ok(_mapper.Map<List<VariantInfoDto>>(variantInfos));
        }

        // GET: api/VariantInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VariantInfoDto>> GetVariantInfo(int id)
        {
            var variantInfo = await _variantInfosRepository.GetAsync(id);

            if (variantInfo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VariantInfoDto>(variantInfo));
        }

        // PUT: api/VariantInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> PutVariantInfo(int id, VariantInfoDto variantInfoDto)
        {
            if (id != variantInfoDto.Id)
            {
                return BadRequest();
            }

            var variantInfo = await _variantInfosRepository.GetAsync(id);
            if (variantInfo == null)
            {
                return NotFound();
            }

            _mapper.Map(variantInfoDto, variantInfo);

            try
            {
                await _variantInfosRepository.UpdateAsync(variantInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VariantInfoExists(id))
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

        // POST: api/VariantInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<VariantInfo>> PostVariantInfo(CreateVariantInfoDto variantInfoDto)
        {
            var colorInfo = await _colorInfosRepository.GetAsync(variantInfoDto.ColorInfoId);
            if (colorInfo == null)
            {
                return NotFound("Color info not found.");
            }

            var variantInfo = _mapper.Map<VariantInfo>(variantInfoDto);
            await _variantInfosRepository.AddAsync(variantInfo);

            return CreatedAtAction("GetVariantInfo", new { id = variantInfo.Id }, variantInfo);
        }

        // DELETE: api/VariantInfoes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteVariantInfo(int id)
        {
            var variantInfo = await _variantInfosRepository.GetAsync(id);
            if (variantInfo == null)
            {
                return NotFound();
            }

            await _variantInfosRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> VariantInfoExists(int id)
        {
            return await _variantInfosRepository.Exists(id);
        }
    }
}
