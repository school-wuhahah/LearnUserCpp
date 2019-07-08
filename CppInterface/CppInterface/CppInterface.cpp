﻿// CppInterface.cpp : 定义 DLL 应用程序的导出函数。
//

#include <string>
#include <sstream>
#include "CppInterface.h"


int Add(int a, int b)
{
	int result = a + b;
	stringstream sstream;
	sstream << result;
	Debuger::Log(sstream.str());
	return result;
}

void SetDebugFunction(Debuger::DebugFuncPtr fp)
{
	Debuger::SetDebugFuncPtr(fp);
}

void init_register_luaState(lua_State *L)
{
	LuaTest::init_register_luaState(L);
}

