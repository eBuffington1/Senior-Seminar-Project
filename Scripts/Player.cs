using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private CharacterBody2D _characterBody;

    [Export]
    private int _speed = 400;
	private Vector2 _currentVelocity;

    [Export]
    private int _health = 4;

    [Export]
    private double _invulMaxTime = 1;
    private double _invulTime = 0;
    private bool _isInvul = false;

    [Signal]
    public delegate void HealthUpdateEventHandler(int health);


    public override void _Ready()
    {
        ManageHealth(0);

        _characterBody = GetNode<CharacterBody2D>("PlayerCharacter");
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        HandleInput();

        Velocity = _currentVelocity;
        MoveAndSlide();

    }

    public override void _Process(double delta)
    {
        if (_isInvul)
        {
            // Count down invuln timer
            _invulTime -= delta;

            // If invuln timer is less than or equal to zero, reset invuln state
            if (_invulTime <= 0)
            {
                _isInvul = false;
                _invulTime = _invulMaxTime;
            }
        }

        //_characterBody.Get
    }

    private void HandleInput()
    {
        _currentVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        _currentVelocity *= _speed;
    }

    private void ManageHealth(int healthModify)
    {
        _health += healthModify;
        EmitSignal(SignalName.HealthUpdate, _health);
    }

    public void HitHostile (int damage)
    {
        // If not invincible, deal damage and activate invuln
        if (!_isInvul)
        {
            ManageHealth(damage);
            _isInvul = true;
        }
        
        
    }
}
