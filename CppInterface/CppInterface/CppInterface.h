#pragma once
#include "Debuger.h"

extern "C"
{
	__declspec(dllexport) int Add(int a, int b);

	__declspec(dllexport) void SetDebugFunction(Debuger::DebugFuncPtr fp);

}