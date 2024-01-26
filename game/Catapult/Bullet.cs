using game.Catapult;
using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	private int speed = 1000;
	[Export] private Sprite2D bullet;
	[Export] private AnimatedSprite2D boom;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		double radians = CatapultState.aimAngle * Math.PI / 180;

		double x = (Math.Cos(radians) * (speed * CatapultState.power));
		double y = (Math.Sin(radians) * (speed * CatapultState.power));
		this.ApplyCentralImpulse(new Vector2((float)x, (float)y));
		this.AngularVelocity = 100.0f;

		this.BodyEntered += OnContact;
		this.ContactMonitor = true;
		this.MaxContactsReported = 1;
		
		boom.AnimationFinished += OnExploded;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _ExitTree()
	{
		boom.AnimationFinished -= OnExploded;
		this.BodyEntered -= OnContact;
		base._ExitTree();
	}

	private void OnContact(Node body) {
		Node parent = body.GetParent();
		if (parent is FieldSpawner) {
			SetDeferred("freeze", true);
			bullet.Visible = false;

			boom.Visible = true;
			boom.Play();
		}
		
		//TODO: Add check to verify hits on bread
	}
	
	private void OnExploded() {
		this.GetParent().QueueFree();
	}
}
