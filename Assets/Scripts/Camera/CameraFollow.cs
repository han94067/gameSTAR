using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform star;

	void LateUpdate(){
		if (star != null) {
			Vector3 temp = transform.position;
			temp.x = star.position.x + 1.3f;
			transform.position = temp;
		}	
	}
}
