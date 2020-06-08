using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace BJTest
{
    public partial class BlackJack : System.Web.UI.Page
    {
        // creating a playing deck
        static Stack<Card> playDeck = new Stack<Card>();

        // creating arrays for dealer and player hands
        static IList<Card> dealerHand = new List<Card>();
        static IList<Card> playerHand = new List<Card>();

        // flag to check if player pressed Stand button
        static bool isStand = false;

        // variable to store player money
        static double accountBalance = 0;

        // variable to store player's bet
        static double bet = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // action for the first load of the app
            if (!Page.IsPostBack)
            {
                NewGame();
            }

        }

        protected void btnBet_Click(object sender, EventArgs e)
        {
            // get bet value
            bet = Int32.Parse(ddlBetAmount.SelectedValue.ToString());

            // deduct bet from the account
            accountBalance -= bet;

            if(accountBalance >= 0)
            {
                // show remaining account balance on the screen
                txtAccount.Text = accountBalance.ToString();

                // Deal a new hand
                NewHand();

                // show Player Score controls
                ShowPlayerScoreControls();
            }
            else
            {
                // Configure the message box to be displayed
                string messageBoxText = "You're broke. Do you want to start a new game?";
                string caption = "You lost all your money";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;

                // Display message box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // check player's choice
                if (result == MessageBoxResult.Yes)
                {
                    accountBalance = 100;
                    NewGame();
                }
                else
                {
                    EndGame();
                }
            }
        }

 
        protected void btnNewHand_Click(object sender, EventArgs e)
        {
            // show remaining account balance on the screen
            txtAccount.Text = accountBalance.ToString();

            // enable Bet controls
            EnableBetControls();

            // hide Result controls
            HideResultControls();

            // hide Player Score
            HidePlayerScoreControls();

            // hide Dealer Score controls
            HideDealerScoreControls();

            // hide New Hand controls
            HideNewHandControls();

            // take cards off the table
            RemoveCards();
        }

        protected void btnHit_Click(object sender, EventArgs e)
        {
            if(playDeck.Count > 0)
            {
                // aaff a card to the player's hand
                playerHand.Add(playDeck.Pop());
                // show cards on the table
                RenderCards(dealerHand, playerHand);
                //  show playter score
                txtPlayerScore.Text = GetScore(playerHand).ToString();

                // check if player busts
                if (GetScore(playerHand) > 21)
                {
                    GameOver();
                    txtResult.Text = $"You bust! You lose your {bet} bucks!";

                }
            }

            else
            {
                DeckIsEmpty();
            }            
        }

        protected void btnStand_Click(object sender, EventArgs e)
        {
            // get dealer and player scores
            int playerScore = GetScore(playerHand);
            int dealerScore = GetScore(dealerHand);

            // determine the winner
            DetermineWinner(playerScore, dealerScore);

            // call GameOver() Function
            GameOver();
        }

        protected void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        protected void RenderCards(IList<Card> dealerHand, IList<Card> playerHand)
        {
            switch (dealerHand.Count)
            {
                case 2:
                    imgDealerCard1.ImageUrl = isStand ? dealerHand[0].ImageSrc : "Images/Cards/red_back.png";
                    imgDealerCard2.ImageUrl = dealerHand[1].ImageSrc;
                    imgDealerCard3.ImageUrl = "";
                    imgDealerCard4.ImageUrl = "";
                    imgDealerCard5.ImageUrl = "";
                    break;
                case 3:
                    imgDealerCard1.ImageUrl = dealerHand[0].ImageSrc;
                    imgDealerCard2.ImageUrl = dealerHand[1].ImageSrc;
                    imgDealerCard3.ImageUrl = dealerHand[2].ImageSrc;
                    imgDealerCard4.ImageUrl = "";
                    imgDealerCard5.ImageUrl = "";
                    break;
                case 4:
                    imgDealerCard1.ImageUrl = dealerHand[0].ImageSrc;
                    imgDealerCard2.ImageUrl = dealerHand[1].ImageSrc;
                    imgDealerCard3.ImageUrl = dealerHand[2].ImageSrc;
                    imgDealerCard4.ImageUrl = dealerHand[3].ImageSrc;
                    imgDealerCard5.ImageUrl = "";
                    break;
                case 5:
                    imgDealerCard1.ImageUrl = dealerHand[0].ImageSrc;
                    imgDealerCard2.ImageUrl = dealerHand[1].ImageSrc;
                    imgDealerCard3.ImageUrl = dealerHand[2].ImageSrc;
                    imgDealerCard4.ImageUrl = dealerHand[3].ImageSrc;
                    imgDealerCard5.ImageUrl = dealerHand[4].ImageSrc;
                    break;
            }

            switch (playerHand.Count)
            {
                case 2:
                    imgPlayerCard1.ImageUrl = playerHand[0].ImageSrc;
                    imgPlayerCard2.ImageUrl = playerHand[1].ImageSrc;
                    imgPlayerCard3.ImageUrl = "";
                    imgPlayerCard4.ImageUrl = "";
                    imgPlayerCard5.ImageUrl = "";
                    break;
                case 3:
                    imgPlayerCard1.ImageUrl = playerHand[0].ImageSrc;
                    imgPlayerCard2.ImageUrl = playerHand[1].ImageSrc;
                    imgPlayerCard3.ImageUrl = playerHand[2].ImageSrc;
                    imgPlayerCard4.ImageUrl = "";
                    imgPlayerCard5.ImageUrl = "";
                    break;
                case 4:
                    imgPlayerCard1.ImageUrl = playerHand[0].ImageSrc;
                    imgPlayerCard2.ImageUrl = playerHand[1].ImageSrc;
                    imgPlayerCard3.ImageUrl = playerHand[2].ImageSrc;
                    imgPlayerCard4.ImageUrl = playerHand[3].ImageSrc;
                    imgPlayerCard5.ImageUrl = "";
                    break;
                case 5:
                    imgPlayerCard1.ImageUrl = playerHand[0].ImageSrc;
                    imgPlayerCard2.ImageUrl = playerHand[1].ImageSrc;
                    imgPlayerCard3.ImageUrl = playerHand[2].ImageSrc;
                    imgPlayerCard4.ImageUrl = playerHand[3].ImageSrc;
                    imgPlayerCard5.ImageUrl = playerHand[4].ImageSrc;
                    break;
            }
        }

        protected void RemoveCards()
        {
            imgPlayerCard1.ImageUrl = "";
            imgPlayerCard2.ImageUrl = "";
            imgPlayerCard3.ImageUrl = "";
            imgPlayerCard4.ImageUrl = "";
            imgPlayerCard5.ImageUrl = "";

            imgDealerCard1.ImageUrl = "";
            imgDealerCard2.ImageUrl = "";
            imgDealerCard3.ImageUrl = "";
            imgDealerCard4.ImageUrl = "";
            imgDealerCard5.ImageUrl = "";
        }

        protected int GetScore(IList<Card> Hand)
        {
            int score = 0;
            // var to check if the deck contains Aces
            bool hasAces = false;
            // var for Ace index
            int aceIndex = 0;

            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].IntegerValue == 11)
                {
                    hasAces = true;
                    aceIndex = i;
                }

                score += Hand[i].IntegerValue;
            }
            // if score > 21 => change value of the Ace
            if (score > 21 && hasAces)
            {
                Hand[aceIndex].IntegerValue = 1;
                score = GetScore(Hand);
            }
            return score;
        }

        protected void EnableBetControls()
        { 
            btnBet.Enabled = true;
            ddlBetAmount.Enabled = true;
            btnBet.Visible = true;
        }

        protected void DisableBetControls()
        {
            btnBet.Enabled = false;
            ddlBetAmount.Enabled = false;
            btnBet.Visible = false;
        }

        protected void EnableGameControls()
        {
            btnHit.Enabled = true;
            btnStand.Enabled = true;
        }

        protected void DisableGameControls()
        {
            btnHit.Enabled = false;
            btnStand.Enabled = false;
        }

        protected void EnableNewHandControls()
        {
            btnNewHand.Enabled = true;
        }

        protected void DisableNewHandControls()
        {
            btnNewHand.Enabled = false;
        }

        protected void ShowResultControls()
        {
            lblResult.Visible = true;
            txtResult.Visible = true;
        }

        protected void HideResultControls()
        {
            lblResult.Visible = false;
            txtResult.Visible = false;
        }

        protected void ShowPlayerScoreControls()
        {
            lblPlayerScore.Visible = true;
            txtPlayerScore.Visible = true;
        }

        protected void HidePlayerScoreControls()
        {
            lblPlayerScore.Visible = false;
            txtPlayerScore.Visible = false;
        }

        protected void ShowDealerScoreControls()
        {
            lblDealerScore.Visible = true;
            txtDealerScore.Visible = true;
        }

        protected void HideDealerScoreControls()
        {
            lblDealerScore.Visible = false;
            txtDealerScore.Visible = false;
        }

        protected void HideGameControls()
        {
            btnHit.Visible = false;
            btnStand.Visible = false;
        }

        protected void ShowGameControls()
        {
            btnHit.Visible = true;
            btnStand.Visible = true;
        }

        protected void HideNewHandControls()
        {
            btnNewHand.Visible = false;
        }

        protected void ShowNewHandControls()
        {
            btnNewHand.Visible = true;
        }

        protected void HideNewGameControls()
        {
            btnNewGame.Visible = false;
        }

        protected void ShowNewGameControls()
        {
            btnNewGame.Visible = true;
        }

        protected void NewGame()
        {
            // get a new shuffled deck
            playDeck = Deck.ShuffleDeck(Deck.CreateDeck());

            // disable Game controls
            DisableGameControls();

            // enable New Hand Button
            EnableNewHandControls();

            // disable Bet controls
            DisableBetControls();

            // hide Game controls
            HideGameControls();

            // show New Hand controls
            ShowNewHandControls();

            // hide result controls
            HideResultControls();

            // hide Player Score controls
            HidePlayerScoreControls();

            // hide New Game button
            HideNewGameControls();

            // add money to player's account
            accountBalance = 100;

            // show account balance
            txtAccount.Text = accountBalance.ToString();

            // paint Game Table green
            GameTable.Style.Add("background-color", "green");
            GameTable.Style.Add("padding", "20");
        }

        protected void EndGame()
        {

            // disable bet controls
            DisableBetControls();

            // disable game controls
            DisableGameControls();

            // disable "New Hand button"
            DisableNewHandControls();

            // hide dealer score
            HideDealerScoreControls();

            // hide game controls
            HideGameControls();

            // hide New Hand button
            HideNewHandControls();

            // hide player score
            HidePlayerScoreControls();

            // show result field
            ShowResultControls();

            // show new game button
            ShowNewGameControls();

            // write Game Over in result field
            lblResult.Visible = false;
            txtResult.Text = "Game Over!";
            txtResult.BackColor = Color.Empty;
            txtResult.ForeColor = Color.White;
        }

        protected void GameOver()
        {
            // disable game controls
            DisableGameControls();

            // enable "New Hand button"
            EnableNewHandControls();

            // disable bet controls
            DisableBetControls();

            // show result controls
            ShowResultControls();

            // hide game controls
            HideGameControls();

            // show new hand controls
            ShowNewHandControls();

            // show Dealer Score controls
            ShowDealerScoreControls();

            // show Dealer Score
            txtDealerScore.Text = GetScore(dealerHand).ToString();

            // switching isStand flag to true
            isStand = true;

            // rendering cards on the table (showing dealer's hidden card) 
            RenderCards(dealerHand, playerHand);
        }

        protected void NewHand()
        {
            // reset values to default state
            isStand = false;
            lblResult.Visible = false;
            txtResult.Visible = false;
            lblDealerScore.Visible = false;
            txtDealerScore.Visible = false;

            // get account balance
            txtAccount.Text = accountBalance.ToString();

            // clear dealer and player hands
            dealerHand.Clear();
            playerHand.Clear();

            // enable game controls
            EnableGameControls();

            // disable NewHand Button
            DisableNewHandControls();

            // disable bet controls
            DisableBetControls();

            // hide result controls
            HideResultControls();

            // hide new hand controls
            HideNewHandControls();

            // show game controls
            ShowGameControls();

            // Deal cards
            DealCards();

            // Display current hand value
            txtPlayerScore.Text = GetScore(playerHand).ToString();

            // check if player or dealer has the BlackJack
            CheckForBlackJack();
        }

        protected void CheckForBlackJack()
        {
            if (GetScore(playerHand) == 21 || GetScore(dealerHand) == 21)
            {
                GameOver();
                //txtAccount.Text = accountBalance.ToString();
                txtDealerScore.Text = GetScore(dealerHand).ToString();

                if (GetScore(playerHand) == 21 && GetScore(dealerHand) != 21)
                {
                    double win = bet + bet * 1.5;
                    accountBalance += win;
                    txtResult.Text = $"You have the BlackJack! You win {bet * 1.5} bucks!";
                }
                // if player and dealer both have 21 => player loses
                // That's the rules of BlackJack apparently
                else if (GetScore(dealerHand) == 21)
                {
                    txtResult.Text = $"Dealer has the BlackJack! You lose your {bet} bucks!";
                }
            }
        }

        protected void DealCards()
        {
            if(playDeck.Count >= 4)
            {
                // adding 2 cards to dealer and player hands
                for (int i = 0; i < 2; i++)
                {
                    dealerHand.Add(playDeck.Pop());
                    playerHand.Add(playDeck.Pop());
                }
                RenderCards(dealerHand, playerHand);
            }
            else
            {
                if (DeckIsEmpty())
                {
                    DealCards();
                }
                
            }
            
        }

        protected bool DeckIsEmpty()
        {
            // Configure the message box to be displayed
            string messageBoxText = "There's not enough cards in the deck. Do you want to deal anpother deck?";
            string caption = "Card deck is empty";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // check player's choice
            if (result == MessageBoxResult.Yes)
            {
                // get a new shuffled deck
                playDeck = Deck.ShuffleDeck(Deck.CreateDeck());
                return true;
            }
            else
            {
                // return player his bet
                accountBalance += bet;
                // end the game
                EndGame();
                return false;
            }
        }

        protected void DetermineWinner(int playerScore, int dealerScore)
        {
            // check if the player bust
            if (playerScore > 21)
            {
                txtResult.Text = $"Game over! You lose your {bet} bucks";
                return;
            }

            // if dealer's score is less than 17
            while (dealerScore <= 17)
            {
                if(playDeck.Count > 0)
                {
                    // adding a card to dealer's hand
                    dealerHand.Add(playDeck.Pop());
                    // checking dealer's score
                    dealerScore = GetScore(dealerHand);
                    // rendering cards on the table
                    RenderCards(dealerHand, playerHand);
                }
                else
                {
                    DeckIsEmpty();
                }
                
            }

            if (playerScore == 21)
            {
                if (dealerScore == 21)
                {
                    accountBalance += bet;
                    txtResult.Text = $"It's a tie! You take your {bet} bucks back";
                    return;
                }
                else
                {
                    double win = bet * 2;
                    accountBalance += win;
                    txtResult.Text = $"You have 21! You win {bet} Bucks!";
                    return;
                }
            }

            if (dealerScore == 21 && playerScore != 21)
            {
                txtResult.Text = $"Dealer has 21, you don't. Hence you lose your {bet} bucks!";
                return;
            }

            // check if the dealer bust
            if (dealerScore > 21 && playerScore <= 21)
            {
                double win = bet * 2;
                accountBalance += win;
                txtResult.Text = $" Dealer busts! You win {bet} bucks!";
                return;
            }

            if (playerScore > dealerScore)
            {
                double win = bet * 2;
                accountBalance += win;
                txtResult.Text = $"You win {bet} bucks!";
                return;
            }
            else if (playerScore == dealerScore)
            {
                accountBalance += bet;
                txtResult.Text = $"It's a tie! You take your {bet} bucks back.";
                return;
            }
            else
            {
                txtResult.Text = $"Dealer wins. You lose your {bet} bucks.";
                return;
            }
        }

        
    }
}