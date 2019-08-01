#pragma once
#include "Debuger.h"
#include "LuaTest.h"

extern "C"
{
	__declspec(dllexport) int Add(int a, int b);

	__declspec(dllexport) void SetDebugFunction(Debuger::DebugFuncPtr fp);

	__declspec(dllexport) void init_register_luaState(lua_State *L);

	__declspec(dllexport) void testManagerfunc(testManagerStruct *tm);

}