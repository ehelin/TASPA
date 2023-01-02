using System.IO;
using Shared.Interfaces;

namespace DAL
{
	public class ChatData : IChatData
	{
		public string GetMessageResponse(string dataPath, string chatMessage)
		{
			var txtPath = string.Format("{0}\\{1}", dataPath, "chat\\data.txt");

			using (var chatData = new StreamWriter(txtPath, true))
			{
				chatData.WriteLine(chatMessage);
				chatData.Flush();
				chatData.Close();
			}

			var msgSent = string.Format("{0}-{1}", "Message Sent", chatMessage);

			return msgSent;
		}
	}
}