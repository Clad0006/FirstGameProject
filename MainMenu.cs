using Godot;

public partial class MainMenu : CanvasLayer
{
	private void OnStartButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetLevelManager().LoadLevel("main_game.tscn");
	}
}
