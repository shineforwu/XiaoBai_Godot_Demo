using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class MyTree_Pre : Node2D
{
    public List<MyNode_Data> MyNode_Data_List = new List<MyNode_Data>();
    public readonly string Node_Scene_Path = "res://MyNode_Pre.tscn";

    public List<MyNode_Pre> MyNode_Pre_List = new List<MyNode_Pre>();

    public override void _Ready()
    {
        base._Ready();


    }

    public override void _EnterTree()
    {
        base._EnterTree();
        MarkData();
        MyNode_Pre_List.Clear();
        AddNode();
    }





    public void MarkData()
    {
        MyNode_Data temp1 = new MyNode_Data();
        temp1.ID = "Node_0";
        temp1.Name = "Node_0";
        temp1.FatherID = string.Empty;
        temp1.Is_Show_Branch = true;
        temp1.On_Father_Branch_Index = 0;
        temp1.Child_Branch_Flag = (1 << 3) + (1 << 4);
        temp1.Child_Branch_Trun_On_Flag = (1 << 3);
        MyNode_Data_List.Add(temp1);

        MyNode_Data temp2 = new MyNode_Data();
        temp2.ID = "Node_2";
        temp2.Name = "Node_2";
        temp2.FatherID = "Node_0";
        temp2.Is_Show_Branch = true;
        temp2.On_Father_Branch_Index = 3;
        temp2.Child_Branch_Flag = (1 << 3);
        temp2.Child_Branch_Trun_On_Flag = (1 << 3);
        MyNode_Data_List.Add(temp2);

        MyNode_Data temp3 = new MyNode_Data();
        temp3.ID = "Node_3";
        temp3.Name = "Node_3";
        temp3.FatherID = "Node_0";
        temp3.Is_Show_Branch = true;
        temp3.On_Father_Branch_Index = 4;
        MyNode_Data_List.Add(temp3);

        MyNode_Data temp4 = new MyNode_Data();
        temp4.ID = "Node_4";
        temp4.Name = "Node_4";
        temp4.FatherID = "Node_2";
        temp4.Is_Show_Branch = true;
        temp4.On_Father_Branch_Index = 3;
        temp4.Child_Branch_Flag = (1 << 3);
        temp4.Child_Branch_Trun_On_Flag = (1 << 3);
        MyNode_Data_List.Add(temp4);

        MyNode_Data temp5 = new MyNode_Data();
        temp5.ID = "Node_5";
        temp5.Name = "Node_5";
        temp5.FatherID = "Node_4";
        temp5.Is_Show_Branch = true;
        temp5.On_Father_Branch_Index = 3;
        MyNode_Data_List.Add(temp5);
    }

    public void AddNode()
    {
        for (int i = 0; i < MyNode_Data_List.Count; i++)
        {
            PackedScene packedScene = GD.Load<PackedScene>(Node_Scene_Path);
            MyNode_Pre tempNode = packedScene.Instantiate<MyNode_Pre>();
            tempNode.MyNode_Data = MyNode_Data_List[i];
            MyNode_Pre_List.Add(tempNode);

            if (MyNode_Data_List[i].FatherID == string.Empty)
            {
                AddChild(tempNode);
                tempNode.Position = new Vector2(100, 300);
            }
            else
            {
                MyNode_Pre fatherNode = MyNode_Pre_List.FirstOrDefault(x => x.MyNode_Data.ID == MyNode_Data_List[i].FatherID);
                fatherNode.MyBranch_Arr[MyNode_Data_List[i].On_Father_Branch_Index].AddChild(tempNode);
            }
            tempNode.Update_UI();
        }
    }
}
