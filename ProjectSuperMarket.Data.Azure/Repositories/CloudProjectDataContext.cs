using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.Data.Services.Client;
using System.Linq;
using System;

namespace ProjectSuperMarket.Data.Azure
{
    public class ProjectSuperMarketDataContext : TableServiceContext
    {
        public string CategoriesTableName { get { return "Categories"; } }
        public string PostedProjectsTableName { get { return "PostedProjects"; } }

        public ProjectSuperMarketDataContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return this.CreateQuery<Category>(CategoriesTableName);
            }
        }

        public IQueryable<PostedProject> PostedProjects
        {
            get
            {
                return this.CreateQuery<PostedProject>(PostedProjectsTableName);
            }
        }

        public static T GetSingleRecord<T>(IQueryable<T> query)
        {
            try
            {
                return query.FirstOrDefault();
            }
            catch (DataServiceQueryException ex)
            {
                if (ex.InnerException.Message.Contains("Resource not found"))
                {
                    return default(T);
                }

                throw;
            }
        }

        public static T[] GetMultipleRecords<T>(IQueryable<T> query)
        {
            try
            {
                return query.ToArray();
            }
            catch (DataServiceQueryException ex)
            {
                if (ex.InnerException.Message.Contains("Resource not found"))
                {
                    return new T[0];
                }

                throw;
            }
        }
    }
}
