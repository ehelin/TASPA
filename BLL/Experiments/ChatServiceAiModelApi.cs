using System;
using System.Collections;
using Shared.Dto.Chat;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shared.Interfaces;
using Shared.Dto;
using System.Net.Http;
using System.IO.Pipes;
using System.Threading.Tasks;

#pragma warning disable CS0219, CS0168 // Variable is assigned but its value is never used

namespace BLL.Experiments
{
	/// <summary>
	/// Wrapper Chat service implementation for AiModelApi (aka AdiModelRunner Python wrapper).
	/// 
	/// </summary>
	public class ChatServiceAiModelApi : IChatService
	{
		public const string CHATTER = "Chat User";  // todo make shared between all chat bot implementations

		// TODO - move to DI if ever more than a play experiment
		private readonly string protocol = "https";
		private readonly string host = "localhost:7012";
		private readonly string endpoint = "/AiModelApi/chat";

		private HttpClient client;

		public ChatServiceAiModelApi()
		{
			Initialize();
		}

		public void ClearChatSession()
		{
			Initialize();
		}		

		public async Task<ChatResponse> GetMessageResponseAsync(string chatMessage)
		{
			var queryString = $"message={chatMessage}";
			var url = $"{this.endpoint}?{queryString}";

			var response = await this.client.GetAsync(url);

			var result = await response.Content.ReadAsStringAsync();

			var chatResponse = AddChatterChatBoxNames(chatMessage, result);

			return chatResponse;
		}

		public ChatResponseType GetCurrentResponseType()
		{
			throw new NotImplementedException();
		}

		public ChatResponse GetMessageResponse(string dataPath, string chatMessage, bool includeSentimentAnalysis)
		{
			throw new NotImplementedException();
		}

		#region private methods

		private void Initialize()
		{
			this.client = BuildClient();
		}

		private HttpClient BuildClient()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri($"{this.protocol}://{this.host}");

			return client;
		}

		// todo make shared between all chat bot implementations
		private ChatResponse AddChatterChatBoxNames(string chatMessage, string response)
		{
			var cr = new ChatResponse();
			var sb = new StringBuilder();

			var chatUser = CHATTER;
			sb.AppendLine(string.Format("{0}: {1}", chatUser, chatMessage));
			sb.AppendLine(string.Format("{0}:", response));

			cr.response = sb.ToString();

			return cr;
		}

		#endregion
	}
}