using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private Area2D _hurtBox;

    [Export]
    private int _speed = 400;
	private Vector2 _currentVelocity;

    [Export]
    private int _dashSpeed = 800;
    [Export]
    private double _dashMaxTime = 0.5;
    private double _dashTime = 0;
    private bool _isDashing = true;

    [Export]
    private int _health = 4;

    [Export]
    private double _invulMaxTime = 1;
    private double _invulTime = 0;
    private bool _isInvul = true;

    [Signal]
    public delegate void HealthUpdateEventHandler(int health);


    public override void _Ready()
    {
        ManageHealth(0);

        _hurtBox = GetNode<Area2D>("HurtBox");
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        HandleInput();

        

        // TICK DOWN INVULN TIMER
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

        // TICK DOWN DASH TIMER
        if (_isDashing)
        {
            // Count down dash timer
            _dashTime -= delta;

            // If dash timer is less than or equal to zero, reset invuln state
            if (_dashTime <= 0)
            {
                _isDashing = false;
                _dashTime = _dashMaxTime;
            }
        }

        // CHECK IF OVERLAPPING HOSTILE
        // Since area2D only detects projectiles, just need to see if greater than 0
        if (_hurtBox.GetOverlappingAreas().Count > 0)
        {
            HitHostile();
        }

        // MOVEMENT
        
        
        Velocity = _currentVelocity;
        MoveAndSlide();
    }

    void OnAreaEntered(Area2D area)
    {
        //GD.Print("collision area test: " + area.Name);
        //HitHostile();

    }

    // INPUT EVENTS
    public override void _Input(InputEvent @event)
    {
        // DASH
        if (@event.IsActionPressed("Dash"))
        {
            _isDashing = true;
            _isInvul = true;
            _dashTime = _dashMaxTime;
            _invulTime = _dashMaxTime;
        }
    }


    private void HandleInput()
    {
        _currentVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        
        // Set speed based on if dashing or not
        if (_isDashing)
        {
            _currentVelocity *= _dashSpeed;
        }
        else
        {
            _currentVelocity *= _speed;
        }
        
    }

    private void ManageHealth(int healthModify)
    {
        _health += healthModify;
        EmitSignal(SignalName.HealthUpdate, _health);
    }

    public void HitHostile (int damage = -1)
    {
        // If not invincible, deal damage and activate invuln
        if (!_isInvul)
        {
            GD.Print("Hit a hostile enemy");
            _isInvul = true;
            ManageHealth(damage);
        }
        
        
    }
}
