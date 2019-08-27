using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;

namespace SecretHitlerMobile.ViewModels
{
	class ApiConnectionController
	{
		private static HttpClient _client = new HttpClient(new HttpClientHandler());

		public ApiConnectionController(HttpClient httpClient)
		{
			_client = httpClient;
			_client.BaseAddress = new Uri(string.Format("https://secrethitler.tk", string.Empty));
		}

		public static string RESPONSECONTENT;
		public static bool ISSUCCESSSTATUSCODE;

		public async Task CreateGameLobby(){

				string data = "againThisMaxiDude";

				StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

				try
				{
					using (HttpResponseMessage response = await _client.PostAsync("api/game/create?userName=", content))
					{
						RESPONSECONTENT = await response.Content.ReadAsStringAsync();
						ISSUCCESSSTATUSCODE = response.IsSuccessStatusCode;
					}


				}
				catch (Exception e)
				{
					RESPONSECONTENT = e.ToString();
				}
		}
	}
}
