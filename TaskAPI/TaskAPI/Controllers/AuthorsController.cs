using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services.Authors;
using TaskAPI.Services.Models;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<AuthorDto>> GetAuthorsList(string job, string search) {
            var authors = _authorService.GetAuthorList(job, search);

            var mappedAuthors = _mapper.Map<ICollection<AuthorDto>>(authors);

            return Ok(mappedAuthors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _authorService.GetAuthor(id);

            return Ok(author);
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(CreateAuthorDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            var newAuthor = _authorService.CreateAuthor(authorEntity);

            var authorForReturn = _mapper.Map<AuthorDto>(newAuthor);

            return CreatedAtRoute("GetAuthor", new { id = authorForReturn.Id }, authorForReturn);
        }

        [HttpPut]
        public ActionResult UpdateAuthor(int authorId, UpdateAuthorDto author)
        {
            var updatingAuthor = _authorService.GetAuthor(authorId);

            if (updatingAuthor is null)
            {
                return NotFound();
            }

            _mapper.Map(author, updatingAuthor);
            _authorService.UpdateAuthor(updatingAuthor);
            return NoContent();
        }
    }
}
