using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour
{
    public GUIStyle style;
    public float xPos = 80, yPos = 23;

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 1220.0f, Screen.width / 881.0f, 1.0f));
        GUI.Label(new Rect(xPos, yPos, 50, 100), GameManager.cash.ToString(), style);    
    }
}
