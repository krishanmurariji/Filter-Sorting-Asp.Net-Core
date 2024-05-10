using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TodayTest.Authorization.Roles;
using TodayTest.Authorization.Users;
using TodayTest.MultiTenancy;
using TodayTest.Models;

namespace TodayTest.EntityFrameworkCore
{
    public class TodayTestDbContext : AbpZeroDbContext<Tenant, Role, User, TodayTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TodayTestDbContext(DbContextOptions<TodayTestDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserDetails> UserDetailsTable { get; set; }
    }
}
