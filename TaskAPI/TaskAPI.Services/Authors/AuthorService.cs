using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.DataAccess;
using TaskAPI.Models;

namespace TaskAPI.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly TodoDbContext _context;

        public AuthorService(TodoDbContext todoDbContext)
        {
            _context = todoDbContext;
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.Find(id);
        }

        public List<Author> GetAuthorList(string job, string search)
        {
            if (string.IsNullOrWhiteSpace(job) && string.IsNullOrWhiteSpace(search))
            {
                return GetAllAuthors();
            }

            var authorCollection = _context.Author as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(job))
            {
                job = job.Trim();
                authorCollection = authorCollection.Where(x => x.JobRole == job);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                authorCollection = authorCollection.Where(x => x.FullName.Contains(search) || x.City.Contains(search));
            }

            return authorCollection.ToList();
        }

        public Author CreateAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return _context.Author.Find(author.Id);
        }

        public void UpdateAuthor(Author author)
        {
            _context.SaveChanges();
        }
    }
}
