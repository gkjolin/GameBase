using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// Dictionary
/// @author CJC
/// @date 2015
/// </summary>
public class AaaDictionary
{
    /// </summary>
    /// mgr 
    /// </summary>
    private static XLDictionaryMgr _mgr = XLDictionaryMgr.getInstance();

    /// </summary>
    /// get string TEST0
    /// </summary>
    public static string TEST0
    {
        get { return _mgr.getTextById(0); }
    }

    /// </summary>
    /// get string TEST1
    /// </summary>
    public static string TEST1
    {
        get { return _mgr.getTextById(1); }
    }

}
