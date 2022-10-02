using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScaler : MonoBehaviour
{
    

    private void Update() {
        if(GameManager.Instance.playerTransform.position.y >= GameManager.Instance.leftWallRenderer.bounds.center.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        } // İf player arrives the half of the wall, the wall size on Y axes gets doubled.
        // This is essential for preventing the player from going out of the map.
    }
}
