# ETCore
包含C#游戏框架ETServer的服务器、客户端独立版本，基于泰课在线维护的ETCore（不包含热更新模块）。 
ETServer&Client base on ET.Core by taikr.com   
ETCore是由泰课在线维护的 ETServer游戏服务器开发框架的分支版本。     
ETCore将前后端项目代码进行了分离，Server与Client各为独立可运行版本。    
去掉了热更新模块。  

## ETCore运行指南（win下就安装这两个，mac，linux下自行解决）
1 安装.NetCore SDK (建议2.2.300+，3.0以下版本，不能跨大版本。3.0版本目前还没有支持到)  
2 通过vs installer安装 .net framework (共享组件需要安装在C盘)  
3 设置launch.json文件，在vs code中对项目进行调试  
4 如果安装了多个版本的.netcore用global.json指定项目net sdk版本  
### 前端运行  
1 客户端ETCore4.0要求unity2017.4以上  
2 客户端ETCore5.0要求unity2018.3以上
3 需要用unity打开新下载的Client项目，使项目能正确加载unity引擎代码库，如果没有正确生成各.csproj项目文件，可从unity中启动visaul studio来正确生成再将编辑环境切换为 vs code. 可参考 https://www.taikr.com/article/3928   
### 后端运行  
1 用Visaul Studio 打开Server解决方案  
2 编译Server/Hotfix/Server.Hotfix.csproj　(用命令行或用visaul studio单独编译都可以)  
3 包还原完成后，调试运行服务端  

### ETCore网络斗地主案例教学（基于ET5.0网络通信，附ET核心框架构建解析）
https://www.taikr.com/course/1053

### 原ET框架作者：熊猫
### 框架地址：https://github.com/egametang/ET

# ETCore6.0发布！
1.netcore升级到3.0   
2.优化了actor分发机制，内网消息全部使用Actor消息。   
3.统一为ET命名空间。   
4.协程锁功能，解决异步队列。   
5.现在只包含状态同步demo，需要的放在，根据5.0中帧同步demo的理解自己实现并不难   

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

