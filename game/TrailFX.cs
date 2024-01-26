using Godot;
using Godot.Collections;

public partial class TrailFX : Node2D
{
	[Export] private Node2D catapult;
	[Export] private Line2D lineRender;
	private Bullet tracked;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var GameUi = GetTree().Root.GetNode("Main/CanvasLayer/GameUi");
		GameUi.Connect("Fire", Callable.From(this.OnFire));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (IsInstanceValid(tracked)) {
			lineRender.AddPoint(tracked.GlobalPosition);
		}
		else if (lineRender.GetPointCount() > 0) {
			lineRender.ClearPoints();
		}
	}

	private void OnFire()
	{
		Node c = catapult.FindChild("Catapult");
		tracked = c.GetNode<Bullet>("Bullet/RigidBody2D");
	}
}
