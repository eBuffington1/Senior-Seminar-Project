using Godot;
using System;

public partial class MainLevel : Node
{
    [Export] AnimationPlayer animPlayer;
    [Export] AudioStreamPlayer2D musicPlayer;

    [Export] Node preFightNode;

    void StartFight(Node2D body)
    {
        animPlayer.Play("Phases/SetupZone");
        musicPlayer.Play();

    }

    public void phase01()
    {
        preFightNode.QueueFree();
    }

}
