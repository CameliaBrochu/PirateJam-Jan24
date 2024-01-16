using Godot;
using Godot.Collections;

using game.Field;

public partial class FieldSpawner : Polygon2D
{
	[Export] private CollisionPolygon2D collision;
	static private Vector2I sceneSize = new Vector2I(1154, 648);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (collision != null) {
			GD.Print("[FIELD-SPAWN] Got a valid collision : ", collision);
		} else {
			GD.Print("[FIELD-SPAWN] Got a invalid collision");
		}

		int step = sceneSize.X / FieldState.heightmap.Length;
		GD.Print("[FIELD-SPAWN] heightmap length = ", FieldState.heightmap.Length);
		GD.Print("[FIELD-SPAWN] step size = ", step);
		Array<int> samples = new Array<int>();
		for(int i = 5; i <= sceneSize.X; i += step) {
			GD.Print("FIELD-SPAWN] current sample = ", i);
			samples.Add(i);
		}

		Vector2[] verts = new Vector2[samples.Count * 2];
		for(int i = 0; i < samples.Count; i++) {
			int height = (int)FieldState.heightmap[i];
			GD.Print("[VERTGEN] (", i ,") -> ", height);

			GD.Print(string.Format("[OFFSETS] {0}, {1}", i*2, (i*2)+1));
			verts[(i * 2) + 0] = new Vector2I(samples[i], height);
			verts[(i * 2) + 1] = new Vector2I(samples[i], sceneSize.Y);
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
