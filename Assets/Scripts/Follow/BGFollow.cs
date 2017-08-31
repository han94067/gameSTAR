using UnityEngine;
using System.Collections;

public class BGFollow : MonoBehaviour {

	private GameObject[] background;
	private GameObject[] ground;
	private GameObject[] backgroundwhite;
	private GameObject[] groundtop;

	private float lastBGpos, lastGroundpos, lastBGWhitepos, lastGToppos;

	void Awake(){
		background = GameObject.FindGameObjectsWithTag ("BackGround");
		ground = GameObject.FindGameObjectsWithTag ("Ground");
		backgroundwhite = GameObject.FindGameObjectsWithTag ("BackGroundWhite");
		groundtop = GameObject.FindGameObjectsWithTag ("GroundTop");

		lastBGpos = background [0].transform.position.x;
		lastGroundpos = ground [0].transform.position.x;
		lastBGWhitepos = backgroundwhite [0].transform.position.x;
		lastGToppos = groundtop [0].transform.position.x;

		for (int i = 1; i < background.Length; i++) {
			if (lastBGpos < background [i].transform.position.x) {
				lastBGpos = background [i].transform.position.x;
			}
		}

		for (int i = 1; i < ground.Length; i++) {
			if (lastGroundpos < ground [i].transform.position.x) {
				lastGroundpos = ground [i].transform.position.x;
			}
		}

		for (int i = 1; i < backgroundwhite.Length; i++) {
			if (lastBGWhitepos < backgroundwhite [i].transform.position.x) {
				lastBGWhitepos = backgroundwhite [i].transform.position.x;
			}
		}

		for (int i = 1; i < groundtop.Length; i++) {
			if (lastGToppos < groundtop [i].transform.position.x) {
				lastGToppos = groundtop [i].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		float width;
		if (target.tag == "BackGround") {
			Vector3 temp = target.transform.position;
			width = ((BoxCollider2D)target).size.x;
			temp.x = (lastBGpos - 0.2f) + width;
			target.transform.position = temp;
			lastBGpos = temp.x;
		}
		else if (target.tag == "Ground"){
			Vector3 temp = target.transform.position;
			width = ((BoxCollider2D)target).size.x;
			temp.x = lastGroundpos + width * 1.65f;
			target.transform.position = temp;
			lastGroundpos = temp.x;
		}else if (target.tag == "BackGroundWhite") {
			Vector3 temp = target.transform.position;
			width = ((BoxCollider2D)target).size.x;
			temp.x = (lastBGWhitepos - 0.2f) + width;
			target.transform.position = temp;
			lastBGWhitepos = temp.x;
		}else if (target.tag == "GroundTop") {
			Vector3 temp = target.transform.position;
			width = ((BoxCollider2D)target).size.x;
			temp.x = lastGToppos + width * 1.65f;
			target.transform.position = temp;
			lastGToppos = temp.x;
		}
	}
}