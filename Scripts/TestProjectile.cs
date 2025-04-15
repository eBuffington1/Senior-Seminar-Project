using Godot;
using System;

public partial class TestProjectile : Sprite2D
{
	private Node2D _player;
	private Area2D _hitBox;

	[Export]
	private int _dealtDamage = -1;

    [Signal]
    public delegate void HitPlayerEventHandler(int damage);

	private bool _inPlayer = false;

    public override void _Ready()
	{
		_hitBox = GetNode<Area2D>("Hitbox");

	}

    public override void _PhysicsProcess(double delta)
    {
        if (_inPlayer)
		{

		}
    }

    void OnAreaEntered(Area2D area)
	{
		//GD.Print("collision area test");
	}

	void OnBodyEntered(Node2D body)
	{
		//GD.Print("collision body test:" + body.Name);

		//if(body.Name == "PlayerCharacter")
		//{
		//	GetTree().CallGroup("Player", "HitHostile", _dealtDamage);
  //      }

    }
}
