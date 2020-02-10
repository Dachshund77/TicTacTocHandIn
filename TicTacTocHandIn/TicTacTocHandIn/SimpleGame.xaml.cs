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

        public Players?[,] GameBoard;

        public SimpleGame()
        {
            InitializeComponent();
            BindingContext = this;
            this.CurPlayerTurn = DeterminStartPlayer();
            this.GameBoard = new Players?[3, 3];
        }

        private async void TakePlayerTurn(Players player, int column, int row, Button button)
        {
            //Test if valid move
            if (GameBoard[column, row] != null)
            {
                return; // Abot call 
            }

            //Update game board
            GameBoard[column, row] = player;

            //Update button
            MarkGameButton(player, button);

            if (HasGameEnded(player))
            {
                await SendEndGameMessageAsync(player); //Ignore this warning
            }
            else
            {
                switch (player)
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
            if (randomInt == 0)
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
            //Test if given player p matched 
            if (MatchedRow(p, 0) ||
                MatchedRow(p, 1) ||
                MatchedRow(p, 2) ||
                MatchedColumn(p, 0) ||
                MatchedColumn(p, 1) ||
                MatchedColumn(p, 2) ||
                MatchedDiagonally(p)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MatchedRow(Players p, int row)
        {
            if (GameBoard[0, row] == p &&
                GameBoard[1, row] == p &&
                GameBoard[2, row] == p)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MatchedColumn(Players p, int column)
        {
            if (GameBoard[column, 0] == p &&
                GameBoard[column, 1] == p &&
                GameBoard[column, 2] == p)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MatchedDiagonally(Players p)
        {
            //top left to bottom right
            if (GameBoard[0, 0] == p &&
               GameBoard[1, 1] == p &&
               GameBoard[2, 2] == p)
            {
                return true;
            }
            //top right to bottom left
            else if (GameBoard[2, 0] == p &&
                    GameBoard[1, 1] == p &&
                    GameBoard[0, 2] == p)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        private void MarkGameButton(Players player, Button button) {
            switch (player)
            {
                case Players.Cross:
                    button.Text = "X";
                    break;
                case Players.Circle:
                    button.Text = "O";
                    break;
                default:
                    throw new Exception();
            }
        }

        private async Task SendEndGameMessageAsync(Players player)
        {
            await DisplayAlert("Game over", player + " has won the game!", "OK");
            await Navigation.PopAsync();
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 0, 0, (Button)sender);
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 1, 0, (Button)sender);
        }

        private void Button9_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 2, 0, (Button)sender);
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 0, 1, (Button)sender);
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 1, 1, (Button)sender);
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 2, 1, (Button)sender);
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 0, 2, (Button)sender);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 1, 2, (Button)sender);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            TakePlayerTurn(CurPlayerTurn, 2, 2, (Button)sender);
        }
    }
}