// LuaCppTest.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#include "LuaTest.h"
#include <iostream>
#include <string>

//编译lua.lib时采用 TC编译 即编译为C代码
//extern “C" 是让编译器在链接是按照C编译的方式来查找符号名
extern "C" {
	#include "lua.h"
	#include "lauxlib.h"
	#include "lualib.h"
};

using namespace std;

int main()
{
	//测试逻辑
	cout << "Hello World begin !\n";
	lua_State *L = luaL_newstate();

	//2.入栈操作
	lua_pushfstring(L, "coooool~");
	lua_pushnumber(L, 20);

	//3.取值操作
	if (lua_isstring(L, 1))
	{
		cout << lua_tostring(L, 1) << endl;
	}

	if (lua_isnumber(L, -1))
	{
		cout << lua_tonumber(L, -1) << endl;
	}

	LuaTest::init_register_luaState(L);
	luaL_dofile(L, "luaTestFunc.lua");


	//luaopen_base(L); //
	//luaopen_table(L); //
	//luaopen_package(L); //
	//luaopen_io(L); //
	//luaopen_string(L); //
	//luaL_openlibs(L); //打开以上所有的lib

	string str;
	while (true)
	{
		cout << "请输入Lua代码:" << std::endl;
		getline(cin, str, '\n');
		if (luaL_loadstring(L, str.c_str())
			|| lua_pcall(L, 0, 0, 0))
		{
			const char * error = lua_tostring(L, -1);
			cout << string(error) << endl;
		}
	}

	lua_close(L);

	cout << "Hello World end !\n";
	return 0;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
