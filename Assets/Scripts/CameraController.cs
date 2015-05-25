using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public PlayerController playerScript;
	public Vector3 lastOffset = new Vector3(0,0,0);
		
	void Start ()
	{
		//past = player.transform.position;
		//offset = transform.position - player.transform.position;
		playerScript = player.GetComponent<PlayerController>();
	}
	
	void Update ()
	{
		/*
		Vector3 diff = player.transform.position - past;
		past = player.transform.position;

		Quaternion rot = Quaternion.Euler(0, Mathf.Atan2(diff.x, diff.z)/3.14F*180F, 0);
		this.transform.rotation = rot;

		Vector3 offset = -diff * 2 + new Vector3(0,2,0);
		transform.position = player.transform.position + offset;
		*/
		//print (playerScript);
		//print ("dddd" + playerScript.rb);
		Vector3 offset = -playerScript.rb.velocity;
		offset.y = (playerScript.rb.velocity.magnitude + 1)/2;
		if (offset.magnitude < 1.5)
			offset = lastOffset;
		else
			lastOffset = offset;
		transform.position = player.transform.position + offset;
		transform.LookAt(player.transform.position);
	}

}