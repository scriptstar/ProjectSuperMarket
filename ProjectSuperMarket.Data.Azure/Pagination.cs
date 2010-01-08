using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;

namespace ProjectSuperMarket.Data.Azure
{
    public class Pagination<T>
    {
        private DataServiceQuery<T> _query;

        public Pagination(DataServiceQuery<T> query)
        {
            _query = query;

        }
        public DataServiceQuery<T> GetQuery(string ct)
        {

            string[] tokens = ct.Split('/');
            var partitionToken = tokens[0];
            var rowToken = tokens[1];

            _query = _query.AddQueryOption("NextPartitionKey", partitionToken)
                         .AddQueryOption("NextRowKey", rowToken);

            return _query;
        }

        public string GetContinuation()
        {
            var res = _query.Execute();
            var qor = (QueryOperationResponse)res;
            string nextPartition = null;
            string nextRow = null;
            qor.Headers.TryGetValue("x-ms-continuation-NextPartitionKey", out nextPartition);
            qor.Headers.TryGetValue("x-ms-continuation-NextRowKey", out nextRow);

            string continuation = "";
            if (nextPartition != null && nextRow != null)
            {
                continuation = string.Format("{0}/{1}", nextPartition, nextRow);
            }

            return continuation;
        }

    }
}
