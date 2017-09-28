using UnityEngine;
using System.Collections;
using XLua;
public class SelfExampleSrc : MonoBehaviour
{
    LuaEnv luaenv = new LuaEnv();
    void Start()
    {
        luaenv.DoString("require 'helloTest'");
    }
}