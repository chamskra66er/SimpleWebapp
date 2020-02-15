using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarServise.Data
{
    public interface IImage
    {
        Image GetById(int id);
        IEnumerable<Image> GetAll();
        IEnumerable<Image> GetImagesByForm(int id);
        Task Add(Image image);
        Task Delete(int id);
    }
}
