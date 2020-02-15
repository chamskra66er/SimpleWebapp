using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarServise.Data;
using CarServise.Data.Models;

namespace CarServise.Service
{
    public class ImageService : IImage
    {
        private readonly ApplicationDbContext _context;
        public ImageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Add(Image image)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAll()
        {
            throw new NotImplementedException();
        }

        public Image GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetImagesByForm(int id)
        {
            return _context.Forums
                .Where(f => f.Id == id).First().ImageUrl;
        }
    }
}
