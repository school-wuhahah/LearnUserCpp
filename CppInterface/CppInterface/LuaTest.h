#pragma once

//����lua.libʱ���� TC���� ������ΪC����
//extern ��C" ���ñ������������ǰ���C����ķ�ʽ�����ҷ�����
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

