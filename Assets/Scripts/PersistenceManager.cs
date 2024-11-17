using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance;         //Convierte en clase accesible en todo el proyecto

    public string currentPlayer;
    public string highScorePlayer;
    public int highScore;

    //Método predefinido de Unity cargado solo la primera vez que se instancia la clase, sin importar si la escena es loaded or reloaded múltiples veces
    private void Awake()
    {



        //Destruye duplicados de MainManager object y evita que el original sea destruido al cambiar de escena
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [System.Serializable]

    class SaveData
    {
        public string lastPlayer;
        public string highScorePlayer;
        public int highScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.lastPlayer = currentPlayer;
        data.highScorePlayer = highScorePlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayer = data.lastPlayer;
            highScorePlayer = data.highScorePlayer;
            highScore = data.highScore;
        }
    }
}

