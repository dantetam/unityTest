using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class MoverScript : MonoBehaviour
{
	public float speed;
	public Boundary bound;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void LateUpdate()
	{
		if (transform.position.x < bound.xMin || transform.position.x > bound.xMax ||
			transform.position.z < bound.zMin || transform.position.z > bound.zMax) 
		{
			Destroy(this.gameObject);
		}
	}
	
}
