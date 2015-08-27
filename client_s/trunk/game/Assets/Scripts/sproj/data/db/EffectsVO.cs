using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class EffectsVO : XLExcelBinBase
{
    private int _effectId;
    public int EffectId
    {
        get { return _effectId; }
    }

    private string _effectName;
    public string EffectName
    {
        get { return _effectName; }
    }

    public EffectsVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _effectId = br.ReadInt32();
        _effectName = XLStreamTools.readJavaUTF(br);
    }

    public EffectsVO clone()
    {
        return this.MemberwiseClone() as EffectsVO;
    }
}
