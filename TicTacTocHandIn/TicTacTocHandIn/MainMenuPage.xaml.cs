using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacTocHandIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Contain Logic to start a new game. Accesed the stord options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleGame_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimpleGame());
        }

        /// <summary>
        /// Continues a previous game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomGame_Button_Clicked(object sender, EventArgs e)
        {
            //This would require some DB implmentation. For the scope of this hand in slightly to large.
            //Might considere doing it if i have the time and motivation, not like om not coding all day already :D
        }

        private void ComplexGame_Button_Clicked(object sender, EventArgs e)
        {
            //This would require some DB implmentation. For the scope of this hand in slightly to large.
            //Might considere doing it if i have the time and motivation, not like om not coding all day already :D
        }

        /// <summary>
        /// Navigates to the Options menu where we can manipulate the options singelton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OptionPage());
        }
    }
}