using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using IntelliTect.Coalesce;
using Microsoft.EntityFrameworkCore;

namespace MarsError.Data.Models
{
    public class Thing
    {
        public long ThingId { get; set; }

        public string Foo { get; set; }

        public string Bar { get; set; }


        public class FooSearchDataSource : StandardDataSource<Thing, AppDbContext>
        {
            public FooSearchDataSource(CrudContext<AppDbContext> context) : base(context)
            {
            }

            [Coalesce]
            public string FooPart { get; set; }

            [Coalesce]
            public string BarPart { get; set; }


            public override IncludeTree GetIncludeTree(IQueryable<Thing> query, IDataSourceParameters parameters)
            {
                return new IncludeTree();
            }


            public override IQueryable<Thing> ApplyListSearchTerm(IQueryable<Thing> query,
                IFilterParameters parameters)
            {
                var sql = new List<string> {"SELECT * FROM [dbo].[Things] WHERE 1=1"};

                var sqlParams = new List<SqlParameter>();

                if (false == string.IsNullOrWhiteSpace(FooPart))
                {
                    sql.Add("[Foo] LIKE '%' + @FooPart + '%' ");
                    sqlParams.Add(new SqlParameter("FooPart", FooPart));
                }

                if (false == string.IsNullOrWhiteSpace(BarPart))
                {
                    sql.Add("[Bar] LIKE '%' + @BarPart + '%' ");
                    sqlParams.Add(new SqlParameter("BarPart", BarPart));
                }

                return sql.Count == 1
                    ? Enumerable.Empty<Thing>().AsQueryable()
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
                    : query.FromSql(string.Join(" AND ", sql), sqlParams.Cast<object>().ToArray());
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
            }
        }
    }
}