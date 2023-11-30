using BlogApp.DbContextData;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class ContentRepo
    {
        private readonly BlogAppDbContext _context;
        public ContentRepo(BlogAppDbContext context)
        {
            _context = context;
        }

        public async Task<Contents> AddContent(ContentDto req)
        {
            //Create ID
            var uniqueId = Guid.NewGuid().ToString();


            var payload = new Contents
            {
                Id = uniqueId,
                Author = req.Author,
                Title = req.Title,
                Image = req.Image,
                Summary = req.Summary,
                Description = req.Description
            };

            await _context.contents.AddAsync(payload);
            var AddUsers = _context.SaveChanges();
            return payload;
        }

        public async Task<List<Contents>> GetAllContents()
        {
            var AllContents = await _context.contents.ToListAsync();
            return AllContents;
        }

        public async Task<Contents> GetContent(string Id)
        {

            var SingleContent = _context.contents.FirstOrDefault(x => x.Id == Id);
            return SingleContent;
        }

        public async Task<Contents> UpdateContent(string Id, ContentDto req)
        {

            var SingleContent = _context.contents.FirstOrDefault(x => x.Id == Id);

            if (SingleContent == null)
            {
                SingleContent.Author = req.Author;
                SingleContent.Title = req.Title;
                SingleContent.Image = req.Image;
                SingleContent.Summary = req.Summary;
                SingleContent.Description = req.Description;
                _context.SaveChanges();
            }

            var NewContent = _context.contents.FirstOrDefault(x => x.Id == Id);

            return NewContent;
        }

        public async Task<String> DeleteContent(string Id)
        {

            var SingleContent = _context.contents.FirstOrDefault(x => x.Id == Id);

            if (SingleContent == null )
            {
                return "Record Not Found";
            }

            _context.contents.Remove(SingleContent);
            _context.SaveChanges();
            return "Deleted Successfully";
        }


    }
}
