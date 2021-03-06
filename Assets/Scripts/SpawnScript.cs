﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject coins, coin;

	void Update () 
	{	
		if (coin.transform.childCount < 20) {
			if (Random.value < 0.01)
			{
				Vector3 pos = transform.position;
				pos += new Vector3((float)(Random.value-0.5F)*50F, 0.4F, (float)(Random.value-0.5F)*50F);
				GameObject temp = (GameObject)Instantiate(coin, pos, Quaternion.identity);
				temp.transform.parent = coins.transform;
			}
		}
	}

}
