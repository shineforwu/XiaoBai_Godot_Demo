/*
 * @Author: Shine__Wu 
 * @Date: 2026-07-13 06:27:02 
 * @Last Modified by: Shine__Wu
 * @Last Modified time: 2026-07-13 07:35:49
 */
using Godot;
using System;
public partial class Main : Node2D
{
    [Export] public Play[] Player_Arr;
    [Export] public Button[] Button_Arr;

    public override void _Ready()
    {
        base._Ready();
        Button_Arr[0].Pressed += On_Reset_Btn_Pressed;
        Button_Arr[1].Pressed += On_Move_1_Btn_Pressed;
        Button_Arr[2].Pressed += On_Move_2_Btn_Pressed;

    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (Player_Arr[1].Ray.IsColliding())
        {
            GD.Print($"Player_Arr[1].Position = {Player_Arr[1].Position}");
            if (Player_Arr[1].Velocity != Vector2.Zero)
            {
                Player_Arr[1].Velocity = Vector2.Zero;
                GD.Print($"Player_Arr[1].Velocity = {Player_Arr[1].Velocity}");
            }
            else
            {
                return;
            }
        }
    }
    private void On_Reset_Btn_Pressed()
    {
        Player_Arr[0].Position = new Vector2(100, 100);
        Player_Arr[1].Position = new Vector2(100, 400);
        Player_Arr[0].Velocity = new Vector2(0, 0);
        Player_Arr[1].Velocity = new Vector2(0, 0);
    }
    private void On_Move_1_Btn_Pressed()
    {

        if (Player_Arr[0].Ray.IsColliding())
        {
            return;
        }
        Player_Arr[0].Position += new Vector2(100, 0);
    }
    private void On_Move_2_Btn_Pressed()
    {
        Player_Arr[1].Velocity = new Vector2(100, 0);
    }
}
