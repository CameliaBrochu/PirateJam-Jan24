using Godot;
using System;

using game.Field;

public partial class FieldSpawner : Polygon2D
{
	static private Vector2I sceneSize = new Vector2I(1150, 645);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(string.Format("[FIELD-SPAWN] screen dimensions: ({0}, {1})", sceneSize.X, sceneSize.Y));

		foreach(float f in FieldState.heightmap) {
			GD.Print(string.Format("[FIELD-SPAWN] value = {0}", f));
		}
		int step = sceneSize.X / FieldState.heightmap.Length;
		GD.Print(string.Format("[FIELD-SPAWN] step = {0}", step));

		for(int i = 0; i <= sceneSize.X; i += step) {
			GD.Print(string.Format("[FIELD-SPAWN] Sampling at X = {0}", i));
			//TODO: Generate sub-polygon for this slice of the screen
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
