
using System;

public partial class MyNode_Data
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string FatherID { get; set; } = string.Empty;
    public bool Is_Show_Branch { get; set; } = false;
    public int On_Father_Branch_Index { get; set; } = 0;
    /// <summary>
    /// 分支展示标志  位运算
    /// </summary>
    public int Child_Branch_Flag { get; set; } = 0;
    /// <summary>
    /// 分支点亮标志  位运算
    /// </summary>
    public int Child_Branch_Trun_On_Flag { get; set; } = 0;
}
