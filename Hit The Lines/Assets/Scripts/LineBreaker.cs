using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBreaker : MonoBehaviour //Will be responsible from animate the line renderer component of obstacles
{
    private static int howManyPieces = 3;
    private static float breakingPower = 2.0f;

    LineRenderer starRenderer, childRenderer;
    Vector3[] starRendererPos, childRendererPos;
    
    private float lerpValue = 3.0f;
    public static LineRenderer[] SeperateLineIntoPieces(GameObject _star, Vector2 _hitPoint)
    {
        LineBreaker lb =  _star.AddComponent<LineBreaker>();

        lb.starRenderer = _star.GetComponent<LineRenderer>();
        lb.childRenderer = _star.transform.GetChild(0).GetComponent<LineRenderer>();
    
        ColorizeChildLine(lb.starRenderer, lb.childRenderer);

        Vector2 startingPoint = lb.starRenderer.GetPosition(0); //_star.GetComponent<EdgeCollider2D>().points[0];
        Vector2 endingPoint = lb.starRenderer.GetPosition(1);



        lb.starRendererPos = new Vector3[2];
        lb.childRendererPos = new Vector3[2];

        lb.starRendererPos[0] = startingPoint;
        lb.starRendererPos[1] = _hitPoint;
        lb.childRendererPos[0] = _hitPoint;
        lb.childRendererPos[1] = endingPoint;

        lb.starRenderer.SetPositions(lb.starRendererPos);
        lb.childRenderer.SetPositions(lb.childRendererPos);





        return null;
    }

    private static void ColorizeChildLine(LineRenderer _starLr, LineRenderer _childLr)
    {
        _childLr.startColor = _starLr.endColor;
        _childLr.endColor = _starLr.startColor;
    }

    private void Update() {
        starRendererPos[1] = Vector3.Lerp(starRendererPos[1], starRendererPos[0], lerpValue * Time.deltaTime);
        childRendererPos[0] = Vector3.Lerp(childRendererPos[0], childRendererPos[1], lerpValue * Time.deltaTime);

        starRenderer.SetPositions(starRendererPos);
        childRenderer.SetPositions(childRendererPos);

        if((starRendererPos[0] - starRendererPos[1]).magnitude <= .001f && (childRendererPos[0] - childRendererPos[1]).magnitude <= .001f)
        {
            starRenderer.enabled = false;
            childRenderer.enabled = false;
            Destroy(this);
        } 
        


    }
}
