using AvaloniaProject.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaProject.Services
{
    public class MovieService
    {
        readonly string _workingDirectory = Environment.CurrentDirectory;

        public async Task<IEnumerable<Movie>> GetMovies(int pageIndex)
        {
            string folderPath = $"{_workingDirectory}\\Data\\Page{pageIndex}";
            string dataFile = $"page{pageIndex}.json";
            string imageFolder = Path.Combine(folderPath, "Images");
            IEnumerable<Movie> movies;

            using (var reader = new StreamReader(Path.Combine(folderPath, dataFile)))
            {
                string json = reader.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            foreach (Movie movie in movies)
            {
                string imagePath = Path.Combine(imageFolder, $"{movie.Title}.png");
                movie.Poster = await GetPoster(imagePath);
            }

            return movies;
        }

        private Task<Bitmap> GetPoster(string posterUrl)
        {
            return Task.Run(() =>
            {
                using(var fileStream = new FileStream(posterUrl, FileMode.Open, FileAccess.Read) { Position = 0 })
                {
                    var bitmap = new Bitmap(fileStream);
                    return bitmap;
                }
            });
        }
    }
}