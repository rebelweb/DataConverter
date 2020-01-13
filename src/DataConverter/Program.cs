using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataConverter
{
    class Program
    {
        static string NpgsqlConnectionString => Environment.GetEnvironmentVariable("PSQL_CONN");

        static string SqlServerConnectionString => Environment.GetEnvironmentVariable("MSSQL_CONN");

        static async Task Main(string[] args)
        {
            Console.WriteLine("Converting Data");

            List<User> users = await RetrieveUsers();
            await WriteUsers(users);
        }

        static async Task<List<User>> RetrieveUsers()
        {
            DbContextOptions opts = new DbContextOptionsBuilder()
                .UseNpgsql(NpgsqlConnectionString)
                .Options;

            List<User> users;

            using (var context = new DataConverterContext(opts))
            {
                users = await context.Users.ToListAsync();
            }

            return users;
        }

        static async Task<int> WriteUsers(List<User> users)
        {
            DbContextOptions opts = new DbContextOptionsBuilder()
                .UseSqlServer(SqlServerConnectionString)
                .Options;

            using (var context = new DataConverterContext(opts))            
            {
                context.AddRange(users);
                await context.SaveChangesAsync();
            }
            
            return 0;
        }
    }
}
