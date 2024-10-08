using Godot;
using System;

[GlobalClass]
public partial class CustomMainLoop : SceneTree
{
    private LevelManager LevelManager;
    private SaveManager SaveManager;
    private Node mainMenu;
    
    public override void _Initialize()
    {
        LevelManager = new LevelManager();
        GetRoot().AddChild(LevelManager);
        
        SaveManager = new SaveManager();
        GetRoot().AddChild(SaveManager);
        
        mainMenu = ResourceLoader.Load<PackedScene>("res://main_menu.tscn").Instantiate();
        GetRoot().AddChild(mainMenu);
        
        base._Initialize();
        GD.Print("CustomMainLoop initialized");
    }
    
    public LevelManager GetLevelManager() { return LevelManager; }
    public SaveManager GetSaveManager() { return SaveManager; }

    public override void _Finalize()
    {
        base._Finalize();
        GD.Print("CustomMainLoop finalized");
    }
}