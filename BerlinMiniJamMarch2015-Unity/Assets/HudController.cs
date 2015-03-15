using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {
	public static HudController hudController;

	SpriteRenderer projectile01;
	SpriteRenderer projectile02;
	SpriteRenderer projectile03;
	SpriteRenderer projectile04;

	SpriteRenderer[] projectiles;

	void Awake(){	
		hudController=this;
	}

	void Start () {
		projectile01 = GameObject.Find ("projectile_01").GetComponent<SpriteRenderer>();
		projectile02 = GameObject.Find ("projectile_02").GetComponent<SpriteRenderer>();
		projectile03 = GameObject.Find ("projectile_03").GetComponent<SpriteRenderer>();
		projectile04 = GameObject.Find ("projectile_04").GetComponent<SpriteRenderer>();

		projectiles = new SpriteRenderer[] {projectile01, projectile02, projectile03, projectile04};
		grayOutAllFields();
	}

	public void setColorForProjectileType(int projectileType)
	{
		grayOutAllFields();
		Color tmpColor = new Color();
		tmpColor.r = 1f;
		tmpColor.g = 1f;
		tmpColor.b = 1f;
		tmpColor.a = 1f;
		projectiles[projectileType-1].color = tmpColor;
	}

	void grayOutAllFields()
	{
		Color tmpColor = new Color();
		foreach(SpriteRenderer sr in projectiles)
		{
			tmpColor.r = 0.3f;
			tmpColor.g = 0.3f;
			tmpColor.b = 0.3f;
			tmpColor.a = 1f;
			sr.color = tmpColor;
		}
	}
}
