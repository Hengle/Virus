using UnityEngine;
using System.Collections;
using XLua;

public class xLuaInstance
{
    LuaEnv luaenv;
    /// <summary>
    /// 热补丁修复中。。。
    /// </summary>
    public void Fixing(string fileName)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(fileName);

        if (bytes != null)
        {
            luaenv = new LuaEnv();
            luaenv.DoString(bytes);
        }
    }

    void Update()
    {
        if (luaenv != null)
            luaenv.Tick();
    }

    void OnDestroy()
    {
        if (luaenv != null)
            luaenv.Dispose();
    }
}