using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;

	public float speed, maxSpeed;
	public float rot = 0;
	public float tilt;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//rot.x = 0; rot.z = 0;
			Quaternion rot = Quaternion.Euler(0, Mathf.Atan2(rb.velocity.x, rb.velocity.z)/3.14F*180F, 0);
			Instantiate(shot, shotSpawn.position, rot);
			//audio.Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rot -= moveHorizontal/35F;
		speed += moveVertical;
		if (speed > maxSpeed) 
			speed = maxSpeed;
		else if (speed < 0)
			speed = 0;

		Vector3 movement = new Vector3 (Mathf.Cos(rot), 0.0f, Mathf.Sin (rot));
		//rb.AddForce (movement * speed);
		rb.velocity = (movement * speed);

		/*
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		*/
	}

	/*
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin"))
		{
			other.gameObject.SetActive (false);
		}
	}*/

}
