using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public void btnStart(){

		ScenesFader.instance.fakein("GamePlay");
	}
}
