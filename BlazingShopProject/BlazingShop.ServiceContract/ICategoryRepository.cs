using Blazingshop.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.ServiceContract
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetByid(int id);

        Category UpdateCategory(int id, Category category);
        Category DeleteCategory(int id);

        Category InsertCategory(Category c);
    }
}
