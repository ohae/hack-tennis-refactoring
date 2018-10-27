using System;

namespace Hack.Lib
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point;
        private int player2Point;

        private string player1PointText;
        private string player2PointText;
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player1Point = 0;
            this.player1PointText = string.Empty;
            
            this.player2Name = player2Name;
            this.player2Point = 0;
            this.player2PointText = string.Empty;
        }

        private static string GetPointText(int tempScore)
        {
            string score = string.Empty;
            switch (tempScore)
            {
                case 0:
                    score = "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }
            return score;
        }
        public string GetScore()
        {
            var score = string.Empty;
            if (player1Point == player2Point && player1Point < 3)
            {
                score = string.Format("{0}-All", GetPointText(player1Point));
            }
            if (player1Point == player2Point && player1Point > 2)
                score = "Deuce";
            
            if (player1Point > 0 && player2Point == 0)
            {
                player1PointText = GetPointText(player1Point);
                player2PointText = "Love";
                score = string.Format("{0}-{1}", player1PointText, player2PointText);
            }
            if (player2Point > 0 && player1Point == 0)
            {
                player2PointText = GetPointText(player2Point);
                player1PointText = "Love";
                score = string.Format("{0}-{1}", player1PointText, player2PointText);
            }

            if (player1Point > player2Point && player1Point < 4)
            {
                player1PointText = GetPointText(player1Point);
                player2PointText = GetPointText(player2Point);

                score = string.Format("{0}-{1}", player1PointText, player2PointText);
            }
            if (player2Point > player1Point && player2Point < 4)
            {
                player2PointText = GetPointText(player2Point);
                player1PointText = GetPointText(player1Point);

                score = string.Format("{0}-{1}", player1PointText, player2PointText);
            }

            if (player1Point > player2Point && player2Point >= 3)
            {
                score = "Advantage player1";
            }
            if (player2Point > player1Point && player1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void SetP1Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                player1Point++;
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                player2Point++;
            }
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                SetP1Score(1);
            else
                SetP2Score(1);
        }

    }
}

