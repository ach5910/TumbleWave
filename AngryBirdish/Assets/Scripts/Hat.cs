using UnityEngine;
using UnityEngine.UI;

public class Hat : MonoBehaviour {
    public Rigidbody2D projectile;
    public Text countText;
    private int count;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            count = count + 1;
            countText.text = "Score: " + count.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            count = count + 1;
        }
    }
}
