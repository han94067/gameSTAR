using UnityEngine;
using System.Collections;

public class BlackStar : MonoBehaviour {

	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;

	public void SetColliderForSprite(int spriteNum)
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}
}
