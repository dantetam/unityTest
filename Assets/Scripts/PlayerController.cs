using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;

	public float speed, maxSpeed;
	public float rot = 0;
	public float tilt;

	public GameObject coins;
	public GameObject shots;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		coins = GameObject.Find("Coins"); 
	}
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//rot.x = 0; rot.z = 0;
			Quaternion rot = Quaternion.Euler(0, Mathf.Atan2(rb.velocity.x, rb.velocity.z)/3.14F*180F, 0);
			GameObject temp = (GameObject)Instantiate(shot, shotSpawn.position, rot);
			temp.transform.parent = shots.transform;
			//audio.Play ();
		}
		if (Input.GetButton("Fire2"))
		{
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				if (hitInfo.transform.gameObject.tag == "Baseplate")
				{
					Vector3 pos = hitInfo.point;
					pos += new Vector3(0, 0.5F, 0);
					GameObject coinPrefab = (GameObject)(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Cube.prefab", typeof(GameObject)));
					GameObject temp = (GameObject)Instantiate(coinPrefab, pos, Quaternion.identity);
					temp.transform.parent = coins.transform;
				}
			}
			Debug.Log("Mouse is down");
		} 
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (speed > 0.1) {
			rot -= moveHorizontal / 35F;
		}
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
