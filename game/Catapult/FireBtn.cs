using game.Catapult;
using Godot;
using System;

public partial class FireBtn : TextureButton
{
	private bool buttonReleased = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (this.ButtonPressed){
			this.buttonReleased = true;
			CatapultState.charging = true;
		} else {
			if(this.buttonReleased){
				this.EmitFireSignal();
				this.buttonReleased = false;
			}
			CatapultState.charging = false;
		}
	}

	[Godot.Signal]
	public delegate void FireEventHandler();

	public override void _Pressed()
	{
		
	}

	private void EmitFireSignal()
	{
		EmitSignal(SignalName.Fire);
	}
}
