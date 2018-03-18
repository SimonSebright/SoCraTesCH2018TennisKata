namespace Tennis
{
    internal class TennisGame1 : TennisGame
    {
        private const string ScoreLove = "Love";
        private const string ScoreAll = "All";
        private const string ScoreFifteen = "Fifteen";
        private const string ScoreThirty = "Thirty";
        private const string ScoreForty = "Forty";
        private const string ScoreDeuce = "Deuce";

        private const string AdvantagePlayer1 = "Advantage player1";
        private const string AdvantagePlayer2 = "Advantage player2";

        private const string WinForPlayer1 = "Win for player1";
        private const string WinForPlayer2 = "Win for player2";
        private const string Player1 = "player1";

        private int m_score1;
        private int m_score2;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == Player1)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = $"{ScoreLove}-{ScoreAll}";
                        break;
                    case 1:
                        score = $"{ScoreFifteen}-{ScoreAll}";
                        break;
                    case 2:
                        score = $"{ScoreThirty}-{ScoreAll}";

                        break;
                    case 3:
                        score = $"{ScoreForty}-{ScoreAll}";

                        break;
                    default:
                        score = ScoreDeuce;
                        break;
                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = AdvantagePlayer1;
                else if (minusResult == -1)
                    score = AdvantagePlayer2;
                else if (minusResult >= 2)
                    score = WinForPlayer1;
                else
                    score = WinForPlayer2;
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1)
                    {
                        tempScore = m_score1;
                    }
                    else
                    {
                        score += "-";
                        tempScore = m_score2;
                    }

                    switch (tempScore)
                    {
                        case 0:
                            score += ScoreLove;
                            break;
                        case 1:
                            score += ScoreFifteen;
                            break;
                        case 2:
                            score += ScoreThirty;
                            break;
                        case 3:
                            score += ScoreForty;
                            break;
                    }
                }
            }

            return score;
        }
    }
}