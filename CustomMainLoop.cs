using Godot;
using System;

[GlobalClass]
public partial class CustomMainLoop : SceneTree
{
    private LevelManager LevelManager;
    private SaveManager SaveManager;
    
    public override void _Initialize()
    {
        LevelManager = new LevelManager();
        GetRoot().AddChild(LevelManager);
        
        SaveManager = new SaveManager();
        GetRoot().AddChild(SaveManager);
        
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