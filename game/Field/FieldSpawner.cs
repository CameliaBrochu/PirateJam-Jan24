using Godot;
using Godot.Collections;

using game.Field;

public partial class FieldSpawner : Polygon2D
{
	static private Vector2I sceneSize = new Vector2I(1154, 648);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(string.Format("[FIELD-SPAWN] screen dimensions: ({0}, {1})", sceneSize.X, sceneSize.Y));
		int step = sceneSize.X / FieldState.heightmap.Length;

		Array<int> samples = new Array<int>();
		for(int i = 0; i <= sceneSize.X; i += step) {
			samples.Add(i);
		}

		Vector2[] verts = new Vector2[samples.Count + 1];
		for(int i = 0; i < samples.Count; i+=2) {
			GD.Print("[VERTGEN] (", i + 0, "); (", i + 1, ")");

			int height = (int)FieldState.heightmap[System.Math.Min(i, FieldState.heightmap.Length - 1)];
			verts[i + 0] = new Vector2I(samples[i], height);
			verts[i + 1] = new Vector2I(samples[i], sceneSize.Y);
		}
		GD.Print("[POLY] count = ", verts.Length);
		foreach (Vector2 v in verts) {
			GD.Print("  - ", v);
		}
		
		Array<Array<int>> polys = new Array<Array<int>>();
		for (int i = 0; i < verts.Length - 2; i+=2) {
			polys.Add(new Array<int> { i + 0, i + 2, i + 3, i + 1 });
		}

		foreach (Array<int> p in polys) {
			GD.Print(p);
		}
		Polygon = verts;
		Polygons = (Array)polys;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
