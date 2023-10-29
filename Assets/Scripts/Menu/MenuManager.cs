using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _leadersButton;
    [SerializeField] private Button _toGameButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _leaders;
    [SerializeField] private Text _leadersText;
    [SerializeField] private LeaderBoard _leaderBoard;

    private void Awake()
    {
        _leadersButton.onClick.AddListener(() => LeadersTableClick());
        _toGameButton.onClick.AddListener(() => NewGameClick());
        _toMenuButton.onClick.AddListener(() => VisibleMenuClick());
        _leaders.gameObject.SetActive(false);
        
    }
    private void NewGameClick()
    {
        SceneManager.LoadScene("Game");
    }
    private void LeadersTableClick()
    {
        _menu.gameObject.SetActive(false);
        _leaders.gameObject.SetActive(true);
        List<PlayerData> leaders = _leaderBoard.GetLeaders();
        for(int i = 0; i < leaders.Count; i++)
        {
            _leadersText.text += $"{leaders[i].nickname} - {leaders[i].score} очков\n";
        }
        
    }
    private void VisibleMenuClick()
    {
        _menu.gameObject.SetActive(true);
        _leaders.gameObject.SetActive(false);
    }
}
