namespace Sandbox
{
    using Application.UseCases.Lyrics.Create;
    using Application.UseCases.User.Register;
    using CsvHelper;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using Persistence.Repositories;
    using Sandbox.Models;
    using Sandbox.Stubs;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    internal class Seeder
    {
        private const string Username = "admin";
        private static LyricsDbContext db;
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LyricsDbContext>();
            optionsBuilder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB; database=LyricsDB; Integrated Security=true");
            db = new LyricsDbContext(optionsBuilder.Options);
            SeedUser().GetAwaiter().GetResult();
            using (var reader = new StreamReader(@"C:\Users\klyub\Desktop\Projects\Open-Lyrics\server\src\Sandbox\songdata.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<LyricModel>();
                SeedLyrics(records).GetAwaiter().GetResult();
            }
        }

        private static async Task SeedLyrics(IEnumerable<LyricModel> records)
        {
            if (db.Lyrics.Count() > 5)
            {
                Console.WriteLine("There are already seeded lyrics.");
                return;
            }
            Console.WriteLine("Seeding Lyrics....");
            var userRepo = new UserEfRepository(db);
            var author = await userRepo.GetByUsernameAsync(Username);
            var lyricsRepo = new LyricEfRepository(db);
            var usecase = new CreateLyricUseCase<Action>(userRepo, lyricsRepo);
            int counter = 0;
            Console.Write("Loading");
            foreach (var item in records)
            {
                if (counter % 100 == 0)
                {
                    Console.Write(".");
                }
                await usecase.HandleAsync(new CreateLyricInput { Singer = item.artist, Text = item.text, Title = item.song, AuthorId = author.Id }, new CreateLyricOutputHandlerStub());
                counter += 1;
            }
        }

        private static async Task SeedUser()
        {
            if (db.Users.Any(x => x.Username == Username))
            {
                Console.WriteLine($"User '{Username}' already exists");
                return;
            }
            Console.WriteLine("Seeding User....");
            var repository = new UserEfRepository(db);
            var userUsecase = new RegisterUseCase<Action>(repository);

            await userUsecase.HandleAsync(new RegisterUserInput("Kris", "Lyubenov", Username, "admin@mysite.com", "Test321"), new RegisterOutputHandlerStub());
        }
    }
}
