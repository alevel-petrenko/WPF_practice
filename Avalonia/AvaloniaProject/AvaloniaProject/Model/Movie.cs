﻿using System.Drawing;
using System.Text.Json.Serialization;

namespace AvaloniaProject.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public int VoteCount { get; set; }
        public string PosterPath { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }

        [JsonIgnore]
        public Bitmap Poster { get; set; }
    }
}