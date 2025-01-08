using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Authors
{
    public interface IAuthorService
    {
        public List<Author> GetAuthorList(string job, string search);
        public Author GetAuthor(int id);
        public Author CreateAuthor(Author author);
        public void UpdateAuthor(Author author);
    }
}
