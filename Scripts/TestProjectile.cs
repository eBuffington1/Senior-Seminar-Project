using Godot;
using System;

public partial class TestProjectile : Sprite2D
{
	private Node2D _player;

	public override void _Ready()
	{

	}

    void OnAreaEntered(Area2D area)
	{
		GD.Print("collision area test");
	}

	void OnBodyEntered(Node2D body)
	{
		GD.Print("collision body test");
	}
}
