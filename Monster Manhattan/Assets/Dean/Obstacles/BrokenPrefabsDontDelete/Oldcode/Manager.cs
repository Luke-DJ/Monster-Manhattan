using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public int difficulty = 1;

    public Text text;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            difficulty += 1;
        }
        text.text = difficulty.ToString();
    }
}
