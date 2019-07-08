#include "LuaTest.h"
#include "Debuger.h"

void LuaTest::init_register_luaState(lua_State *L)
{
	if (L != nullptr)
	{
		luaL_openlibs(L);
		create_test_luafunc(L);
	}
}

void LuaTest::create_test_luafunc(lua_State *L)
{
	lua_register(L, "testluafunc", testluafunc);
}


int LuaTest::testluafunc(lua_State *L)
{
	Debuger::Log("Run Cpp Register luaFunc : testluafunc ");
	return 0;
}


