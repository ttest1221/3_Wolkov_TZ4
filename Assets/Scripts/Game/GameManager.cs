using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private MovingBackground _backgroundMovement;
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _sportcarSprite;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _lastScoreText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text startTimerText;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _nicknamePanel;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Button _acceptNicknameButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _buySportcarButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private Button _toGameButton;
    [SerializeField] private InputField _nicknameInput;
    

    public LeaderBoard leaderBoard;
    public SaveManager saveManager;
    public string nickname;
    public int score;
    public int bestScore;
    public float speed;
    public int money;
    public int startTimer = 3;
    private int _lastScore;
    
    private void Start()
    {
        _shop.SetActive(false);
        _gameOver.SetActive(false);
        HideGame();
        _acceptNicknameButton.onClick.AddListener(() => AcceptNicknameClick());
        _restartButton.onClick.AddListener(() => RestartClick());
        _pauseButton.onClick.AddListener(() => PauseClick());
        _toMenuButton.onClick.AddListener(() => ToMenuClick());
        _toGameButton.onClick.AddListener(() => ToGameClick());
        _buySportcarButton.onClick.AddListener(() => BuySportcarClick());
    }

    private void BuySportcarClick()
    {
        if(money >= 2)
        {
            money -= 2;
            _player.spriteRenderer.sprite = _sportcarSprite;
            TextsUpdate();
        }
    }

    private void AcceptNicknameClick()
    {
        nickname = _nicknameInput.text;
        ShowGame();
        _nicknamePanel.SetActive(false);
        TextsUpdate();
        StartCoroutine(StartTimer());
    }
    private void HideGame()
    {
        _game.SetActive(false);
        _ui.SetActive(false);
        _camera.SetActive(true);
    }
    private void ShowGame()
    {
        _game.SetActive(true);
        _ui.SetActive(true);
        _camera.SetActive(false);
    }
    private void ToGameClick()
    {
        ShowGame();
        Play();
        _shop.SetActive(false);
        
    }
    private void PauseClick()
    {
        HideGame();
        Pause();
        _shop.SetActive(true);
    }
    private IEnumerator StartTimer()
    {
        startTimerText.gameObject.SetActive(true);
        if (startTimer != 0)
        {
            yield return new WaitForSeconds(1);
            startTimer--;
            TextsUpdate();
            StartCoroutine(StartTimer());
        }
        else
        {
            Play();
            startTimerText.gameObject.SetActive(false);
        }
            
    }
    
    public void TextsUpdate()
    {
        _scoreText.text = "Current: " + score.ToString();
        _bestScoreText.text = "Best: " + bestScore.ToString();
        _lastScoreText.text = "Last: " + _lastScore.ToString();
        moneyText.text = "Δενόγθ: " + money.ToString();
        startTimerText.text = startTimer.ToString();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
    private void Play()
    {
        Time.timeScale = 1f;
    }
    private void RestartClick()
    {
        _cameraMovement.transform.position += new Vector3(_cameraMovement.transform.position.x, _cameraMovement.transform.position.y + 50, 0);
        _gameOver.SetActive(false);
        ShowGame();
        Play();
        speed = 0;
        _cameraMovement.cameraSpeed = 4;
        _backgroundMovement.backgroundSpeed = 0.1f;
        startTimer = 3;
       
        TextsUpdate();
        StartCoroutine(StartTimer());
    }
    private void ToMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateSpeed()
    {
        _cameraMovement.cameraSpeed += speed;
        _backgroundMovement.backgroundSpeed += speed;
    }
    public void GameOver()
    {
        _lastScore = score;
        if (score > bestScore)
            bestScore = score;
        score = 0;
        saveManager.SaveLeader(leaderBoard.GetLeaders());
        HideGame();
        Pause();
        _gameOver.SetActive(true);
    }
}
