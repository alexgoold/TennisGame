using static System.Formats.Asn1.AsnWriter;

namespace TennisGame.Shared;

public class ScoreBoard
{
	public TennisPlayer Player1 { get; set; }
	public TennisPlayer Player2 { get; set; }
	public string ScoreAsString { get; set; }

	public ScoreBoard(TennisPlayer player1, TennisPlayer player2)
	{
		Player1 = player1;
		Player2 = player2;
		player1.Name = "Player 1";
		player2.Name = "Player 2";
		ScoreAsString = $"{Player1.Score} - {Player2.Score}";
	}
	public void AddPointToPlayer(TennisPlayer player)
	{
		player.Points++;
		player.Score = player.ConvertNumberToTennisScore(player.Points);
		ScoreAsString = Score();
	}

	public string Score()
	{
		if (Player1.Points == Player2.Points)
		{
			Player1.Score = Player2.Score =
				Player1.Points < 3
				? Player1.ConvertNumberToTennisScore(Player1.Points)
				: "Deuce";
		}
		else if (Player1.Points >= 4 && Player1.Points >= Player2.Points + 2)
		{
			return $"{Player1.Name} wins";
		}
		else if (Player2.Points >= 4 && Player2.Points >= Player1.Points + 2)
		{
			return $"{Player2.Name} wins";
		}
		else if (Player1.Points >= 4 && Player1.Points == Player2.Points + 1)
		{
			return $"{Player1.Name} advantage";
		}
		else if (Player2.Points >= 4 && Player2.Points == Player1.Points + 1)
		{
			return $"{Player2.Name} advantage";
		}

		return $"{Player1.Score} - {Player2.Score}";

	}

	public void ResetRound()
	{
		Player1.Points = 0;
		Player2.Points = 0;
		Player1.Score = "Love";
		Player2.Score = "Love";
		ScoreAsString = $"{Player1.Score} - {Player2.Score}";
	}

}