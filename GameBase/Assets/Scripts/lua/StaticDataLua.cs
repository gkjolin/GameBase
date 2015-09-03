using System.Collections;
using System.Collections.Generic;
using SLua;

public class StaticDataLua {

    private static StaticDataLua _instance;

    public static StaticDataLua Instance
    {
        get { if (_instance == null) { _instance = new StaticDataLua(); } return StaticDataLua._instance; }
    }

    private LuaSvr lua;
    public StaticDataLua()
    {
        lua = new LuaSvr();
    }

    private Dictionary<string, LuaTable> _dictTables = new Dictionary<string, LuaTable>();
    private LuaTable GetTable(string tableName)
    {
        if (_dictTables.ContainsKey(tableName))
        {
            return _dictTables[tableName];
        }
        LuaTable table = (LuaTable)lua.start(tableName);
        _dictTables.Add(tableName, table);
        return table;
    }

    private LuaTable GetTableRow(string tableName, int rowId)
    {
        LuaTable table = GetTable(tableName);
        LuaTable row = (LuaTable)table[rowId];
        return row;
    }

    private object GetTableCell(string tableName, int rowId, string key)
    {
        object obj = GetTableRow(tableName, rowId)[key];
        return obj;
    }
}
