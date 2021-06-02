using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingPage : ContentPage
    {
        RestService restService;
        int page = 0;
        public NowPlayingPage()
        {
            InitializeComponent();

            restService = new RestService();

            CondtionPagging();

            btnPrev.IsEnabled = false;
            btnNext.IsEnabled = false;

            page = 1;
            OnLoadMovieData();
        }

        

        async void OnLoadMovieData()
        {
            loadingDataMovie.IsVisible = true;

            MovieData movie = await restService.GetMovieData(GenerateRequest(Constants.Endpoint, "/movie/now_playing", page.ToString()));
            listMovie.ItemsSource = movie.Results;

            loadingDataMovie.IsVisible = false;

            btnNext.IsEnabled = true;

            CondtionPagging();
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
            if (page <= 1)
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