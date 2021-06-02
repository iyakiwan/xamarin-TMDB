using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        public FavoritePage()
        {
            InitializeComponent();

            //Title = "Movie List";
        }

        protected override void OnAppearing()
        {
            listMovie.ItemsSource = App.DBUtils.GetAllMovies();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MovieEntity item = (MovieEntity)e.SelectedItem;
            await Navigation.PushAsync(new DetailPage(item));
        }
    }
}