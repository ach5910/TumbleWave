using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hat : MonoBehaviour {
    public Rigidbody2D projectile;
    public Camera camera;
    public Text countText;
    private int count;

    void Start()
    {
        count = 0;
    }
   // void SetCountText(int count)
  //  {
    //    countText.text = "Score: " +  count.ToString();
    //}

    void Update()
    {
        //if (other.GetComponent<Rigidbody2D>() == projectile)
        if (Input.GetKeyDown(KeyCode.G))
        {
            count = count + 1;
            countText.text = "Score: " + count.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.GetComponent<Rigidbody2D>() == projectile)
        if (Input.GetKeyDown(KeyCode.G))
        {
            count = count + 1;
           // SetCountText(count);
        }
    }
}
