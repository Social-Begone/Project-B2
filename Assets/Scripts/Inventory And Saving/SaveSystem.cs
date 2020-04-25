using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Use simple 'using' statement", Justification = "Not usable in Unity.")]
public static class SaveSystem
{
    private const string fileName = "player.DAT";
    public static readonly string path =
        Application.persistentDataPath
#if UNITY_IOS || UNITY_ANDROID || UNITY_STANDALONE_LINUX
        + '/'
#elif UNITY_STANDALONE_WIN
        + '\\'        
#endif
        + fileName;

    public static PlayerData LastSave { get; private set; }

    private static bool hasBeenLoaded;

    public static void SavePlayer(Player player) {
        using (var stream = new FileStream(path, FileMode.Create)) {
            LastSave = new PlayerData(player);
            new BinaryFormatter().Serialize(stream, LastSave);
        }
    }

    public static PlayerData LoadPlayer() {
        if (hasBeenLoaded) return LastSave;

        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate)) {
            hasBeenLoaded = true;
            return LastSave = stream.Length > 0
                ? new BinaryFormatter().Deserialize(stream) as PlayerData
                : new PlayerData();
        }
    }
}
