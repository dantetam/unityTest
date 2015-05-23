using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Shot"))
		{
			Destroy(other.gameObject);
		    this.gameObject.SetActive(false);
		}
	}
	
}
