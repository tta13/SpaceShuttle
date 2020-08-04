using System.IO;
using UnityEngine;

public class JsonSaveLoader : MonoBehaviour, ISaveLoader
{
    public T Load<T>(string path) where T : class
    {
        FileStream fs = new FileStream(path, FileMode.Open);

        StreamReader reader = new StreamReader(fs);

        var data = JsonUtility.FromJson<T>(reader.ReadToEnd());

        reader.Close();
        reader.Dispose();

        fs.Close();
        fs.Dispose();

        return data;
    }

    public void Save<T>(T data, string path) where T : class
    {
        FileStream fs = new FileStream(path, FileMode.Create);

        StreamWriter writer = new StreamWriter(fs);

        string jsonData = JsonUtility.ToJson(data);

        Debug.Log(jsonData);

        writer.Write(jsonData);
        writer.Close();
        writer.Dispose();

        fs.Close();
        fs.Dispose();
    }
}
