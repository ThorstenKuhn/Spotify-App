# Spotify-App
Spotify Client Controller

Dieses Projekt sollte mir den Umgang mit einer API näher bringen. 
Tatsächlich mag ich es nicht, dass gefühlt immer wieder die gleichen Tracks abgespielt werden. 
Deshalb sollte dieses auch die Möglichkeit beinhalten Tracks mehr zufällig in die Warteschlange hinzuzufügen.

Leider ist die API noch nicht sehr ausgereift was spezielle Befehle oder Informationen anbelangt.
Im Moment ist es auch nur sehr schwer möglich einen Player zu implementieren, der Tracks von Spotify streamen kann.

Für meine Sicherheit habe ich die ClientID und das ClientSecret aus meinem Code entfernt. 
Wer das Programm trotzdem testen will, habe ich eine App_Spotify.config hinzugefügt mit einer kleinen Erklärung, welche dann in den selben Ordner wie die .exe kommt.

>This project was intended to teach me how to use an API.
>In fact, I don't like that it feels like the same tracks are being played over and over again.
>Therefore, this should also include the option to add more random tracks to the queue.

>Unfortunately, the API is not yet very mature when it comes to special commands or getting information from it.
>At the moment it is also very difficult to implement a player that can stream tracks from Spotify.

>For security I removed the ClientID and ClientSecret from my code.
>If you still want to test the program, I have added an App_Spotify.config with a small explanation, which then goes into the same folder as the .exe.

## Features:

- skip for-/backward

- play/pause

- skip to time in playing track.

- change between avaiable devices

- login through browser

- display playlists with their tracks and tracks in queue

- add selected track to queue

- start new play from Playlist
  * optional with 50 random tracks added to personal queue (RealShuffle)

 ## Future Updates

  Waiting for Spotify Web API to include more possibilites to include here. 
  
  Some Features i hope for are:

  - more control over the queue.
    - display tracks added by user
    - edit queue order
    - remove track from queue
  - info and control over the radio mode
  - get the playlists that are "added to profile" (they are now excluded from request)

  Things that may come in some updates:

  - nicer GUI (may includes changing it to a WPF)
    - add control to change volume
    - filter playlists
    - display more info about each track / playlist
    - change progress bar to something nicer
    - display devices through icon/button like spotify has
  - making the Interface more independent from excuted code (lags here and there through requests updating data)
    -maybe by making a new thread
  - save the refresh token safely for longer than runtime

## Contribution

  This is one of my first published projects, so if anyone has suggestions about new features or better code, please let me know.
  
  I am also thankful for reporting bugs or crashes.
