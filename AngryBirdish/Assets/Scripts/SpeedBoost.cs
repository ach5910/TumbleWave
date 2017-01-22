using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private float resetSpeedSqr;
    private Rigidbody2D projectile;
    private SpringJoint2D spring;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        projectile = GetComponent<Rigidbody2D>();

    }

    void Start () {
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            projectile.mass = projectile.mass * projectile.mass;
        }
	}
}
