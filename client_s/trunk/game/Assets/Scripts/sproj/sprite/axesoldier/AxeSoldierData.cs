using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

public class AxeSoldierData : SoldierDataBase
{
    public AxeSoldierData()
    {
        this.HP = 20;
        this.ATK = 2;
        this.MoveSpeed = 1;
        this.AttckDistance = 1.5f;
        this.Interval = 10;
        this.DeadDelay = 30;
    }
}
