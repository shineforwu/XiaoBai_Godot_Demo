/*
 * @Author: Shine_Wu 
 * @Date: 2026-07-16 06:24:56 
 * @Last Modified by: Shine_Wu
 * @Last Modified time: 2026-07-16 07:43:14
 */
using Godot;
using System;

public partial class Run_Win : Node2D
{
     [Export] public Player[] Player_Arr;
     [Export] public Button  Attack_Btn;

     public override void _Ready()
     {
          base._Ready();
          Attack_Btn.Pressed += Attack_Btn_Pressed;
     }

     private void Attack_Btn_Pressed()
    {
        Player_Arr[0].Attack();
        
    }
}
