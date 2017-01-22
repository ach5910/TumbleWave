using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {
    public Rigidbody2D projectile;
    public Text countText;
    public bool coinHit;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            Count.count += 100;
            coinHit = true;
            Destroy(gameObject);
        }
    }
}
