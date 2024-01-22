using game.Catapult;
using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	private int speed = 1000;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		double radians = CatapultState.aimAngle * Math.PI / 180;

		
		double x = (Math.Cos(radians) * (speed * CatapultState.power));
		double y = (Math.Sin(radians) * (speed * CatapultState.power));
		this.ApplyCentralImpulse(new Vector2((float)x, (float)y));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


}
