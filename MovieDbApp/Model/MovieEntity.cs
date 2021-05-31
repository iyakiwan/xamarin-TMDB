using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Model
{
    public class MovieEntity
    {
        [PrimaryKey]
        public int MovieId { get; set; }

        public bool Adult { get; set; }

        public string BackdropPath { get; set; }
        
        public string OriginalLanguage { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string ReleaseDate { get; set; }

        public string Title { get; set; }

        public double VoteAverage { get; set; }
    }
}
