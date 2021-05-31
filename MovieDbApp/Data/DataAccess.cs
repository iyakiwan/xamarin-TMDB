using MovieDbApp.Model;
using Plugin.NetStandardStorage.Abstractions.Interfaces;
using Plugin.NetStandardStorage.Implementations;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieDbApp.Data
{
    public class DataAccess
    {
        SQLiteConnection database;
        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqliteConnection;
            var sqliteFileName = "MyMovieDb.db3";
            IFolder folder = new FileSystem().LocalStorage;
            string path = Path.Combine(folder.FullPath, sqliteFileName);
            sqliteConnection = new SQLiteConnection(path);
            return sqliteConnection;
        }
        public DataAccess()
        {
            database = GetConnection();
            database.CreateTable<MovieEntity>();
        }
        public IEnumerable<MovieEntity> GetAllMovies()
        {
            return database.Query<MovieEntity>("select * from MovieEntity order by Title");
        }

        public IEnumerable<MovieEntity> GetMovieById(int id)
        {
            return database.Query<MovieEntity>("select * from MovieEntity where MovieId = ?", id);
        }

        public int SaveMovie(MovieEntity movie)
        {
            return database.Insert(movie);
        }

        public int DeleteMovie(MovieEntity movie)
        {
            return database.Delete(movie);
        }
        public int EditMovie(MovieEntity movie)
        {
            return database.Update(movie);
        }
    }
}
