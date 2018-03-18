namespace Tennis
{
    internal class AdvantageScoreManager
    {
        private const string AdvantagePlayer1 = "Advantage player1";
        private const string AdvantagePlayer2 = "Advantage player2";
        private const string WinForPlayer1 = "Win for player1";
        private const string WinForPlayer2 = "Win for player2";
        private readonly Player player1;
        private readonly Player player2;

        public AdvantageScoreManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public string GetScore()
        {
            return IsGameEquall()
                ? GetScoreForEqual()
                : (HasGameAdvantages() ? GetScoreForAdvantages() : GetSimpleScore());
        }

        private bool IsGameEquall()
        {
            return player1.Score == player2.Score;
        }

        private bool HasGameAdvantages()
        {
            return player1.Score >= 4 || player2.Score >= 4;
        }

        private string GetSimpleScore()
        {
            var score = string.Empty;
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1)
                {
                    tempScore = player1.Score;
                }
                else
                {
                    score += "-";
                    tempScore = player2.Score;
                }

                switch (tempScore)
                {
                    case 0:
                        score += Scores.Love;
                        break;
                    case 1:
                        score += Scores.Fifteen;
                        break;
                    case 2:
                        score += Scores.Thirty;
                        break;
                    case 3:
                        score += Scores.Forty;
                        break;
                }
            }

            return score;
        }

        private string GetScoreForAdvantages()
        {
            string score;
            var minusResult = player1.Score - player2.Score;
            switch (minusResult)
            {
                case 1:
                    score = AdvantagePlayer1;
                    break;
                case -1:
                    score = AdvantagePlayer2;
                    break;
                default:
                    score = minusResult >= 2 ? WinForPlayer1 : WinForPlayer2;
                    break;
            }

            return score;
        }

        private string GetScoreForEqual()
        {
            string score;
            switch (player1.Score)
            {
                case 0:
                    score = $"{Scores.Love}-{Scores.All}";
                    break;
                case 1:
                    score = $"{Scores.Fifteen}-{Scores.All}";
                    break;
                case 2:
                    score = $"{Scores.Thirty}-{Scores.All}";

                    break;
                case 3:
                    score = $"{Scores.Forty}-{Scores.All}";

                    break;
                default:
                    score = Scores.Deuce.ToString();
                    break;
            }

            return score;
        }
    }
}