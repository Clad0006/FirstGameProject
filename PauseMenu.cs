using Godot;
using System;

public partial class PauseMenu : CanvasLayer
{
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("escape"))
		{
			var customMainLoop = (CustomMainLoop)GetTree();
			customMainLoop.GetLevelManager().LoadLevel("main_game.tscn");
		}
	}

	private void OnContinueButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetLevelManager().LoadLevel("main_game.tscn");
	}
	
	private void OnSaveButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetSaveManager().Save("user://savegame.save");
	}
	
	private void OnQuitButtonPressed()
	{
		var customMainLoop = (CustomMainLoop)GetTree();
		customMainLoop.GetLevelManager().LoadLevel("main_menu.tscn");
	}
}
