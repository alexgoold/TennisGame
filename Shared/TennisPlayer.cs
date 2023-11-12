namespace TennisGame.Shared;

public class TennisPlayer
{
	public string Name { get; set; } = string.Empty;
	public string Score { get; set; } = "Love";
	public int Points { get; set; } = 0;

	public string ConvertNumberToTennisScore(int score)
	{
		return score switch
		{
			0 => "Love",
			1 => "15",
			2 => "30",
			3 => "40",
			_ => "You should never see this",
		};
	}
}