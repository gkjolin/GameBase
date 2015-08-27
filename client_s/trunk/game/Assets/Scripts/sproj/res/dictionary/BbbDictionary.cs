using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// Dictionary
/// @author CJC
/// @date 2015
/// </summary>
public class BbbDictionary
{
    /// </summary>
    /// mgr 
    /// </summary>
    private static XLDictionaryMgr _mgr = XLDictionaryMgr.getInstance();

    /// </summary>
    /// get string SS0
    /// </summary>
    public static string SS0
    {
        get { return _mgr.getTextById(10000); }
    }

    /// </summary>
    /// get string TRR2
    /// </summary>
    public static string TRR2
    {
        get { return _mgr.getTextById(10001); }
    }

}
