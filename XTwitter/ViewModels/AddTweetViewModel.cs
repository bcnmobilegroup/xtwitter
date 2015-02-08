using System;
using XForms.Framework.ViewModels;
using XForms.Framework.Services;
using XTwitter.Core.Services.Twitter;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.XamForms.Mobile.Media;
using Acr.XamForms.UserDialogs;
using System.IO;
using XTwitter.Extensions;
using System.Threading.Tasks;

namespace XTwitter.ViewModels
{
	public class AddTweetViewModel : Base.BaseTweetViewModel
	{

		#region Consts

		const int MAX_TWITTER_LENGTH = 140;

		#endregion

		#region Private members

		ITwitterApi _twitterApiService;
		IMediaPicker _mediaPicker;
		IUserDialogService _userDialogService;

		string _charactersCounter;
		Color _charactersCounterColor;
		bool _tweetIsValid;
		ImageSource _imageSource;
		byte[] _imageBytes;

		#endregion

		#region Properties

		public string CharactersCounter 
		{ 
			get
			{
				return _charactersCounter;
			}
			private set
			{
				base.SetProperty(ref _charactersCounter, value, "CharactersCounter");
			}
		}

		public Color CharactersCounterColor 
		{ 
			get
			{
				return _charactersCounterColor;
			}
			private set
			{ 
				base.SetProperty(ref _charactersCounterColor, value, "CharactersCounterColor");
			}
		}

		public bool TweetIsValid
		{
			get
			{
				return _tweetIsValid;
			}
			private set
			{
				base.SetProperty(ref _tweetIsValid, value, "TweetIsValid");
			}
		}

		public ImageSource Image

		{
			get 
			{ 
				return this._imageSource; 
			}
			private set 
			{
				this._imageSource = value;
				this.OnPropertyChanged();
			}
		}

		#endregion

		#region Commands

		public ICommand SendTweetCommand { get; private set; }
		public ICommand ChoiceImageSourceCommand { get; private set; }
		public ICommand ImageFromGalleryCommand { get; private set; }
		public ICommand ImageFromCameraCommand { get; private set; }
		public ICommand RemoveImageCommand { get; private set; }

		#endregion

		#region Constructor

		public AddTweetViewModel(INavigator navigator, ITwitterApi twitterApiService, IUserDialogService userDigalogService, IMediaPicker mediaPicker)
			: base(navigator)
		{
			_twitterApiService = twitterApiService;
			_userDialogService = userDigalogService;
			_mediaPicker = mediaPicker;

			InitData ();

			SendTweetCommand = new Command (SendTweet);
			ConfigureCameraCommands ();

			this.TweetIsValid = false;

			base.PropertyChanged += HandlePropertyChanged;
		}

		#endregion

		#region Overrides

		protected override void InitData ()
		{
			base.Title = "New Tweet";
			base.Username = _twitterApiService.UserLogged.Name;
			base.ScreenUsername = _twitterApiService.UserLogged.ScreenName;
			base.UserImageUrl = _twitterApiService.UserLogged.ProfileImageUrl;
			this.CharactersCounter = MAX_TWITTER_LENGTH.ToString();
			this.CharactersCounterColor = Styles.XTwitterColors.TweetCharactersCounterOKTextColor;
			this.TweetIsValid = true;
		}

		#endregion

		#region Private methods

		void UpdateTweetControlProperties()
		{
			UpdateCharactersCounter ();
			UpdateCharactersCounterColor ();
			UpdateTweetIsValid ();
		}

		void UpdateCharactersCounter()
		{
			this.CharactersCounter = (MAX_TWITTER_LENGTH - Text.Length).ToString ();
		}

		void UpdateCharactersCounterColor()
		{
			this.CharactersCounterColor = (Text.Length <= MAX_TWITTER_LENGTH)
				? Styles.XTwitterColors.TweetCharactersCounterOKTextColor 
				: Styles.XTwitterColors.TweetCharactersCounterKOTextColor ;
		}

		void UpdateTweetIsValid()
		{
			this.TweetIsValid = Text != null && 
								Text.Length > 0 && 
								Text.Length <= MAX_TWITTER_LENGTH;
		}

		async void SendTweet()
		{
			if (TweetIsValid) 
			{
				using (var dlg = _userDialogService.Loading ("Seding Tweet...")) 
				{
					try
					{
						var xtweet = new XTwitter.Core.Models.Tweet { 
							Text = Text,
						}.WithImage (_imageBytes);

						await _twitterApiService.PublishTweetAsync (xtweet);
						MessagingCenter.Send<AddTweetViewModel> (this, "ReloadTimeline");
						await Task.Delay(500);
						await base.Navigator.PopAsync ();
					}
					catch(Exception) 
					{
						_userDialogService.Alert("Oh oh...Houston, we have a problem!");
					}
				}
			} 
			else 
			{
				_userDialogService.Alert("Tweet is not valid.");
			}
		}

		void ConfigureCameraCommands()
		{
			this.ChoiceImageSourceCommand = new Command(() => {
				var actionSheetConfig = new ActionSheetConfig()
												.SetTitle("Choose a option...")
												.Add("Camera", () => this.ImageFromCameraCommand.Execute(null))
											    .Add("Gallery", () => this.ImageFromGalleryCommand.Execute(null));

				if(Image != null)
				{
					actionSheetConfig = actionSheetConfig.Add("Remove", () => this.RemoveImageCommand.Execute(null));
				}

				actionSheetConfig = actionSheetConfig.Add("Cancel");

				_userDialogService.ActionSheet(actionSheetConfig);
			});
			ImageFromGalleryCommand = new Command (ImageFromGallery);
			ImageFromCameraCommand = new Command (ImageFromCamera);
			RemoveImageCommand = new Command (RemoveImage);
		}

		async void ImageFromGallery()
		{
			if (!_mediaPicker.IsPhotoGalleryAvailable)
				_userDialogService.Alert("Photo Gallery is unavailable");
			else { 
				var result = await _mediaPicker.PickPhoto();
				this.OnImageReceived(result);
			}
		}

		async void ImageFromCamera()
		{
			if (!_mediaPicker.IsCameraAvailable)
				_userDialogService.Alert("Camera is not available");
			else { 
				var result = await _mediaPicker.TakePhoto();
				this.OnImageReceived(result);
			}
		}

		void RemoveImage()
		{
			Image = null;
			_imageBytes = null;
		}

		void OnImageReceived(IMediaFile file) {
			if (file == null)
				this._userDialogService.Alert ("Photo Cancelled");
			else 
			{
				this.Image = ImageSource.FromFile (file.Path);
				_imageBytes = file.GetBytes ();
			}
		}

		#endregion

		#region Event Handlers

		void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals ("Text")) 
			{
				UpdateTweetControlProperties ();
			}
		}

		#endregion

	}
}

