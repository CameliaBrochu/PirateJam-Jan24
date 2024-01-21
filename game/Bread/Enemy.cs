using Godot;
using System;
using System.Runtime.InteropServices;

public partial class Enemy : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.BodyEntered += _HandleCollision;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _ExitTree()
	{
		this.BodyEntered -= _HandleCollision;
		base._ExitTree();
	}

	private void _HandleCollision(Node2D other)
	{
		string path = other.GetPath().ToString();
		GD.Print("AYO, collision avec un boulett ! path = ", path);
	}
}
