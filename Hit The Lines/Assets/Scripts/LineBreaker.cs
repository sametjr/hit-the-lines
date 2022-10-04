using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBreaker : MonoBehaviour //Will be responsible from animate the line renderer component of obstacles
{
    private static int howManyPieces = 3;



    public static LineRenderer[] SeperateLineIntoPieces(GameObject _star)
    {
        Vector2 startingPoint = Vector2.zero;
        Vector2 endingPoint = _star.GetComponent<EdgeCollider2D>().points[1];

        Vector2 xInterval = new Vector2(startingPoint.x, endingPoint.x);
        Vector2 yInterval = new Vector2(startingPoint.y, endingPoint.y);


        Vector3[] pos= new Vector3[howManyPieces + 1];
        

        for(int i = 1; i <= howManyPieces; i++)
        {
            float xPoint = (xInterval.y - xInterval.x) / (float)i;
            float yPoint = (yInterval.y - yInterval.x) / (float)i;

            pos[i] = new Vector3(xPoint, yPoint, 0);
        }
        _star.GetComponent<LineRenderer>().positionCount = howManyPieces + 1;
        _star.GetComponent<LineRenderer>().SetPositions(pos);

        return null;
    }
}
