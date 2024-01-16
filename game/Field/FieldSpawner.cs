using Godot;
using Godot.Collections;

public partial class FieldSpawner : Polygon2D
{
	[Export] private CollisionPolygon2D collision;
	static private Vector2I sceneSize = new Vector2I(1154, 648);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		float[] heightmap = new float[25];
		for(int i = 0; i < heightmap.Length; i++) {
			heightmap[i] = SampleFunc(i) * 20 + 350;
		}

		int step = sceneSize.X / heightmap.Length;
		Array<int> samples = new Array<int>();
		for(int i = 0; i <= sceneSize.X; i += step) {
			samples.Add(i);
		}

		Vector2[] verts = new Vector2[samples.Count * 2];
		for(int i = 0; i < samples.Count; i++) {
			int height = (int)heightmap[System.Math.Min(i, heightmap.Length - 1)];
			verts[(i * 2) + 0] = new Vector2I(samples[i], height);
			verts[(i * 2) + 1] = new Vector2I(samples[i], sceneSize.Y);
		}
		Polygon = verts;

		Array<Array<int>> polys = new Array<Array<int>>();
		for (int i = 0; i < verts.Length - 2; i+=2) {
			polys.Add(new Array<int> { i + 0, i + 2, i + 3, i + 1 });
		}
		Polygons = (Array)polys;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private float SampleFunc(float x) {
		return (float)(
			System.Math.Sin(0.87*x) +
			System.Math.Cos(0.10*x) +
			System.Math.Sin(0.46*x) +
			System.Math.Cos(0.33*x) +
			3.1416
		);
	}
}
