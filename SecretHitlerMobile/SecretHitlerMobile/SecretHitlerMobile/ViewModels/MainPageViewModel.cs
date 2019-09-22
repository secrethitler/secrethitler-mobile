using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using PusherClient;
using Newtonsoft.Json.Linq;

namespace SecretHitlerMobile.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private string _updateLandingPageLabel;

        private readonly INavigationService _navigationService;

        public DelegateCommand InitiateGame { get; private set; }

        public DelegateCommand JoinGame { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
		: base(navigationService)
		{
			InitiateGame = new DelegateCommand(CreateGameLobbyExecute);
            JoinGame = new DelegateCommand(JoinGameLobbyExecute);
            _navigationService = navigationService;
		}
        
        private async void CreateGameLobbyExecute()
        {
	        var api = new ApiConnectionController(new HttpClient());
	        NavigateToLobbyPage();
	        await api.CreateGameLobby();
	        UpdateLandingPageLabel = $"Response: {ApiConnectionController.RESPONSECONTENT} \n Successful: {ApiConnectionController.ISSUCCESSSTATUSCODE}";
            if(ApiConnectionController.ISSUCCESSSTATUSCODE)
            {
                JObject response = JObject.Parse(ApiConnectionController.RESPONSECONTENT);
                string channelName = (string)response["channelName"];
                string userId = (string)response["userId"];
                PusherConnect();
                Console.WriteLine("42069: " + userId);
                PusherConnectionController._publicChannel = await PusherConnectionController._pusher.SubscribeAsync(channelName);
                PusherConnectionController._privateChannel = await PusherConnectionController._pusher.SubscribeAsync("private-" + userId);
                // PusherConnectionController._presenceChannel = await PusherConnectionController._pusher.SubscribeAsync("presence-" + channelName);
                // PusherConnectionController._presenceChannel.Subscribed += _presenceChannel_Subscribed;
            }
        }
        
        private async void JoinGameLobbyExecute()
        {
	        var api = new ApiConnectionController(new HttpClient());
	        await api.JoinGameLobby();
	        Console.WriteLine("42069 " + ApiConnectionController.RESPONSECONTENT);
	        if (ApiConnectionController.ISSUCCESSSTATUSCODE)
	        {
		        PusherConnect();
                PusherConnectionController._privateChannel = await PusherConnectionController._pusher.SubscribeAsync("private-" + ApiConnectionController.RESPONSECONTENT);
		        NavigateToLobbyPage();
	        }
        }
        
        private void NavigateToLobbyPage()
        {
	        _navigationService.NavigateAsync("LobbyPage");
        }
        
        public string UpdateLandingPageLabel
        { 
	        get => _updateLandingPageLabel;
	        set => SetProperty(ref _updateLandingPageLabel, value); 
        }
        
        private async void PusherConnect()
        {
            PusherConnectionController._pusher = new Pusher("dbaa9e20ac7717618b2a", new PusherOptions()
            {
                Cluster = "eu",
                Authorizer = new HttpAuthorizer("https://secrethitler.tk/api/pusher/auth")
            });
            // PusherConnectionController._pusher.ConnectionStateChanged += _pusher_ConnectionStateChanged;
            // PusherConnectionController._pusher.Error += _pusher_Error;
            ConnectionState connectionState = await PusherConnectionController._pusher.ConnectAsync();
        }
        
        static void _pusher_ConnectionStateChanged(object sender, ConnectionState state)
        {
                     Console.WriteLine("Connection state: " + state.ToString());
		}
        static void _pusher_Error(object sender, PusherException error)
        {
	        Console.WriteLine("Pusher Channels Error: " + error.ToString());
        }

        static void _presenceChannel_Subscribed(object sender)
        {
            Console.WriteLine("IT WORKDED 420");
        }
    }
}
