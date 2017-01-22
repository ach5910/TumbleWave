using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileFollow : MonoBehaviour {

	public Transform projectile;
	public Transform farLeft;
    public Transform farTop;
    public Transform farBottom;
    public Transform farRight;
    public Transform startCam;
    public Transform zoomOut;
    public Transform zone2;
    public Transform zone3;

    private SpringJoint2D spring;
    private Camera camera;
    private bool zoom_in;
   // private int count;
    //public Text countText;

    void Start()
    {
        spring = projectile.GetComponent<SpringJoint2D>();
        camera = transform.GetComponent<Camera>();
        zoom_in = true;
       // count = 0;
       // SetCountText();
    }
    void Update()
	{
		Vector3 newPosition = transform.position;
		newPosition.x = projectile.position.x;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
        if (spring == null && projectile.position.y >= startCam.position.y)
        {
            newPosition.y = projectile.position.y;
            newPosition.y = Mathf.Clamp(newPosition.y, farBottom.position.y, farTop.position.y);
        }
        if (projectile.position.y > 0 && projectile.position.y <= 40)
            camera.orthographicSize = (projectile.position.y % 40) + 17;
        if (projectile.position.x > zone2.position.x)
        {
            if (projectile.position.x > zone3.position.x)
            {
                newPosition.y = projectile.position.y;
                newPosition.y = Mathf.Clamp(newPosition.y, farBottom.position.y, farTop.position.y);
            }
            else
            {
                newPosition.y = projectile.position.y;
                newPosition.y = Mathf.Clamp(newPosition.y, farBottom.position.y, farTop.position.y);
            }
        }

        //if (zoom_in && projectile.position.y >= zoomOut.position.y && camera.orthographicSize < 16)
        //{
           // camera.orthographicSize++;
            //zoom_in = false;
        //}
        transform.position = newPosition;
	}

   // void SetCountText()
   // {
    //    countText.text = "Score: " + count.ToString();
    //}
}
