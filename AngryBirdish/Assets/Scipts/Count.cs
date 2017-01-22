using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {

    public static long count;
    public static Text score;
	void Start () {
        count = 0;
        score = GetComponent<Text>();
	}
	
	void Update()
    {
        score.text = "Score: " + count;
    }
}
