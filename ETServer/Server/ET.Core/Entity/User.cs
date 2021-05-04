namespace ETModel
{
    [ObjectSystem]
    public class UserAwakeSystem : AwakeSystem<User,long>
    {
        public override void Awake(User self, long id)
        {
            self.Awake(id);
        }
    }

    /// <summary>
    /// 玩家对象 在C2G_LoginGate_Handler中初始化参数
    /// </summary>
    public sealed class User : Entity
    {
        /// <summary>
        /// 读取自数据库中的永久ID
        /// 本程序中出现的UserID字样变量均代表此意
        /// </summary>
        public long UserId { get; private set; }
 
        /// <summary>
        /// 玩家所在的Gate服务器的AppID
        /// </summary>    
        public int GateAppId { get; set; }

        /// <summary>
        /// 与客户端的连接session的实例id
        /// </summary>
        public long GateSessionId { get; set; }
        

        // unit实例id
        public long UnitId { get; set; }
        // player实例id
		public long ActorId { get; set; }
        
        public void Awake(long id)
        {
            this.UserId = id;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
            
            this.UserId = 0;
            this.GateAppId = 0;
            this.GateSessionId = 0;
            this.ActorId = 0;
        }
    }
}