using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ETModel
{
	/**
	* @description: 
		* NetworkComponent 主要创建实际的 Service 对象
		* OnAccept 方法创建 Session,并作为方法传递给 实际Service, 在其中Recv()时,创建并取得信道
		* Create 方法创建 Session,并直接通过 this.Service.ConnectChannel 创建并取得信道
	* @param {type} 
	* @return: 
	*/
	public abstract class NetworkComponent : Component
	{
		public AppType AppType;
		
		protected AService Service;

		private readonly Dictionary<long, Session> sessions = new Dictionary<long, Session>();

		public IMessagePacker MessagePacker { get; set; }

		public IMessageDispatcher MessageDispatcher { get; set; }

		/**
		* @description: 
			*网络组件（NetworkComponent）的awake方法中构建实际的 Service 对象。你可以创建NetOuterComponent组件来定义构建
			* kcp,tcp，websocket中的哪一种服务。
			* 此Awake方法由 扩展类NetOuterComponentAwake1System中触发。
			* 构建实际的 Service 对象时，比如 new KService(ipEndPoint, this.OnAccept);将传入OnAccept方法作为参数
			* KService创建通信信道 channel 后，把信道传参给网络组件（NetworkComponent）的 OnAccept 方法
		* @param {type} 
		* @return: 
		*/

		public void Awake(NetworkProtocol protocol, int packetSize = Packet.PacketSizeLength2)
		{
			switch (protocol)
			{
				case NetworkProtocol.KCP:
					this.Service = new KService();
					break;
				case NetworkProtocol.TCP:
					this.Service = new TService(packetSize);
					break;
				case NetworkProtocol.WebSocket:
					this.Service = new WService();
					break;
			}
		}

		public void Awake(NetworkProtocol protocol, string address, int packetSize = Packet.PacketSizeLength2)
		{
			try
			{
				IPEndPoint ipEndPoint;
				switch (protocol)
				{
					case NetworkProtocol.KCP:
						ipEndPoint = NetworkHelper.ToIPEndPoint(address);
						this.Service = new KService(ipEndPoint, this.OnAccept);
						break;
					case NetworkProtocol.TCP:
						ipEndPoint = NetworkHelper.ToIPEndPoint(address);
						this.Service = new TService(packetSize, ipEndPoint, this.OnAccept);
						break;
					case NetworkProtocol.WebSocket:
						string[] prefixs = address.Split(';');
						this.Service = new WService(prefixs, this.OnAccept);
						break;
				}
			}
			catch (Exception e)
			{
				throw new Exception($"NetworkComponent Awake Error {address}", e);
			}
		}

		public int Count
		{
			get { return this.sessions.Count; }
		}

		/**
		* @description: 
			* 网络组件（NetworkComponent）的 OnAccept方法，是作为参数传递给实际创建的 Service 对象的。
			* 这个方法会创建Session组件，并把比如KService中创建的信道channel存入Session，
			* Session最终都是通过此信道传输数据流。  //channel.Send(stream);
		* @param {type} 
		* @return: 
		*/
		public void OnAccept(AChannel channel)
		{
			Session session = ComponentFactory.CreateWithParent<Session, AChannel>(this, channel);
			this.sessions.Add(session.Id, session);
			session.Start();
		}

		public virtual void Remove(long id)
		{
			Session session;
			if (!this.sessions.TryGetValue(id, out session))
			{
				return;
			}
			this.sessions.Remove(id);
			session.Dispose();
		}

		public Session Get(long id)
		{
			Session session;
			this.sessions.TryGetValue(id, out session);
			return session;
		}

		/// <summary>
		/// 创建一个新Session
		/// </summary>
		public Session Create(IPEndPoint ipEndPoint)
		{
			AChannel channel = this.Service.ConnectChannel(ipEndPoint);
			Session session = ComponentFactory.CreateWithParent<Session, AChannel>(this, channel);
			this.sessions.Add(session.Id, session);
			session.Start();
			return session;
		}
		
		/// <summary>
		/// 创建一个新Session
		/// </summary>
		public Session Create(string address)
		{
			AChannel channel = this.Service.ConnectChannel(address);
			Session session = ComponentFactory.CreateWithParent<Session, AChannel>(this, channel);
			this.sessions.Add(session.Id, session);
			session.Start();
			return session;
		}

		public void Update()
		{
			if (this.Service == null)
			{
				return;
			}
			this.Service.Update();
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();

			foreach (Session session in this.sessions.Values.ToArray())
			{
				session.Dispose();
			}

			this.Service.Dispose();
		}
	}
}