using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //var allAlbumsInfo = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(allAlbumsInfo);

            var allSongsAboveDuration = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(allSongsAboveDuration);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albumsInfo = context
                .Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToList(),
                    AlbumPrice = a.Price
                })
                .ToList();

            foreach (var a in albumsInfo.OrderByDescending(a => a.AlbumPrice))
            {
                int songCount = 1;
                output
                    .AppendLine($"-AlbumName: {a.AlbumName}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");

                foreach (var s in a.Songs)
                {
                    output
                        .AppendLine($"---#{songCount}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.SongPrice:f2}")
                        .AppendLine($"---Writer: {s.SongWriterName}");

                    songCount++;
                }

                output.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder output = new StringBuilder();

            var allSongs = context
                .Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}"),
                    ProduserName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToList();

            int songNumber = 1;
            foreach (var s in allSongs)
            {
                output
                    .AppendLine($"-Song #{songNumber}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");

                if (s.Performers != null)
                {
                    foreach (var p in s.Performers.OrderBy(p => p))
                    {
                        output.AppendLine($"---Performer: {p}");
                    }
                }

                output
                    .AppendLine($"---AlbumProducer: {s.ProduserName}")
                    .AppendLine($"---Duration: {s.Duration}");

                songNumber++;
            }

            return output.ToString().TrimEnd();
        }
    }
}
