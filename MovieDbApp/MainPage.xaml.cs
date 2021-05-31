using MovieDbApp.Model;
using MovieDbApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using Xamarin.Forms;

namespace MovieDbApp
{
    public partial class MainPage : ContentPage
    {
        RestService restService;
        int page = 0;

        public MainPage()
        {
            InitializeComponent();
            
            Title = "The Movie DB";

            restService = new RestService();

            CondtionPagging();

            btnPrev.IsEnabled = false;
            btnNext.IsEnabled = false;

            //Task.Run(() => { OnLoadData("1"); }).Wait();
            //label.Text = GenerateRequest(Constants.Endpoint, "/movie/popular", "1");
            Console.WriteLine(GenerateRequest(Constants.Endpoint, "/movie/popular", "1"));
        }

        protected override void OnAppearing()
        {
            page = 1;
            OnLoadMovieData();
        }

        async void OnLoadMovieData()
        {
            loadingDataMovie.IsVisible = true;

            //btnGetData.Text = GenerateRequest(Constants.Endpoint, "/movie/popular", "1");
            //BindingContext = await restService.GetMovieData(GenerateRequest(Constants.Endpoint, "/movie/popular", "1"));
            MovieData movie = await restService.GetMovieData(GenerateRequest(Constants.Endpoint, "/movie/popular", page.ToString()));
            listMovie.ItemsSource = movie.Results;

            loadingDataMovie.IsVisible = false;

            btnNext.IsEnabled = true;

            CondtionPagging();
        }

        private async void OnClickFav(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritePage());
        }

        private void OnClickNext(object sender, EventArgs e)
        {
            page++;
            OnLoadMovieData();
        }

        private void OnClickPrev(object sender, EventArgs e)
        {
            page--;
            OnLoadMovieData();
        }

        void CondtionPagging()
        {
            if(page <= 1)
            {
                btnPrev.IsEnabled = false;
            }
            else
            {
                btnPrev.IsEnabled = true;
            }
            textPagging.Text = page.ToString();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Result item = (Result)e.SelectedItem;
            await Navigation.PushAsync(new DetailPage(item));
        }

        string GenerateRequest(string endpoint, string path, string page)
        {
            string requestUri = endpoint;
            requestUri += path;
            requestUri += $"?api_key={Constants.APIKey}";
            requestUri += $"&language=en-US";
            requestUri += $"&page={page}";
            return requestUri;
        }
    }
}
