using System;

namespace ProjectSuperMarket.Data
{
    public interface ICategory
    {
        string PartitionKey { get; set; }
        string RowKey { get; set; }
        string Name { get; set; }
    }
}
