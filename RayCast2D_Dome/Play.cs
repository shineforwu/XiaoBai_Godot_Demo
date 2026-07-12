/*
 * @Author: Shine__Wu 
 * @Date: 2026-07-13 06:27:05 
 * @Last Modified by: Shine__Wu
 * @Last Modified time: 2026-07-13 06:44:17
 */
using Godot;
using System;

public partial class Play : CharacterBody2D
{
    [Export] public RayCast2D Ray;
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (Engine.IsEditorHint()) return;
        MoveAndSlide();

    }
}
