#pragma once

//编译lua.lib时采用 TC编译 即编译为C代码
//extern “C" 是让编译器在链接是按照C编译的方式来查找符号名
extern "C" {
#include "lua.h"
#include "lauxlib.h"
#include "lualib.h"
};

class LuaTest
{
public:
	static void init_register_luaState(lua_State *L);

private:
	static void create_test_luafunc(lua_State *L);

	static int testluafunc(lua_State *L);

};

