using Godot;
using System;

public partial class FireBtn : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (this.ButtonPressed)
		{
			GD.Print("pressed");
		}
	}

	[Godot.Signal]
	public delegate void FireEventHandler();

	public override void _Pressed()
	{
		this.EmitFireSignal();
	}

	private void EmitFireSignal()
	{
		EmitSignal(SignalName.Fire);
	}
}