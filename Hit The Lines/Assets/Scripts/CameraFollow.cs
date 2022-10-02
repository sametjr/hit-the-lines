using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpValue = 3;
    private Vector3 cameraDestination;
    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(
                    transform.position.x < 0 ?
                    
                    Mathf.Max(playerTransform.position.x, 
                    GameManager.Instance.leftWallRenderer.bounds.min.x +
                     GameManager.Instance.leftWallRenderer.size.x / 2 +
                      GameManager.Instance._camera.orthographicSize / 2) :


                    Mathf.Min(playerTransform.position.x,
                     GameManager.Instance.rightWallRenderer.bounds.max.x - 
                      GameManager.Instance.rightWallRenderer.size.x / 2 - 
                       GameManager.Instance._camera.orthographicSize / 2),
                        transform.position.y, transform.position.z),
            lerpValue * Time.deltaTime
        ); // Control the camera to not to show the outside of the map.


    }
}
