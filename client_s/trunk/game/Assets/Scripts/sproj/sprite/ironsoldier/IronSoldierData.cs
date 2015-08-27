using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

public class IronSoldierData : SoldierDataBase {

    public IronSoldierData()
    {
        this.HP = 10;
        this.ATK = 2;
        this.MoveSpeed = 1;
        this.AttckDistance = 1.5f;
        this.Interval = 30;
        this.DeadDelay = 30;
    }
}
