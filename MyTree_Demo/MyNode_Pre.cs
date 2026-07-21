using Godot;
using System;

public partial class MyNode_Pre : Node2D
{
    [Export] public Marker2D[] MyBranch_Arr;
    [Export] public Sprite2D[] MyBranch_L1_Arr;
    [Export] public Sprite2D[] MyBranch_L2_Arr;
    [Export] public Marker2D Branch_Arr_Pre;
    [Export] public Label Name_LB;
    public MyNode_Data MyNode_Data;
    public override void _Ready()
    {
        base._Ready();
    }


    public override void _EnterTree()
    {
        base._EnterTree();

    }


    public void Update_UI()
    {
        this.Name = MyNode_Data.ID;
        Name_LB.Text = MyNode_Data.Name;
        Branch_Arr_Pre.Visible = MyNode_Data.Is_Show_Branch;
        for (int i = 0; i < MyBranch_Arr.Length; i++)
        {

            MyBranch_Arr[i].Visible = (MyNode_Data.Child_Branch_Flag & (1 << i)) == (1 << i);
            MyBranch_L1_Arr[i].Visible = (MyNode_Data.Child_Branch_Trun_On_Flag & (1 << i)) == (1 << i);
            MyBranch_L2_Arr[i].Visible = !MyBranch_L1_Arr[i].Visible;
            //Node2D scale_rotation = MyBranch_Arr[i].GetChild<Node2D>();

        }

    }
}
