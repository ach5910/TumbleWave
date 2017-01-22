using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {
	public Rigidbody2D projectile;
	public float resetSpeed = 0.025f;
    public Transform hiRight;
    public Transform hiLeft;
    public Transform midRight;
    public Transform lowRight;
    public Transform midLeft;
    public Transform lowLeft;

    private float resetSpeedSqr;
	private SpringJoint2D spring;
    private bool over;

	void Start()
	{
		resetSpeedSqr = resetSpeed * resetSpeed;
		spring = projectile.GetComponent <SpringJoint2D> ();
        over = false;
	}
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.R))
            restartCurrentScene();
        if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr)
            checkTarget();
	}
    void checkTarget()
    {
        float x = projectile.position.x;
        if (!over && x >= lowLeft.position.x && x <= lowRight.position.x)
        {
            if (x >= midLeft.position.x && x <= midRight.position.x)
            {
                if (x >= hiLeft.position.x && x <= hiRight.position.x)
                {
                    Count.count *= 10;
                }
                else
                {
                    Count.count *= 5;
                }
            }
            else
            {
                Count.count *= 2;
            }
        }
        over = true;
        Count.score.alignment = TextAnchor.MiddleCenter;
        Count.score.fontSize = 48;

    }
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Rigidbody2D>() == projectile)
            restartCurrentScene();
	}
	void restartCurrentScene()
	{
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
		//Application.LoadLevel (Application.loadedLevel);
	}
}
