namespace ETModel
{
	public interface IMessageDispatcher
	{
		bool Dispatch(Session session, ushort opcode, object message);
	}
}
