using Godot;
using System;

public partial class PauseMenu : CanvasLayer
{
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("escape"))
		{
			LevelManager.Instance.LoadLevel("main_game.tscn");
		}
	}

	private void OnContinueButtonPressed()
	{
		LevelManager.Instance.LoadLevel("main_game.tscn");
	}
	
	private void OnSaveButtonPressed()
	{
		//SaveManager.Instance.save()
	}
	
	private void OnQuitButtonPressed()
	{
		LevelManager.Instance.LoadLevel("main_menu.tscn");
	}
}
