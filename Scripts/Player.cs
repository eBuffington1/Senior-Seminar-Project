using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private Area2D _hurtBox;

    [Export]
    private int _speed = 400;
	private Vector2 _currentVelocity;

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
