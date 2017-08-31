using UnityEngine;
using System.Collections;

public static class MyCounrtin {

	public static IEnumerator WaitForRealSecond(float time){
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < (time + start)) {
			yield return null;
		}
	}
}
