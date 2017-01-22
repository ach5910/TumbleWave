using UnityEngine;

public class ProjectileDragging : MonoBehaviour
{
	public float maxStretch = 3.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;
	public Transform zone3;

	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private float maxStretchSqr;
	private Rigidbody2D rigidbody2D;
	private Ray leftCatapultToProjectile;
	private float circleRadius;
	private bool clickedOn;
	private bool gravity;
	private Vector2 prevVelocity;

	void Awake()
	{
		spring = GetComponent<SpringJoint2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		catapult = spring.connectedBody.transform;
	}

	void Start()
	{
		LineRendererSetup();
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<CircleCollider2D>();
		circleRadius = circle.radius;
		gravity = false;
	}
	void Update()
	{

		if (Input.GetMouseButton(0) && spring != null)
		{
			ButtonPressed();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!gravity)
			{
				rigidbody2D.gravityScale = rigidbody2D.gravityScale * 10;
				gravity = true;
			}

		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (gravity)
			{
				rigidbody2D.gravityScale = rigidbody2D.gravityScale / 10;
				gravity = false;
			}
		}
		if (clickedOn)
			Dragging();
		if (Input.GetMouseButtonUp(0) && spring != null)
		{
			ButtonReleased();
		}

		if (spring != null)
		{
			if (!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude)
			{
				Destroy(spring);
				rigidbody2D.velocity = prevVelocity;
			}
			if (!clickedOn)
				prevVelocity = rigidbody2D.velocity;

			LineRendererUpdate();
		}
		else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;

		}
		if (rigidbody2D.position.x > zone3.position.x)
		{
			rigidbody2D.angularDrag = 2.0f;
		}

	}

	void LineRendererSetup()
	{
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";

		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}


	void ButtonPressed()
	{
		spring.enabled = false;
		clickedOn = true;
	}

	void ButtonReleased()
	{
		spring.enabled = true;
		rigidbody2D.isKinematic = false;
		clickedOn = false;
	}
	void LineRendererUpdate()
	{
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdpoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition(1, holdpoint);
		catapultLineBack.SetPosition(1, holdpoint);
	}

	void Dragging()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		if (catapultToMouse.sqrMagnitude > maxStretchSqr)
		{
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}

		mouseWorldPoint.z = 0.0f;
		transform.position = mouseWorldPoint;
	}
}
