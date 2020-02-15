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
    using System.Diagnostics;
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
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            SeedUser().GetAwaiter().GetResult();
            using (var reader = new StreamReader(@"C:\Users\klyub\Desktop\Projects\Open-Lyrics\server\src\Sandbox\songdata.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<LyricModel>().ToList();
                SeedLyrics(records).GetAwaiter().GetResult();
            }
            Console.WriteLine("Finished seeding database.");
            Console.ReadLine();
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
            int takeCount = 2000;
            int batchNumber = 0;
            Console.Write("Loading");
            var sw = new Stopwatch();
            sw.Start();
            while (counter <= records.Count())
            {
                var lyricsToAdd = records
                                    .Skip(batchNumber * takeCount)
                                    .Take(takeCount)
                                    .Select(item => new CreateLyricInput { Singer = item.artist, Text = item.text, Title = item.song, AuthorName = author.Username });

                await usecase.HandleAsync(lyricsToAdd.ToList(), new CreateLyricOutputHandlerStub());
                counter += takeCount;
                batchNumber += 1;
            }
            

            sw.Stop();
            Console.WriteLine($"Added 2000 records in {sw.ElapsedMilliseconds}ms");
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
