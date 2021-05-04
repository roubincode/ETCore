# ETCore
包含C#游戏框架ETServer的服务器、客户端独立版本，基于泰课在线维护的ETCore（不包含热更新模块）。 
ETServer&Client base on ET.Core by taikr.com   
ETCore是由泰课在线维护的 ETServer游戏服务器开发框架的分支版本。     
ETCore将前后端项目代码进行了分离，Server与Client各为独立可运行版本。    
去掉了热更新模块。  

## ETCore运行指南（指南是基于win，mac，linux下自行解决）
1.下载 vs code system版本，找到扩展面板，搜索C#扩展安装好扩展。  
2.安装.NetCore SDK，下载：.NetCore2.2  (建议2.2.300+，3.0以下版本，不能跨大版本。ETCore5.0 不支持netcore3)  
3.设置netsdk的windows环境变量，在用户变量中设置  
配置环境变量名： MSBuildSdksPath  
环境变量值：C:\Program Files\dotnet\sdk\2.2.300\Sdks （根据你自己的安装目录）  
4.安装 .NETFramework  
比如打开项目报错缺少 .NETFFramework4.7.1，就找到 下载页面选择 4.7.1  下载页面上的 Developer Pack  
5.指定项目使用的netcore运行时版本  
通过 global.json 文件，定义运行时使用的 .NET Core SDK 版本  
命令行到达项目的根目录：dotnet new globaljson --sdk-version 2.2.300，在你的项目中创建一个global.json 文件  
6.用vs code打开项目，根据提示完成一次"Restore"包还原操作。  
如果打开运行过项目，把你的解决方案中的所有项目中的obj目录全部删除，打开code重新Restore

### 前端运行  
1 客户端ETCore4.0要求unity2017.4以上  
2 客户端ETCore5.0要求unity2018.3以上  
### 后端运行  
1 用Visaul Studio 打开Server解决方案编译运行，或者命令行运行生成的App.dll  
2 需要单独编译Server/Hotfix/Server.Hotfix.csproj　(用命令行或用visaul studio单独编译都可以)  

### ETCore网络斗地主案例教学（基于ET5.0网络通信，附ET核心框架构建解析）
https://www.taikr.com/course/1053

### 原ET框架作者：熊猫
### 框架地址：https://github.com/egametang/ET

# ETCore5.0最新更新！
1.删除了所有不必要的服务端组件。  
2.框架不再包含demo示例，前后端如何使用可通过教学文档了解，这样减少了并不了解框架全部核心组件模块结构的人，
运行框架的障碍，也能不受影响的开发自己的项目功能。  
3.最近原ET框架可能发布6.0的正式版，所以删除了ETCore6.0分支，到时再添加。

# ETCore5.0发布!  
1.ETCore5.0即是基于ETServer5.0版本。   
2.在ETServer5.0中增加了同步方式组件，同时包含帧同步与状态同步demo。   
3.加入了UI组件demo中的登录界面使用UI组件了。   
4.增加了actor rpc 返回逻辑

# ETCore4.0发布!  
1.ETCore4.0即是基于ETServer4.0版本。   
2.前后端都基于代码相同的ET.Core，而不是像原框架那样在服务端项目中引用部分前端代码，这样能逻辑结构与思维更清楚的共享核心的事件，组件，网络模块代码。  

## ETServer c#游戏服务器框架
这是肉饼负责维护的一个ET框架的纯服务器版本，同步原框架更新。  

ET框架使用C#做服务端，现在C#是完全可以跨平台的，在linux上安装.netcore，即可，不需要修改任何代码，就能跑起来。性能方面，现在.netcore的性能非常强，比lua，python，js什么快的多了，做游戏服务端完全不在话下。

ET框架不但支持TCP，而且支持可靠的UDP协议（ENET跟KCP），ENet是英雄联盟所使用的网络库，其特点是快速，并且网络丢包的情况下性能也非常好，这个我们做过测试TCP在丢包5%的情况下，moba游戏就卡的不行了，但是使用ENet，丢包20%仍然不会感到卡，非常强大。框架还支持使用KCP协议，KCP也是可靠UDP协议，据说比ENET性能更好，使用kcp请注意，需要自己加心跳机制，否则20秒没收到包，服务端将断开连接。三种协议可以无缝切换。

## 视频教程：  
[肉饼老师主讲：](http://www.taikr.com/course/972) http://www.taikr.com/course/972  
__讨论QQ群 : 474643097__

