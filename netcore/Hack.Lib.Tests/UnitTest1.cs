using System;
using System.Collections.Generic;
using Xunit;

namespace Hack.Lib.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckTennisGame1()
        {
            foreach (var score in this.allScores)
            {
                var game = new TennisGame1("player1", "player2");
                CheckScore(game, score);
            }
        }

        [Fact]
        public void CheckTennisGame2()
        {
            foreach (var score in this.allScores)
            {
                var game = new TennisGame2("player1", "player2");
                CheckScore(game, score);
            }
        }

        [Fact]
        public void CheckTennisGame3()
        {
            foreach (var score in this.allScores)
            {
                var game = new TennisGame3("player1", "player2");
                CheckScore(game, score);
            }
        }

        private void CheckScore(ITennisGame game, PlayerScore score)
        {
            var highestScore = Math.Max(score.Player1Score, score.Player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < score.Player1Score)
                    game.WonPoint("player1");
                if (i < score.Player2Score)
                    game.WonPoint("player2");
            }
            Assert.Equal(score.ExpectedScore, game.GetScore());
        }

        public class PlayerScore
        {
            public readonly int Player1Score;
            public readonly int Player2Score;
            public readonly string ExpectedScore;

            public PlayerScore(int p1, int p2, string expected)
            {
                this.Player1Score = p1;
                this.Player2Score = p2;
                this.ExpectedScore = expected;
            }
        }

        private PlayerScore[] allScores = new PlayerScore[] {
            new PlayerScore( 0,  0, "Love-All"),
            new PlayerScore( 1,  1, "Fifteen-All"),
            new PlayerScore( 2,  2, "Thirty-All"),
            new PlayerScore( 3,  3, "Deuce"),
            new PlayerScore( 4,  4, "Deuce"),
            new PlayerScore( 1,  0, "Fifteen-Love"),
            new PlayerScore( 0,  1, "Love-Fifteen"),
            new PlayerScore( 2,  0, "Thirty-Love"),
            new PlayerScore( 0,  2, "Love-Thirty"),
            new PlayerScore( 3,  0, "Forty-Love"),
            new PlayerScore( 0,  3, "Love-Forty"),
            new PlayerScore( 4,  0, "Win for player1"),
            new PlayerScore( 0,  4, "Win for player2"),
            new PlayerScore( 2,  1, "Thirty-Fifteen"),
            new PlayerScore( 1,  2, "Fifteen-Thirty"),
            new PlayerScore( 3,  1, "Forty-Fifteen"),
            new PlayerScore( 1,  3, "Fifteen-Forty"),
            new PlayerScore( 4,  1, "Win for player1"),
            new PlayerScore( 1,  4, "Win for player2"),
            new PlayerScore( 3,  2, "Forty-Thirty"),
            new PlayerScore( 2,  3, "Thirty-Forty"),
            new PlayerScore( 4,  2, "Win for player1"),
            new PlayerScore( 2,  4, "Win for player2"),
            new PlayerScore( 4,  3, "Advantage player1"),
            new PlayerScore( 3,  4, "Advantage player2"),
            new PlayerScore( 5,  4, "Advantage player1"),
            new PlayerScore( 4,  5, "Advantage player2"),
            new PlayerScore(15, 14, "Advantage player1"),
            new PlayerScore(14, 15, "Advantage player2"),
            new PlayerScore( 6,  4, "Win for player1"),
            new PlayerScore( 4,  6, "Win for player2"),
            new PlayerScore(16, 14, "Win for player1"),
            new PlayerScore(14, 16, "Win for player2"),
        };
    }

    public class ExampleGameTennisTest
    {
        [Fact]
        public void CheckGame1()
        {
            var game = new TennisGame1("player1", "player2");
            RealisticTennisGame(game);
        }

        [Fact]
        public void CheckGame2()
        {
            var game = new TennisGame2("player1", "player2");
            RealisticTennisGame(game);
        }

        [Fact]
        public void CheckGame3()
        {
            var game = new TennisGame3("player1", "player2");
            RealisticTennisGame(game);
        }

        private void RealisticTennisGame(ITennisGame game)
        {
            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expectedScores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player1" };
            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Assert.Equal(expectedScores[i], game.GetScore());
            }
        }
    }
}
