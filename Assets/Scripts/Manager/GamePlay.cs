using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

	public Button Clicktoplay, btnpause, btnresume;
	public Image imgplay;
	public Text txtSco, sco, bestsco, newi, speed;
	public GameObject Panel;

	public static GamePlay instance;

	private const string HIGHT = "hight";

	[SerializeField]
	private GameObject FadeCan;

	[SerializeField]
	private Animator ani;

	void Start(){
		fakeout ();

		int adid = 0;
		if (!UM_AdManager.IsInited) {
			UM_AdManager.Init ();
		}
		if (adid <= 0) {
			adid = UM_AdManager.CreateAdBanner (TextAnchor.LowerCenter);
			UM_AdManager.ShowBanner (adid);
		}
	}

	void Awake(){
		MakeInstance ();
		Time.timeScale = 0f;
		//PlayerPrefs.SetInt (HIGHT, 0);    reset score
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void clickplay(){
		Time.timeScale = 1f;
		Clicktoplay.gameObject.SetActive (false);
		imgplay.gameObject.SetActive (false);
		btnpause.gameObject.SetActive (true);
		txtSco.gameObject.SetActive (true);
		speed.gameObject.SetActive (true);
		StarScripts.instance.anim.SetTrigger("Fly");
	}

	public void btPause(){
		Time.timeScale = 0f;
		btnresume.gameObject.SetActive (true);
		btnpause.gameObject.SetActive (false);
	}

	public void btResume(){
		Clicktoplay.gameObject.SetActive (true);
		imgplay.gameObject.SetActive (true);
		btnresume.gameObject.SetActive (false);
	}

	public void ShowPanel(){
		Panel.SetActive (true);
		btnpause.gameObject.SetActive (false);
		txtSco.gameObject.SetActive (false);
		speed.gameObject.SetActive (false);
		sco.text = StarScripts.instance.Score.ToString ();

		if (StarScripts.instance.Score > getHightScore ()) {
			setHightScore (StarScripts.instance.Score);
			newi.gameObject.SetActive (true);
		}
		bestsco.text = getHightScore ().ToString ();
	}

	public void btRestart(){
		Application.LoadLevel ("GamePlay");
	}

	public void btRate(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.han94067.star");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		#endif
	}

	public void setScore(int s){
		txtSco.text = s.ToString ();
	}

	public void setHightScore(int s){
		PlayerPrefs.SetInt (HIGHT, s);
	}

	public int getHightScore(){
		return PlayerPrefs.GetInt (HIGHT);
	}

	public void setSpeed(string s){
		speed.text = s;
	}

	IEnumerator FadeOut(){
		FadeCan.SetActive (true);
		ani.Play ("FadeOut");
		yield return StartCoroutine (MyCounrtin.WaitForRealSecond (1f));
		FadeCan.SetActive (false);
	}

	public void fakeout(){
		StartCoroutine (FadeOut ());
	}
}
