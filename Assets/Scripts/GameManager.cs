using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    playing,
    home,
    pause,
    option
}

public class GameManager : MonoBehaviour
{
    public static GameState gameState; //ゲームステータス

    bool onCity;
    bool onHome;
    

    void Start()
    {
        gameState = GameState.playing; //ゲームステータスの取得
        
        //シーン情報の取得
        Scene currentScene = SceneManager.GetActiveScene();
        //シーン名の取得
        string sceneName = currentScene.name;

        

    }

    
    void Update()
    {
        
    }
}
