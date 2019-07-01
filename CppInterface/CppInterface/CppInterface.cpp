// CppInterface.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include <string>
#include <sstream>
#include "CppInterface.h"

extern "C"
{
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
	
}

