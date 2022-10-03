using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private float thresholdValue = 3;
    private Vector3 _playerPosition;
    private float _distanceFromPlayer = 10;
    void Start()
    {
        StartCoroutine(SpawnStar());
    }

    private IEnumerator SpawnStar()
    {
        while (true)
        {
            ObjectPool.DisableStarsUnderGround();
            GameObject createdStar = SpawnStarFromPool();
            Vector3 closestStarPos = ObjectPool.ClosestStarPosition(_star: createdStar);
            HandleLineRenderer(createdStar, closestStarPos);
            HandleEdgeCollider(createdStar, closestStarPos);
            yield return new WaitForSecondsRealtime(GameManager.Instance.SecondsToSpawn);
        }
    }

    private GameObject SpawnStarFromPool()
    {
        float randomX = Random.Range(GameManager.Instance.leftWallRenderer.bounds.max.x, GameManager.Instance.rightWallRenderer.bounds.min.x);
        float randomY = Random.Range(_distanceFromPlayer + thresholdValue, _distanceFromPlayer - thresholdValue) + GameManager.Instance.playerTransform.position.y;

        return ObjectPool.GetStarFromPool(new Vector2(randomX, randomY)); // Spawn star every x second at a random point between the walls and a random heigh.
    }

    private void HandleEdgeCollider(GameObject _createdStar, Vector3 _closestStarPos)
    {
        List<Vector2> positions = new List<Vector2>();
        positions.Add(_createdStar.transform.InverseTransformPoint(_createdStar.transform.position));
        positions.Add(_createdStar.transform.InverseTransformPoint(_closestStarPos));

        EdgeCollider2D ec = _createdStar.GetComponent<EdgeCollider2D>();
        ec.SetPoints(positions);
        ec.points = positions.ToArray();
    }

    private void HandleLineRenderer(GameObject _createdStar, Vector3 _closestStarPos)
    {
        LineRenderer lr = _createdStar.GetComponent<LineRenderer>();
        List<Vector3> positions = new List<Vector3>();
        positions.Add(_createdStar.transform.position);
        positions.Add(_closestStarPos);

        lr.SetPositions(positions.ToArray());
        lr.startColor = GetRandomColor();
        lr.endColor = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        float randomRedValue = Random.Range(0f, 1f);
        float randomGeenValue = Random.Range(0f, 1f);
        float randomBlueValue = Random.Range(0f, 1f);

        Color color = new Color(randomRedValue, randomGeenValue, randomBlueValue, 1);
        return color;
    }


}
