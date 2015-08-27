using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

public class GeneralSoldierData : SoldierDataBase
{
    public GeneralSoldierData()
    {
        this.HP = 10;
        this.ATK = 1;
        this.MoveSpeed = 1;
        this.AttckDistance = 1.5f;
        this.Interval = 10;
        this.DeadDelay = 30;
    }
}
