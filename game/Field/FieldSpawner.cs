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

		Array<Vector2> verts = new Array<Vector2>();
		for(int i = 1; i < samples.Count; i++) {
			verts.Add(new Vector2I(samples[i], 200));
			verts.Add(new Vector2I(samples[i], sceneSize.Y));
		}
		GD.Print("[POLY] count = ", verts.Count);
		
		for (int i = 0; i < verts.Count - 2; i+=2) {
			GD.Print(string.Format("[POLYs] ({0}); ({1}); ({2}); ({3})",
						i, i+2, i+3, i+1));
		}

		Array<Array<int>> polys = new Array<Array<int>>();
		//this.Polygons = [];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
