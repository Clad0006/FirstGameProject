using Godot;

public partial class MainMenu : CanvasLayer
{
	private void OnStartButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetLevelManager().LoadLevel("main_game.tscn");
	}

	private void OnExitButtonPressed()
	{
		GetTree().Quit();
	}

	private void OnContinueButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetLevelManager().LoadLevel("main_game.tscn");
		customMainLoop.GetSaveManager().Load("user://savegame.save");
	}
}
