using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/playerdata.save";

    public static void Save(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(savePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }

        Debug.Log("Game saved/ Juego guardado.");
    }

    public static PlayerData Load()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }
        }
        else
        {
            Debug.Log("No se guardo el archivo. Creando PlayerData.");
            //return new PlayerData(0,60f,"", new List<string>());
            return new PlayerData(0);
        }
    }

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/playerdata.save";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Progreso borrado.");
        }
    }
}
