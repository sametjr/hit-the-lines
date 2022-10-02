using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndWallsMovement : MonoBehaviour
{
    
    private void Update() {
        transform.Translate(Vector3.up * Time.deltaTime * GameManager.Instance.GameSpeed);
    }
}
