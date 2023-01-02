using System;
using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;

namespace BLL
{
    public class ChatService : IChatService
    {
		private readonly IChatData chatData;

        public ChatService(IChatData chatData)
        {
			this.chatData = chatData;
		}

		public string GetMessageResponse(string chatMessage)
		{
			var response = this.chatData.GetMessageResponse(chatMessage);

			return response;
		}
	}
}