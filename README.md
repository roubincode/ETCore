# ETCore
包含C#游戏框架ETServer的服务器、客户端独立版本，基于泰课在线维护的ETCore（不包含热更新模块）。 
ETServer&Client base on ET.Core by taikr.com   
ETCore是由泰课在线维护的 ETServer游戏服务器开发框架的分支版本。     
ETCore将前后端项目代码进行了分离，Server与Client各为独立可运行版本。    
去掉了热更新模块。  

## ETCore运行使用方法
1 安装.net sdk  
2 通过vs installer安装 .net framework (共享组件需要安装在C盘)  
3 安装vs code 和vs code c#扩展(unity2018以上package mananger中包含vs code unity插件)  
4 需要用uinty打开新下载的ES项目，使项目能正确加载unity引擎代码库，如果没有正确生成各.csproj项目文件，可从unity中启动visaul studio来正确生成再将编辑环境切换为 vs code. 可参考 https://www.taikr.com/article/3928  
5 NLog.config文件解决ES4,5版本log输出问题(\ET-Branch_V5.0\Server\App)  
6 设置launch.json文件，在vs code中对项目进行调试  
7 用global.json指定项目net sdk版本  
8 命令行编译Server/Hotfix/Server.Hotfix.csproj(visaul studio单独编译也可以)  
9 调试运行服务端，运行客户端 

### 框架作者：熊猫
### 框架地址：https://github.com/egametang/ET
__讨论QQ群 : 474643097__

# ETCore5.0发布!  
1.ETCore5.0即是基于ETServer5.0版本。   
2.在ETServer5.0中增加了同步方式组件，帧同步与状态同步demo。   
3.加入了UI组件demo中的登录界面使用UI组件了。


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

