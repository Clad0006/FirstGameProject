using Godot;
using Godot.Collections;

public partial class LevelManager : Node
{
	public static LevelManager Instance { get; private set; }
	private Node CurrentScene { get; set; }
	
	private Array<Node> _tofree = new();
	
	public override void _Ready()
	{
		GD.Print("Ready");
		Instance = this;
	}

	public void LoadLevel(string path,bool free = true)
	{
		Viewport root = GetTree().Root;
		CurrentScene = root.GetChild(root.GetChildCount() - 1);
		
		_tofree.Add(CurrentScene);
		if (GetTree().Root.GetNode(path.Remove(path.Length - 5)) != null)
		{
			_tofree.Remove(GetTree().Root.GetNode(path.Remove(path.Length - 5)));
		}
		else
		{
			CurrentScene = ResourceLoader.Load<PackedScene>(path).Instantiate();
			GetTree().Root.AddChild(CurrentScene);
		}
		if (free)
		{
			foreach (var scene in _tofree)
			{
				scene.QueueFree();
			}
			_tofree.Clear();
		}
	}
}
