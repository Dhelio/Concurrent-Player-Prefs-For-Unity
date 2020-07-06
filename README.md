# Concurrent-Player-Prefs-For-Unity
Unity's PlayerPrefs isn't thread safe; this is a similar system that is thread safe.

Currently it does require Json.NET for perfomance reasons, and because it cannot be used with XML serializer;
you may change to JavaScriptSerializer, DataContractSerializer or BinaryFormatter, though. I find Json.NET easier overall.

You can download Json.NET in Unity from NuGet; if you don't know how to set up NuGet packages for Unity, add the this plugin to do the job for you: https://github.com/GlitchEnzo/NuGetForUnity
