using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuScene : MonoBehaviour
{

    [SerializeField] TMP_InputField inputField;       //Gets current player name from input field

  
    public void SetPlayerName(string playerName)
    {
        PersistenceManager.instance.currentPlayer = inputField.text;
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}

