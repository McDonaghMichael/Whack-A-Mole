using System;
using System.Timers;

namespace WackAMole

    
{
    public partial class MainPage : ContentPage
    {

        private static System.Timers.Timer aTimer;

        public int moleX = 0;
        public int moleY = 0;
        public int userScore = 0;
        public MainPage()
        {
            InitializeComponent();
            loopGame();

            oneOne.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(0, 0); }) });
            oneTwo.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(0, 1); }) });
            oneThree.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(0, 2); }) });

            twoOne.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(1, 0); }) });
            twoTwo.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(1, 1); }) });
            twoThree.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(1, 2); }) });

            threeOne.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(2, 0); }) });
            threeTwo.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(2, 1); }) });
            threeThree.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => {whackAttempt(2, 2); }) });
        }

        public void moleButton(object sender, EventArgs e)
        {
            

        }

        public void startTimer()
        {
          
        }
        public void endTimer()
        {

        }

        public void whackAttempt(int x, int y)
        {

            if(x == moleX && y == moleY)
            {
                resetGrass();
                loopGame();
                userScore++;
                score.Text = "Score: " + userScore;
            }
            
        }

        private void loopGame()
        {

            Random random = new Random();

            int x = random.Next(3);
            int y = random.Next(3);
            
            while (x == moleX && y == moleY) {
               x = random.Next(3);
                y = random.Next(3);

                
            }

            moleX = x;
            moleY = y;
            var targetImage = grid.Children.OfType<Image>()
                    .FirstOrDefault(image =>
                    Grid.GetRow(image) == x && Grid.GetColumn(image) == y);

                if (targetImage != null)
                {
                    // Change the source of the target image
                    targetImage.Source = ImageSource.FromFile("C:\\Users\\G00421944@atu.ie\\Downloads/mole.png");
            }

            
        }

        public void resetGrass()
        {
                    var targetImage = grid.Children.OfType<Image>()
                    .FirstOrDefault(image =>
                    Grid.GetRow(image) == moleX && Grid.GetColumn(image) == moleY);

                    if (targetImage != null)
                    {
                        // Change the source of the target image
                        targetImage.Source = ImageSource.FromFile("C:\\Users\\G00421944@atu.ie\\Downloads/grass.png");
                    }
               
          

        }

    }
}