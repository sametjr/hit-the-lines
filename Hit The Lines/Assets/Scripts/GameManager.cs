using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField, Range(0,20)] private float gameSpeed;
    [SerializeField, Range(0, .01f)] float gameSpeedMultiplier = .0001f;

    private float secondsToSpawn = 1;
    private int playerHealth = 3;
    private int _score = 0;

    public SpriteRenderer leftWallRenderer => this.leftWall.GetComponent<SpriteRenderer>();
    public SpriteRenderer rightWallRenderer => this.rightWall.GetComponent<SpriteRenderer>();
    public Camera _camera => this._cam;
    public Transform playerTransform => this._player.transform;
    public float GameSpeed => this.gameSpeed;
    public Vector3 groundPosition => this._groundTransform.position;
    public float SecondsToSpawn => this.secondsToSpawn;
    public int PlayerHealth => this.playerHealth;

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
        this.gameSpeed += gameSpeedMultiplier;
        this.secondsToSpawn -= gameSpeedMultiplier / 4;
    }

    public void PlayerHitObstacle()
    {
        this.playerHealth--;
        GameOver();
    }

    private void GameOver()
    {
        //TODO 
        Debug.Log("Game Over !");
    }
}
