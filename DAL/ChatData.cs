using Shared.Interfaces;

namespace DAL
{
	public class ChatData : IChatData
	{
		public string GetMessageResponse(string chatMessage)
		{
			var msgSent = string.Format("{0}-{1}", "Message Sent", chatMessage);

			return msgSent;
		}
	}
}