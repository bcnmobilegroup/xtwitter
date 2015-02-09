# XTwitter

XTwitter is a basic Twitter client implemented in Xamarin.Forms, and it has served as a demo for the first [Meetup] of [Barcelona Mobile .NET Developers Group].

![XTwitterTimeline](/_screenshots/XTwitter1.png?raw=true "Timeline") ![XTwiiterTweetView](/_screenshots/XTwitter2.png?raw=true "Tweet view") ![XTwitterSendTweet](/_screenshots/XTwitter3.png?raw=true "Send Tweet View")

# Features

The demo allows:

- To load the last 40 tweets from the timeline of the connected user.
- To visualize the detail of a tweet.
- To make a tweet and the possibility of adding an image to it.
    
# Configuration
Before launching XTwitter, it is necessary to modify the API Keys in other to load the timeline of a specific user, and being ablle to make tweet in its name. These keys are referenced in the **TwitterApiData.cs**, located in the **XTwitter.Forms** project.

```C#
public const string TWITTER_ACCESS_TOKEN = "EDIT";
public const string TWITTER_ACCESS_TOKEN_SECRET = "EDIT";
public const string TWITTER_CONSUMER_KEY = "EDIT";
public const string TWITTER_CONSUMER_SECRET = "EDIT";
```

In other to get these keys it is necessary:

- To create an app in the [Twitter Application Manager].
- To go to **Key and Access Tokens**.
- In this section, you can find and generate the necessary keys.

[Xamarin.Forms]:http://xamarin.com/forms
[Meetup]:http://www.meetup.com/Barcelona-Mobile-NET-Developers-Group/
[Barcelona Mobile .NET Developers Group]:http://bcnmobilegroup.azurewebsites.net/
[Twitter Application Manager]:https://apps.twitter.com/
