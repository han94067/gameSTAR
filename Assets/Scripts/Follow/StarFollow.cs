using UnityEngine;
using System.Collections;

public class StarFollow : MonoBehaviour {

	private GameObject[] BlackStar;
	private float LastStar;
	private float dis = 10f;
	private float min = -4f;
	private float max = 5.5f;

	void Awake () {
		BlackStar = GameObject.FindGameObjectsWithTag ("BlackStar");

		for (int i = 0; i < BlackStar.Length; i++) {
			Vector3 temp = BlackStar [i].transform.position;
			temp.y = Random.Range (min, max);
			BlackStar [i].transform.position = temp;
		}
		LastStar = BlackStar [0].transform.position.x;
		for (int i = 1; i < BlackStar.Length; i++) {
			if (LastStar < BlackStar [i].transform.position.x) {
				LastStar = BlackStar [i].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "BlackStar") {
			Vector3 temp = target.transform.position;
			temp.x = LastStar + dis;
			temp.y = Random.Range (min, max);
			target.transform.position = temp;
			LastStar = temp.x;
		}
	}
}
