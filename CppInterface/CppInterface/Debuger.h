#pragma once
#include<iostream>
#include<string>
using namespace std;

class Debuger
{
public:
	typedef void(*DebugFuncPtr)(const char *);
	static DebugFuncPtr FuncPtr;
	static void SetDebugFuncPtr(DebugFuncPtr ptr);	
	static void Log(const string str);
};

