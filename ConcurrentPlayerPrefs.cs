using System.Collections.Concurrent;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class ConcurrentPlayerPrefs {
    
    private static ConcurrentDictionary<string, dynamic> d = new ConcurrentDictionary<string, dynamic>();
    private static object locker = new object();

#if !UNITY_EDITOR && UNITY_ANDROID
    public const string SavesDirectory = @"sdcard/somefolder/";
    public const string SavesFile = SavesDirectory + @"/somefile";
#elif UNITY_EDITOR || UNITY_STANDALONE_WIN
    public const string SavesDirectory = "D:\\somefolder\\";
    public const string SavesFile = SavesDirectory + "somefile";
#endif

    public static int GetInt(string Key, int DefaultValue = 0) { return (int)d.GetOrAdd(Key, DefaultValue);}

    public static float GetFloat(string Key, float DefaultValue = 0.0f) { return (float)d.GetOrAdd(Key, DefaultValue); }

    public static string GetString(string Key, string DefaultValue = "") { return (string)d.GetOrAdd(Key, DefaultValue); }

    public static void SetInt(string Key, int Value) { d.AddOrUpdate(Key, Value, (CurrentKey, CurrentValue) => Value); }

    public static void SetFloat(string Key, float Value) { d.AddOrUpdate(Key, Value, (CurrentKey,CurrentValue) => Value); }

    public static void SetString(string Key, string Value) { d.AddOrUpdate(Key, Value, (CurrentKey, CurrentValue) => Value); }

    public static void Save() {
        lock (locker) {
            File.WriteAllText(SavesFile, JsonConvert.SerializeObject(d));
        }
    }

    public static void Load() {
        lock (locker) {
                if (!Directory.Exists(SavesDirectory))
                    Directory.CreateDirectory(SavesDirectory);
                if (!File.Exists(SavesFile))
                    File.Create(SavesFile);
                else
                    d = JsonConvert.DeserializeObject<ConcurrentDictionary<string, dynamic>>(File.ReadAllText(SavesFile));
        }
    }

    public static void DeleteKey(string Key) {
        lock (locker) {
            d.TryRemove(Key, out dynamic k);
        }
    }

    public static void DeleteAll() {
        lock (locker) {
            d.Clear();
        }
    }

}

