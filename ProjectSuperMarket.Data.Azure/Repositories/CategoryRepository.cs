using System.Collections.Generic;
using System.Linq;
using ProjectSuperMarket.Data;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Data.Services.Client;
using Microsoft.WindowsAzure;

namespace ProjectSuperMarket.Data.Azure
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(ICategory category)
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            context.AddObject(context.CategoriesTableName, category);
            context.SaveChanges();
        }

        public void EditCategory(ICategory category)
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            context.UpdateObject(category);
            context.SaveChanges();
        }

        public void DeleteCategory(string id)
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            var categoryToDelete = (from c in context.Categories
                        where c.RowKey == id
                        select c).FirstOrDefault();

            context.DeleteObject(categoryToDelete);
            context.SaveChanges();

        }

        public ICategory GetCategory(string partitionKey, string rowKey)
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            partitionKey = partitionKey == null ? string.Empty : partitionKey;
            var query = from c in context.Categories
                        where c.PartitionKey == partitionKey && c.RowKey == rowKey
                        select c;
            return ProjectSuperMarketDataContext.GetSingleRecord<Category>(query);
        }

        public IEnumerable<ICategory> GetCategories(string partitionKey)
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            var query = from c in context.Categories
                        where c.PartitionKey == partitionKey
                        select c;
            return ProjectSuperMarketDataContext.GetMultipleRecords<Category>(query);
        }

        public IEnumerable<ICategory> GetCategories()
        {
            ProjectSuperMarketDataContext context = GetDataContext();
            return ProjectSuperMarketDataContext.GetMultipleRecords<Category>(context.Categories);
        }

        private static ProjectSuperMarketDataContext GetDataContext()
        {
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            ProjectSuperMarketDataContext context = new ProjectSuperMarketDataContext(account.TableEndpoint.ToString(), account.Credentials);
            return context;
        }


    }
}