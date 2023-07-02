using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Contracts;
using WebShop.Data;
using WebShop.Models.Articles;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesController(IMapper mapper, IArticlesRepository articlesRepository)
        {
            _mapper = mapper;
            _articlesRepository = articlesRepository;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articles = await _articlesRepository.GetAllAsync();

            var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
            return Ok(articleDtos);
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _articlesRepository.GetDetails(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleDto = _mapper.Map<ArticleDto>(article);

            return Ok(articleDto);
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutArticle(int id, UpdateArticleDto updateArticleDto)
        {
            if (id != updateArticleDto.Id)
            {
                return BadRequest("Invalid Article Id");
            }

            var article = await _articlesRepository.GetAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            _mapper.Map(updateArticleDto, article);

            try
            {
                await _articlesRepository.UpdateAsync(article);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArticleExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Article>> PostArticle(CreateArticleDto createArticle)
        {
            var article = _mapper.Map<Article>(createArticle);

            await _articlesRepository.AddAsync(article);

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _articlesRepository.GetAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            await _articlesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ArticleExists(int id)
        {
            return  await _articlesRepository.Exists(id);
        }
    }
}
