using System;
using ProjectSuperMarket.Data;
using Microsoft.WindowsAzure.StorageClient;
using System.ComponentModel.DataAnnotations;

namespace ProjectSuperMarket.Data.Azure
{
    public class Category : TableServiceEntity, ICategory
    {
        public Category()
        {
            this.PartitionKey = string.Empty;
            this.RowKey = Guid.NewGuid().ToString();            
        }

        [Required]
        public string Name { get; set; }
    }
}
