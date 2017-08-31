using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StarScripts : MonoBehaviour, IEventSystemHandler {

	public float MoveSpeed;
	public float jum;

	public Rigidbody2D body;

	public Animator anim;

	public bool IsFly, IsLive;

	public int Score = 0;

	private GameObject[] YStar;
	public float LastYStar;
	private float dis = 10f;
	private float min = -2f;
	private float max = 4f;

	public static StarScripts instance;

	[SerializeField]
	private GameObject FadeCan;

	[SerializeField]
	private Animator ani;

	[SerializeField]
	private AudioSource audiping, audidie, audispeed;

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		IsLive = true;
		IsFly = false;
		MakeInstance ();

		YStar = GameObject.FindGameObjectsWithTag ("YellowStar");
		for (int i = 1; i < YStar.Length; i++) {
			Vector3 temp = YStar [i].transform.position;
			temp.y = Random.Range (min, max);
			YStar [i].transform.position = temp;
		}
		LastYStar = YStar [0].transform.position.x;
		for (int y = 0; y < YStar.Length; y++) {
			if (LastYStar < YStar [y].transform.position.x) {
				LastYStar = YStar [y].transform.position.x;
			}
		}
	}
		
	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	void FixedUpdate(){
		Move ();
	}

	public void pressed (BaseEventData eventData)
	{
		IsFly = true;
	}

	public void notpressed (BaseEventData eventData)
	{
		IsFly = false;
	}

	void Move(){
		if (IsLive) {
			Vector3 temp = transform.position;
			temp.x += MoveSpeed * Time.deltaTime;
			transform.position = temp;
			if (IsFly) {
				body.velocity = new Vector2 (0, jum);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "YellowStar") {
			Vector3 temp = target.transform.position;
			temp.x = YellowStarFollow.instance.LastStar + dis;
			temp.y = Random.Range (min, max);
			target.transform.position = temp;
			LastYStar = temp.x;
			YellowStarFollow.instance.LastStar = LastYStar;
			if (IsLive) {
				Score++;
				GamePlay.instance.setScore (Score);
				if (Score == 10) {
					MoveSpeed += 0.5f;
					GamePlay.instance.setSpeed ("x1.5");
					audiping.Play ();
				} else if (Score == 15) {
					MoveSpeed += 0.5f;
					GamePlay.instance.setSpeed ("x2");
					audiping.Play ();
				} else if (Score == 25) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x3");
					audiping.Play ();
				} else if (Score == 50) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x4");
					audiping.Play ();
				} else if (Score == 75) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x5");
					audiping.Play ();
				} else if (Score == 100) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x6");	
					audiping.Play ();
				} else if (Score == 125) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x7");
					audiping.Play ();
				} else if (Score == 150) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x8");
					audiping.Play ();
				} else if (Score == 175) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x9");
					audiping.Play ();
				} else if (Score == 200) {
					MoveSpeed += 1;
					GamePlay.instance.setSpeed ("x10");
					audiping.Play ();
				} else {
					audispeed.Play ();
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "StarDie") {
			if (IsLive) {
				IsLive = false;
				fakeinout ();
				audidie.Play ();
				anim.SetTrigger("Die");
				UM_AdManager.StartInterstitialAd();
				StartCoroutine(MyCoroutine());
				GamePlay.instance.ShowPanel ();
			}
		}
	}

	IEnumerator MyCoroutine()
	{
		yield return new WaitForSeconds (1.5f);
		Time.timeScale = 0f;
	}

	IEnumerator FadeInOut(){
		FadeCan.SetActive (true);
		ani.Play ("FadeDie");
		yield return StartCoroutine (MyCounrtin.WaitForRealSecond (1f));
		FadeCan.SetActive (false);
	}

	public void fakeinout(){
		StartCoroutine (FadeInOut ());
	}
}
