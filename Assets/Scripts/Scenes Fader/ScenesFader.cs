using UnityEngine;
using System.Collections;

public class ScenesFader : MonoBehaviour {

	public static ScenesFader instance;

	[SerializeField]
	private GameObject FadeCan;

	[SerializeField]
	private Animator ani;

	void Awake(){
		MakeInstance ();
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	IEnumerator FadeIn(string name){
		FadeCan.SetActive (true);
		ani.Play ("FadeIn");
		yield return StartCoroutine (MyCounrtin.WaitForRealSecond (1f));
		Application.LoadLevel (name);
	}

	public void fakein(string name){
		StartCoroutine (FadeIn (name));
	}
}
