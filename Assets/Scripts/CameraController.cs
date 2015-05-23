using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public Vector3 offset; //, past;

	void Start ()
	{
		//past = player.transform.position;
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		/*
		Vector3 diff = player.transform.position - past;
		past = player.transform.position;

		Quaternion rot = Quaternion.Euler(0, Mathf.Atan2(diff.x, diff.z)/3.14F*180F, 0);
		this.transform.rotation = rot;

		Vector3 offset = -diff * 2 + new Vector3(0,2,0);
		transform.position = player.transform.position + offset;
		*/
		transform.position = player.transform.position + offset;
	}

}