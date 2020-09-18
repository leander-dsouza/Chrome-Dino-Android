# Chrome-Dino-Android
A custom replication of the Chrome's Dino offline game on Android using Unity 2D.

## Gameplay





## Installation (TL;DR)

If you're not interested in setting up the Assets in your Unity 2D Project, and just want to install the final apk on your Android device; the apk is present [here](https://github.com/leander-dsouza/Chrome-Dino-Android/raw/master/Google's%20Dinosaur/Build/Google's%20T-Rex.apk) for download.


## Setup in Unity 2D

* Create a new 2D Project in the Unity Editor.
* Download Android Build Support as an add-on. If the download fails for some reason, download the SDK through [Android Studio](https://developer.android.com/studio/?gclid=Cj0KCQjwtZH7BRDzARIsAGjbK2YdCD80R12alROYyLURJUPHTxilCAwvNl5kqhTIyLfT0psg6MHk1Z8aAiHeEALw_wcB&gclsrc=aw.ds) and the NDK through [here](https://dl.google.com/android/repository/android-ndk-r19-windows-x86_64.zip).
* After you enter your project, make sure to change build target to Android.
* Replace the Assets folder of your project with [mine](https://github.com/leander-dsouza/Chrome-Dino-Android/tree/master/Google's%20Dinosaur/Assets).
* Before buiding your project, note the following settings:
     
    * In Player Settings, modify the orientation to **Landscape Left**.
    * Change the Scripting Backend parameter to **IL2CPP**, this helps to enable us the **ARM64** in the Target Architecture.
    * Finally build your project to generate the APK.
