using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public void UpdateScore(int _value)
    {
        scoreText.text = _value.ToString();
    }
}
