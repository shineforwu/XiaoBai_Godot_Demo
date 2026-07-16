using Godot;
using System;
using System.Linq;

public partial class Player : CharacterBody2D
{
    [Export] public AnimationPlayer AnimPlayer;
    [Export] public Area2D   Attack_Area;
    public void Attack()
    {
        GD.Print("Attack");
        AnimPlayer.Play("Attack");
        var list = Attack_Area.GetOverlappingBodies().OfType<Player>().Where(x=>x!=this).ToList();
        if(list.Count<1)
        {
            return;
        }
        else
        {
            var target = list.First();
            target.Hit();
        }

    }

    public void Hit()
    {
        GD.Print("Hit");
        AnimPlayer.Play("Hit");
    }
}
