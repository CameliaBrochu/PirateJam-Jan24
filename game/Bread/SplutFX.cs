using Godot;

public partial class SplutFX : Node2D
{
	[Export] private Label lbl;
	[Export] private Curve scale;
	[Export] private float maxTime = 1.0f;

	private bool isRunning = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Got the label : ", lbl.Name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("debug_splutFX")) {
			GD.Print("FIRE THE SPLUT!");
		}

		base._Input(@event);
	}

	private void Setup()
	{
		// Init FX to start anims
		isRunning = true;
	}
	private void Teardown()
	{
		// Hide FX ready for next fire
		isRunning = false;
	}
}
