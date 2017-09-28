#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class CSModelWithAttributeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(CSModelWithAttribute), L, translator, 0, 6, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHello2", _m_SayHello2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHello3", _m_SayHello3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHello4", _m_SayHello4);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHelloWithRefParam", _m_SayHelloWithRefParam);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHelloWithRefParamAndReturnString", _m_SayHelloWithRefParamAndReturnString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SayHelloWithOutParam", _m_SayHelloWithOutParam);
			
			
			
			
			Utils.EndObjectRegister(typeof(CSModelWithAttribute), L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(typeof(CSModelWithAttribute), L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SayHello1", _m_SayHello1_xlua_st_);
            
			
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnderlyingSystemType", typeof(CSModelWithAttribute));
			
			
			Utils.EndClassRegister(typeof(CSModelWithAttribute), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					CSModelWithAttribute __cl_gen_ret = new CSModelWithAttribute();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to CSModelWithAttribute constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHello1_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    CSModelWithAttribute.SayHello1(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHello2(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SayHello2(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHello3(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string s = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SayHello3( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHello4(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string s = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.SayHello4( s );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHelloWithRefParam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string s = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SayHelloWithRefParam( ref s );
                    LuaAPI.lua_pushstring(L, s);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHelloWithRefParamAndReturnString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string s = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.SayHelloWithRefParamAndReturnString( ref s );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    LuaAPI.lua_pushstring(L, s);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SayHelloWithOutParam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CSModelWithAttribute __cl_gen_to_be_invoked = (CSModelWithAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string s;
                    
                    __cl_gen_to_be_invoked.SayHelloWithOutParam( out s );
                    LuaAPI.lua_pushstring(L, s);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
