using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    private int _speed = 50;
	private Vector2 _currentVelocity;

    [Export]
    private int _health = 4;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        HandleInput();

        Velocity = _currentVelocity;
        MoveAndSlide();
    }

    private void HandleInput()
    {
        _currentVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        _currentVelocity *= _speed;
    }

    private void ManageHealth()
    {
        GD.Print("manage health test");
    }
}
