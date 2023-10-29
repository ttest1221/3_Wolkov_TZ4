using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private string keyPlayer = "Nickname";
    private string keyScore = "Score";
    public List<PlayerData> GetLeaders()
    {
        List<PlayerData> list = new List<PlayerData>();
        for (int i = 0; i < 3; i++)
        {
            list.Add(new PlayerData()
            {
                nickname = PlayerPrefs.GetString(keyPlayer + (i + 1), "None"),
                score = PlayerPrefs.GetInt(keyScore + (i + 1), 0),
            });
        }
        return list;
    }
}
