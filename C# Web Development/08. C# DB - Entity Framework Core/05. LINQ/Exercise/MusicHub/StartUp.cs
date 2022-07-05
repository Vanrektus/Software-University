using MusicHub.Data;
using MusicHub.Data.Models;
using MusicHub.Initializer;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);

            // 02. - Albums Info
            // Console.WriteLine(ExportAlbumsInfo(context, 9));

            // 03. - Songs Above Duration
            // Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        // 02. - Albums Info
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            Producer producer = context.Producers.Find(producerId);

            var albums = producer.Albums
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    AlbumPrice = x.Price,
                    Songs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        Price = x.Price,
                        Writer = x.Writer.Name,
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.Writer)
                    .ToList()
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currAlbum in albums)
            {
                sb.AppendLine($"-AlbumName: {currAlbum.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {currAlbum.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {currAlbum.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songCount = 1;

                foreach (var currSong in currAlbum.Songs)
                {
                    sb.AppendLine($"---#{songCount++}");
                    sb.AppendLine($"---SongName: {currSong.SongName}");
                    sb.AppendLine($"---Price: {currSong.Price:f2}");
                    sb.AppendLine($"---Writer: {currSong.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {currAlbum.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 03. - Songs Above Duration
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration,
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int songCount = 1;

            foreach (var currSong in songs)
            {
                sb.AppendLine($"-Song #{songCount++}");
                sb.AppendLine($"---SongName: {currSong.SongName}");
                sb.AppendLine($"---Writer: {currSong.Writer}");
                sb.AppendLine($"---Performer: {currSong.Performer}");
                sb.AppendLine($"---AlbumProducer: {currSong.AlbumProducer}");
                sb.AppendLine($"---Duration: {currSong.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}