using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TodayTest.EntityFrameworkCore
{
    public static class TodayTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TodayTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TodayTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
