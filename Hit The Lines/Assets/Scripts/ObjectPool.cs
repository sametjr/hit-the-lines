using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private int poolSize = 50;
    [SerializeField] private Material defaultLineMaterial;
    private static Queue<GameObject> starPool;
    private static List<GameObject> activeStarsList;


    private void Start()
    {
        starPool = new Queue<GameObject>();
        activeStarsList = new List<GameObject>();
        CreateAllStarObjects();
    }

    private void CreateAllStarObjects()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instantiatedObject = Instantiate(starPrefab);
            instantiatedObject.transform.parent = this.transform; // Make it child of ObjectPool Game Object, so it will look good on Hierarchy
            instantiatedObject.SetActive(false);    // All of them will be invisible until we use them.
            starPool.Enqueue(instantiatedObject); // Add the new created star to the Queue
        }
    }

    public static GameObject GetStarFromPool(bool getActive = true) // Get the object without setting a certain position
    {
        GameObject head = starPool.Dequeue();
        if(head.GetComponent<LineRenderer>().enabled == false) head.GetComponent<LineRenderer>().enabled = true;
        if(head.GetComponent<EdgeCollider2D>().enabled == false) head.GetComponent<EdgeCollider2D>().enabled = true;
        if (getActive) head.SetActive(true);
        activeStarsList.Add(head);
        return head;
    }

    public static GameObject GetStarFromPool(Vector2 _pos, bool getActive = true) // Get the head object by setting its position
    {
        GameObject head = starPool.Dequeue();
        if(head.GetComponent<LineRenderer>().enabled == false) head.GetComponent<LineRenderer>().enabled = true;
        if(head.GetComponent<EdgeCollider2D>().enabled == false) head.GetComponent<EdgeCollider2D>().enabled = true;
        if (getActive) head.SetActive(true);
        head.transform.position = _pos;
        activeStarsList.Add(head);
        return head;
    }

    public static Vector3 ClosestStarPosition(GameObject _star)
    {
        float minDistance = Mathf.Infinity;
        Vector3 closestStarPosition = Vector3.zero;
        foreach (GameObject _other in activeStarsList)
        {
            float distance = Mathf.Abs(Vector3.Magnitude(_star.transform.position - _other.transform.position));
            if (distance <= minDistance && Mathf.Abs(Mathf.RoundToInt(distance)) != 0)
            {
                minDistance = distance;
                closestStarPosition = _other.transform.position;
            }
        }
        return closestStarPosition;

    }

    public static void DisableStarsUnderGround()
    {
        foreach (GameObject _star in activeStarsList.ToArray())
        {
            if(_star.transform.position.y <= GameManager.Instance.groundPosition.y)
            {
                _star.SetActive(false);
                activeStarsList.Remove(_star);
                starPool.Enqueue(_star);
            }
        }   // This loop gets the copy of array items if I dont convert the list to array, so I cant modify them.

        // for (int i = 0; i < activeStarsList.Count; i++)
        // {
        //     if (activeStarsList[i].transform.position.y <= GameManager.Instance.groundPosition.y)
        //     {
        //         activeStarsList[i].SetActive(false);
        //         activeStarsList.Remove(activeStarsList[i]);
        //         starPool.Enqueue(activeStarsList[i]);
        //     }
        // }
    }

    // public static void DisableStarAndAddToQueue(GameObject _star)
    // {
    //     _star.SetActive(false);
    //     activeStarsList.Remove(_star);
    //     starPool.Enqueue(_star);
    // }
}
