using game.Catapult;
using Godot;
using System;

public partial class PowerMeter : TextureRect
{
	private float power = 0;
	private float maxPower = 1.0f;
	private TextureRect darkMeter;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.darkMeter = new TextureRect();
		this.darkMeter.Set("size", new Vector2(this.Size.X, this.Size.Y));

		Image img = Image.Create(1, (int)this.Size.Y, false, Image.Format.Rgba8);
		img.Fill(new Color(0, 0, 0, 0.8f));
		this.darkMeter.Texture = ImageTexture.CreateFromImage(img);

		this.AddChild(this.darkMeter);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (CatapultState.charging)
		{
			this.Charging();
		} else
		{
			this.power = 0;
			this.darkMeter.Set("position", new Vector2(this.Size.X - Math.Max(0, this.Size.X * (1 - power)), 0));
			this.darkMeter.Set("size", new Vector2(Math.Max(0, this.Size.X * (1 - power)), this.Size.Y));
		}
	}

	public void Charging()
	{
		if (power <= maxPower)
		{
			power += 0.005f;
		}
		else
		{
			this.power = maxPower;
		}
		
		CatapultState.power = this.power;
		this.darkMeter.Set("position", new Vector2(this.Size.X - Math.Max(0, this.Size.X * (1 - power)), 0));
		this.darkMeter.Set("size", new Vector2(Math.Max(0, this.Size.X * (1 - power)), this.Size.Y));
	}
}


