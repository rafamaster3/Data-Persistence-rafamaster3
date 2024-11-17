using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance;         //Convierte en clase accesible en todo el proyecto

    public string playerName;

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

    }

   
}

