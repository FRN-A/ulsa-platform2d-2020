using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platform2DUtils.MemorySystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button btnNewGame;
    [SerializeField]
    Button btnLoadGame;
    [SerializeField]
    Button btnQuitGame;

    void Awake()
    {
        btnLoadGame.onClick.AddListener(LoadGame);
        btnNewGame.onClick.AddListener(NewGame);
        btnQuitGame.onClick.AddListener(QuitGame);
    }
    void Start()
    {
        btnLoadGame.gameObject.SetActive(MemorySystem.DataExists);
    }

    public void LoadGame()
    {
        
    }

    public void NewGame()
    {
        GameManager.instance.GameData = new GameData();
        MemorySystem.SaveData(GameManager.instance.GameData);
        SceneManager.LoadScene(1);
        btnLoadGame.gameObject.SetActive(false);
        GameManager.instance.Score.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
Debug.Log("Quit");
    }
}
