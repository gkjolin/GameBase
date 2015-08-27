using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

public class MasterSoldierData : SoldierDataBase {

    public MasterSoldierData()
    {
        this.HP = 10;
        this.ATK = 2;
        this.MoveSpeed = 1;
        this.AttckDistance = 6f;
        this.Interval = 10;
        this.DeadDelay = 30;
    }
}
