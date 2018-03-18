using System;

namespace Tennis
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public int Score { get; private set; }

        public string Name { get; }

        public void WonPoint()
        {
            Score++;
        }
    }

    internal class TennisGame1 : TennisGame
    {
        private readonly Player player1;
        private readonly Player player2;
        private readonly ScoreType scoreType;

        public TennisGame1(string player1Name, string player2Name, ScoreType scoreType)
        {
            this.scoreType = scoreType;
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            var player = player1.Name == playerName ? player1 : player2;
            player.WonPoint();
        }

        public string GetScore()
        {
            if (scoreType == ScoreType.WithAd) return new AdvantageScoreManager(player1, player2).GetScore();

            throw new NotImplementedException();
        }
    }
}