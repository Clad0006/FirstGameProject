using Godot;

public partial class MainMenu : CanvasLayer
{
	private void OnStartButtonPressed()
	{
		LevelManager.Instance.LoadLevel("main_game.tscn");
	}
}
