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

	private void Shoot()
	{
		Node bullet = this.bulletScene.Instantiate();

		this.AddChild(bullet);

		bullet.Set("position", this.GetNode<Marker2D>("Marker2D").Position);

	}


	private void OnFire()
	{
		this.Shoot();
	}
}
