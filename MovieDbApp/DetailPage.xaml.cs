using MovieDbApp.Model;
using MovieDbApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private bool fav = false;
        private Result result = null;
        private MovieEntity movie = null;
        public DetailPage(Result data)
        {
            InitializeComponent();
            Title = data.Title;

            result = data;
            BindingContext = data;
        }

        public DetailPage(MovieEntity data)
        {
            InitializeComponent();
            Title = data.Title;

            fav = true;
            btnFav.Source = "fav_logo.png";
            movie = data;
            BindingContext = data;
        }

        protected override void OnAppearing()
        {
            if (result != null)
            {
                var data = App.DBUtils.GetMovieById(result.Id);
                //Console.WriteLine("Testing wes:" + data.ToString());
                if(data.Count() > 0)
                {
                    fav = true;
                    btnFav.Source = "fav_logo.png";
                    movie = data.ElementAt(0);
                }
            }
        }

        protected override void OnDisappearing()
        {

        }

        private async void ClickFav(object sender, EventArgs e)
        {
            if (fav)
            {
                var result = await DisplayAlert("Konfirmasi", "Apakah anda ingin menghapus movie ini ? ", "Yes", "No");
                if (result)
                {
                    App.DBUtils.DeleteMovie(movie);
                    btnFav.Source = "fav_out_logo.png";
                    DependencyService.Get<IMessage>().ShortAlert("Data berhasil dihapus");
                    fav = !fav;
                }
            }
            else
            {
                onSave();
                btnFav.Source = "fav_logo.png";
                DependencyService.Get<IMessage>().ShortAlert("Data berhasil disimpan");
                fav = !fav;
            }
            
        }

        private void onSave()
        {
            if (movie == null)
            {
                var newMovie = new MovieEntity()
                {
                    MovieId = result.Id,
                    Adult = result.Adult,
                    BackdropPath = result.BackdropPath,
                    OriginalLanguage = result.OriginalLanguage,
                    Overview = result.Overview,
                    Popularity = result.Popularity,
                    PosterPath = result.PosterPath,
                    ReleaseDate = result.ReleaseDate,
                    Title = result.Title,
                    VoteAverage = result.VoteAverage
                };
                App.DBUtils.SaveMovie(newMovie);
                movie = newMovie;
            }
            else
            {
                App.DBUtils.SaveMovie(movie);
            }
            
        }
    }
}