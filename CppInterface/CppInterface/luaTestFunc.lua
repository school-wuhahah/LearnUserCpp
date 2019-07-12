print("luaTestFunc bgn ...")
testluafunc()
print("testglobal : ", testglobal)
print("luaTestFunc end ...")print("luaTestFunc bgn ...")
testluafunc()
print("testglobal : ", testglobal)
--以module的形式 无法加载 ？？？？ 只能全局变量？？
local cjsondata = cjson.encode({1, 2, "abc"})
print("cjson : " , cjsondata)
