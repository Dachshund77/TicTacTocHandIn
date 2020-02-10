using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacTocHandIn
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Setting Style in code behinde for the navigationBar
            NavigationPage navigationPage = new NavigationPage(new MainMenuPage());

            Style navStyle = Resources["NavigationPageStyle"] as Style;

            navigationPage.Style = navStyle;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
