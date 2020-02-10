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
    public partial class SimpleGame : ContentPage
    {
        private Players curPlayerTurn;  

        public Players CurPlayerTurn
        {
            get
            {
                return curPlayerTurn;
            }
            set
            {
                curPlayerTurn = value;
                base.OnPropertyChanged();
            }
        }

        public SimpleGame()
        {
            InitializeComponent();
            this.CurPlayerTurn = DeterminStartPlayer();
        }

        private void TakePlayerTurn()
        {
            if (HasGameEnded(CurPlayerTurn))
            {
                SendEndGameMessage(CurPlayerTurn);
            } else
            {
                switch (CurPlayerTurn)
                {
                    case Players.Cross:
                        CurPlayerTurn = Players.Circle;
                        break;
                    case Players.Circle:
                        CurPlayerTurn = Players.Cross;
                        break;
                    default:
                        throw new Exception();                      
                }
            }
        }

        private Players DeterminStartPlayer()
        {
            Random rand = new Random();
            int randomInt = rand.Next(2);
            if(randomInt == 0)
            {
                return Players.Cross;
            }
            else
            {
                return Players.Circle;
            }
        }

        private bool HasGameEnded(Players p)
        {
            //3 down
            //if(Button7 == p && )
            //3 left

            //2 from corner to corner 
            return true;
        }

        private void SendEndGameMessage(Players player)
        {

        }



        

    }
}