using Godot;
using Godot.Collections;
using FileAccess = Godot.FileAccess;

namespace FirstGameProject;

public partial class SaveManager : Node
{
	private static SaveManager _instance;

	public static SaveManager Get()
	{
		if (_instance == null) _instance = new SaveManager();
		
		return _instance;
	}

	public void Save(string path)
	{
		GD.Print("Save");
		
		FileAccess saveFile = FileAccess.Open(path, FileAccess.ModeFlags.Write);
		
		Array<Node> savableNodes = GetTree().GetNodesInGroup("Savable");
		GD.Print(savableNodes);
		foreach (Node savable in savableNodes)
		{
			if (!savable.HasMethod("save"))
			{
				GD.Print("Node save not found");
				continue;
			}
			
			var nodeData = savable.Call("save");
			GD.Print(nodeData);
			string jsonString = Json.Stringify(nodeData);
			saveFile.StoreLine(jsonString);
		}
	}

	public void Load(string path)
	{
		GD.Print("Load");

		if (!FileAccess.FileExists(path))
		{
			GD.Print("Save not found");
			return;
		}
		
		FileAccess saveFile = FileAccess.Open(path, FileAccess.ModeFlags.Read);

		while (saveFile.GetPosition() < saveFile.GetLength())
		{
			string jsonString = saveFile.GetLine();

			Json json = new Json();
			Error parseResult = json.Parse(jsonString);
			if (parseResult != Error.Ok) continue;
			
			var nodeData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);
			Node player = GetTree().GetNodesInGroup("player")[0];
			player.Set(Node2D.PropertyName.Position, new Vector2((float)nodeData["pos_x"], (float)nodeData["pos_y"]));
		}
	}
}