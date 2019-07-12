#pragma once
#include "lua.h"

//添加对应的.h 使用过程中多重定义
int luaopen_cjson(lua_State *l);

int luaopen_cjson_safe(lua_State *l);