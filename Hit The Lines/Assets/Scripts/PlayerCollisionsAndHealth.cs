using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsAndHealth : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] private float lerpValue;
    private int _colorIndex = 0;
    private SpriteRenderer _playerGfxSpriteRenderer;

    private void Start() {

        _playerGfxSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // ObjectPool.DisableStarAndAddToQueue(other.gameObject);


        // TODO --> LINE BREAK
        LineBreaker.SeperateLineIntoPieces(other.gameObject, other.ClosestPoint(transform.position));
        // other.gameObject.AddComponent<LineBreaker>();



        
        // other.gameObject.GetComponent<LineRenderer>().enabled = false;
        other.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        
        Vector2 firstPos = other.gameObject.GetComponent<LineRenderer>().GetPosition(0);
        Vector2 secondPos = other.gameObject.GetComponent<LineRenderer>().GetPosition(1);
        

        float _magnitude = Vector3.Magnitude(firstPos - secondPos);

        GameManager.Instance.Score += (10 - Mathf.RoundToInt(_magnitude));
        FindObjectOfType<UIControl>().UpdateScore(GameManager.Instance.Score);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.PlayerHitObstacle();
            _colorIndex++;
            _playerGfxSpriteRenderer.color = colors[_colorIndex];
        }
    }

    // private void Update() {
    //     _playerGfxColor = Color.Lerp(_playerGfxColor, colors[_colorIndex], lerpValue * Time.deltaTime);
    // }
}
