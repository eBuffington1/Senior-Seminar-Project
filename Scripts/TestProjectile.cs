using Godot;
using System;

public partial class TestProjectile : Sprite2D
{
	private Node2D _player;

	[Export]
	private int _dealtDamage = -1;

    [Signal]
    public delegate void HitPlayerEventHandler(int damage);

    public override void _Ready()
	{

	}

    void OnAreaEntered(Area2D area)
	{
		//GD.Print("collision area test");
	}

	void OnBodyEntered(Node2D body)
	{
		//GD.Print("collision body test");

		if(body.Name == "PlayerCharacter")
		{
			GetTree().CallGroup("Player", "HitHostile", _dealtDamage);
        }

    }
}
