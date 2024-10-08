using Godot;
using System;

[GlobalClass]
public partial class CustomMainLoop : MainLoop
{
    public override void _Initialize()
    {
        base._Initialize();
        GD.Print("CustomMainLoop Initialize");
    }
}