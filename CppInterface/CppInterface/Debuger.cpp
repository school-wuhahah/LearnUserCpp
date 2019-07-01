#include "stdafx.h"
#include "Debuger.h"

Debuger::DebugFuncPtr Debuger::FuncPtr;

//char Debuger::container[100];

void Debuger::SetDebugFuncPtr(DebugFuncPtr ptr)
{
	FuncPtr = ptr;
}

void Debuger::Log(const string str)
{
	if (FuncPtr != nullptr)
	{
		FuncPtr(str.c_str());
	}
}
