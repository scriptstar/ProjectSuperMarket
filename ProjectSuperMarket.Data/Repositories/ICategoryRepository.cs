using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSuperMarket.Data
{
    public interface ICategoryRepository
    {
        void AddCategory(ICategory category);
        IEnumerable<ICategory> GetCategories(string parentCategoryId);
        IEnumerable<ICategory> GetCategories();
        ICategory GetCategory(string partitionKey, string rowKey);
    }
}
