using Godot;
using System;

[GlobalClass]
public partial class CustomMainLoop : SceneTree
{
    private LevelManager LevelManager;
    
    public override void _Initialize()
    {
        LevelManager = new LevelManager();
        GetRoot().AddChild(LevelManager);
        base._Initialize();
        GD.Print("CustomMainLoop initialized");
    }
    
    public LevelManager GetLevelManager() { return LevelManager; }

    public override void _Finalize()
    {
        base._Finalize();
        GD.Print("CustomMainLoop finalized");
    }
}