# LearnUserCpp
##### Des:  Learn unity Interact with C++

##### Learn Site:  <https://jacksondunstan.com/articles/3938>

##### AS编译SO时：

~~~c++
#if 0
#define EXPORT_DLL __declspec(dllexport)
#else
#define EXPORT_DLL
#endif

extern "C"
{
    //直接__declspec(dllexport)会编译不过去？？？
    EXPORT_DLL int Add(int a, int b);

}

~~~

