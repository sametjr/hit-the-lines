using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }

    #endregion

    [SerializeField] private GameObject leftWall, rightWall;
    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private UIControl uIControl;
    [SerializeField, Range(0,20)] private float gameSpeed;
    [SerializeField, Range(0, .01f)] private float gameSpeedMultiplier = .0001f;

    private float secondsToSpawn = 1;
    private int playerHealth = 3;
    private int _score = 0;
    private bool _isGamePaused = false, _isGameOver = false;

    public SpriteRenderer leftWallRenderer => this.leftWall.GetComponent<SpriteRenderer>();
    public SpriteRenderer rightWallRenderer => this.rightWall.GetComponent<SpriteRenderer>();
    public Camera _camera => this._cam;
    public Transform playerTransform => this._player.transform;
    public float GameSpeed => this.gameSpeed;
    public Vector3 groundPosition => this._groundTransform.position;
    public float SecondsToSpawn => this.secondsToSpawn;
    public int PlayerHealth => this.playerHealth;
    public bool isGamePaused => this._isGamePaused;

    public int Score
    {
        get
        {
            return this._score;
        }
        set
        {
            this._score = value;
        }
    }


    private void FixedUpdate() {
        this.gameSpeed += gameSpeedMultiplier; //Game speed increases over time
        this.secondsToSpawn -= gameSpeedMultiplier / 4; // Obstacle spawn rate increases over time.
    }

    public void PlayerHitObstacle()
    {
        this.playerHealth--;
        if(this.playerHealth <= 0) GameOver();
    }

    private void GameOver()
    {
        //TODO 
        _isGameOver = true;
        uIControl.ShowGameOverScreen();
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        if(!_isGamePaused && !_isGameOver)
        {
            _isGamePaused = true;
            uIControl.ShowGamePausedMenu();
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        if(_isGamePaused && !_isGameOver)
        {
            _isGamePaused = false;
            Time.timeScale = 1;
            uIControl.HideGamePausedScreen();
        }
    }

    public void RestartGame()
    {
        if(_isGameOver && !_isGamePaused)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
