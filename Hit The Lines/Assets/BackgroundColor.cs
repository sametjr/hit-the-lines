using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField, Range(0.1f, 10f)] private float timeToChangeColor;
    [SerializeField] private float lerpValue = 3f;
    private int colorIndex = 0;

    private void Start() {
        StartCoroutine(UpdateColorTick());
    }
    void Update()
    {
        GameManager.Instance._camera.backgroundColor = Color.Lerp(GameManager.Instance._camera.backgroundColor, colors[colorIndex], lerpValue * Time.deltaTime);
    }

    private IEnumerator UpdateColorTick()
    {
        while(true)
        {
            
            colorIndex++;
            if(colorIndex == colors.Length) colorIndex = 0;
            yield return new WaitForSecondsRealtime(timeToChangeColor);
        }
    }

}
