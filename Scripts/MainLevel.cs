using Godot;
using System;

public partial class MainLevel : Node
{
    [Export]
    AnimationPlayer animPlayer;

    void StartFight(Node2D body)
    {
        animPlayer.Play("Phases/SetupZone");
    }

    public void phase01()
    {

    }

}
