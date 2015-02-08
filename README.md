# XTwitter

XTwitter es un cliente Twitter muy básico implementado en [Xamarin.Forms], y que servió como demo para el primer [Meetup] del grupo [Barcelona Mobile .NET Developers Group].

![XTwitterTimeline](/_screenshots/XTwitter1.png?raw=true "Timeline") ![XTwiiterTweetView](/_screenshots/XTwitter2.png?raw=true "Tweet view") ![XTwitterSendTweet](/_screenshots/XTwitter3.png?raw=true "Send Tweet View")

# Funcionalidades

La demo permite:

- Cargar los últimos 40 tweets del timeline del usuario conectado.
- Visualizar el detalle de un tweet.
- Realizar un tweet, pudiendo agregar una imagen al mismo.
    
# Configuración
Antes de ejecutar XTwitter, es necesario modificar las API Keys necesarias para cargar el timeline de una cuenta específica de usuario, y poder hacer Tweets en su nombre. Estas claves se encuentran en la clase **TwitterApiData.cs**, ubicada en el proyecto **XTwitter**:

```C#
public const string TWITTER_ACCESS_TOKEN = "EDIT";
public const string TWITTER_ACCESS_TOKEN_SECRET = "EDIT";
public const string TWITTER_CONSUMER_KEY = "EDIT";
public const string TWITTER_CONSUMER_SECRET = "EDIT";
```

Para conseguir estas claves es necesario:

- Crear una app en [Twitter Application Manager].
- Ir a **Key and Access Tokens**.
- En esta sección, podréis encontrar y generar las claves necesarias.

[Xamarin.Forms]:http://xamarin.com/forms
[Meetup]:http://www.meetup.com/Barcelona-Mobile-NET-Developers-Group/
[Barcelona Mobile .NET Developers Group]:http://bcnmobilegroup.azurewebsites.net/
[Twitter Application Manager]:https://apps.twitter.com/
