#include "LuaTest.h"
#include "Debuger.h"

void LuaTest::init_register_luaState(lua_State *L)
{
	if (L != nullptr)
	{
		luaL_openlibs(L);
		create_test_luafunc(L);
		lua_get_testglobal_table(L);
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

int LuaTest::lua_get_testglobal_table(lua_State *L)
{
	lua_getglobal(L, "testglobal");
	if (lua_isnil(L, -1)) {
		lua_pop(L, 1);
		lua_newtable(L);
		lua_setglobal(L, "testglobal");
		lua_getglobal(L, "testglobal");
	}
	return 1;
}


