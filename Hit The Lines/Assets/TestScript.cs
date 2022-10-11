using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{

    public static void SaveData(int _score)
    {
        PlayerPrefs.SetInt("highScore", _score);
    }
}
