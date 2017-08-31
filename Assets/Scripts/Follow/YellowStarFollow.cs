using UnityEngine;
using System.Collections;

public class YellowStarFollow : MonoBehaviour {

	private GameObject[] YellowStar;
	public float LastStar;
	private float dis = 10f;
	private float min = -2f;
	private float max = 4f;

	public static YellowStarFollow instance;

	void Awake () {
		MakeInstance ();
		YellowStar = GameObject.FindGameObjectsWithTag ("YellowStar");

		for (int i = 1; i < YellowStar.Length; i++) {
			Vector3 temp = YellowStar [i].transform.position;
			temp.y = Random.Range (min, max);
			YellowStar [i].transform.position = temp;
		}

		LastStar = YellowStar [0].transform.position.x;
		for (int i = 0; i < YellowStar.Length; i++) {
			if (LastStar < YellowStar [i].transform.position.x) {
				LastStar = YellowStar [i].transform.position.x;
			}
		}
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "YellowStar") {
			Vector3 temp = target.transform.position;
			temp.x = StarScripts.instance.LastYStar + dis;
			temp.y = Random.Range (min, max);
			target.transform.position = temp;
			LastStar = temp.x;
			StarScripts.instance.LastYStar = LastStar;
		}
	}
}
