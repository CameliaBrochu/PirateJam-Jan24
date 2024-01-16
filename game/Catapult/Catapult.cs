using Godot;
using System;

public partial class Catapult : Sprite2D
{
	PackedScene bulletScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NodePath currentPath = GetPath();

		this.bulletScene = GD.Load<PackedScene>("res://Catapult/Bullet.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_accept"))
		{
			this.Shoot();
		}
	}

	private void Shoot()
	{
		Node bullet = this.bulletScene.Instantiate();

		this.AddChild(bullet);

		bullet.Set("position", this.GetNode<Marker2D>("Marker2D").Position);

	}
}
