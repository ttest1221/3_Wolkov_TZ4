using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private string keyPlayer = "Nickname";
    private string keyScore = "Score";



    public void SaveLeader(List<PlayerData> data)
    {
        PlayerData currentPlayer = GetCurrentPlayer();
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].score < currentPlayer.score)
            {
                PlayerPrefs.SetString(keyPlayer + (i + 1), currentPlayer.nickname);
                PlayerPrefs.SetInt(keyScore + (i + 1), currentPlayer.score);
                break;
            }
        }
    }
    
    public PlayerData GetCurrentPlayer()
    {
        PlayerData data = new PlayerData() { nickname = _gameManager.nickname, score = _gameManager.bestScore };
        return data;
    }
}
public class PlayerData
{
    public string nickname;
    public int score;
}
