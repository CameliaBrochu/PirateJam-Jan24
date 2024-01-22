using Godot;

public partial class SplutFX : Node2D
{
	[Export] private Label lbl;
	[Export] private Curve curve0;
	[Export] private float maxTime = 1.0f;

	private bool isRunning = false;
	private ulong startTime = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lbl.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isRunning)
		{
			ulong elapsed = System.Math.Min(Time.GetTicksMsec() - startTime, (ulong)(1000 * maxTime));
			float p = elapsed / (float)(1000 * maxTime);
			float val = curve0.Sample(p);
			//GD.Print("e = ", elapsed, " p = ", p, " val = ", val);
			lbl.Set("scale", new Vector2(val, val));

			if (elapsed >= 1000 * maxTime) 
			{
				Teardown();
			}
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("debug_splutFX")) {
			Setup();
		}

		base._Input(@event);
	}

	private void Setup()
	{
		isRunning = true;
		startTime = Time.GetTicksMsec();
		lbl.Visible = true;
	}
	private void Teardown()
	{
		lbl.Visible = false;
		startTime = 0;
		isRunning = false;
	}
}
