using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {

    public static int count;
    private Text score;
	void Start () {
        count = 0;
        score = GetComponent<Text>();
	}
	
	void Update()
    {
        score.text = "Score: " + count;
    }
}
