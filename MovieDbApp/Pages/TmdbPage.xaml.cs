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
    public partial class TmdbPage : TabbedPage
    {
        public TmdbPage()
        {
            InitializeComponent();

            this.Children.Add(new MainPage());
            this.Children.Add(new NowPlayingPage());
            this.Children.Add(new UpcomingPage());
        }

        private async void OnClickFav(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritePage());
        }
    }
}