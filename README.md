# Concurrent-Player-Prefs-For-Unity
Unity's PlayerPrefs isn't thread safe; this is a similar system that is thread safe.

Currently it does require Json.NET for perfomance reasons, and because it cannot be used with XML serializer;
you may change to JavaScriptSerializer, DataContractSerializer or BinaryFormatter, though. I find Json.NET easier overall.
