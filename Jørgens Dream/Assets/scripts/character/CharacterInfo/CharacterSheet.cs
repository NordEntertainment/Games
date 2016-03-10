using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSheet : MonoBehaviour
{

	public int Health;

	public Image CastBar;

	public int AutoAttackDamage;
	public int FireBallDamage;

	public GameObject EnemyNPC;
	public Text EnemyNPChealth;

	public bool aAttack;
	public bool aAttackCastBar;
	public bool Casting;

	private float castbartime;


	// Use this for initialization
	void Start ()
	{

		Health = 100;
		AutoAttackDamage = 5;
		FireBallDamage = 15;
		aAttack = false;
		Casting = false;
		CastBar.fillAmount = 0;
		castbartime = 0f;
		aAttackCastBar = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		EnemyNPChealth.text = "Health:" + Health;

		if (Health <= 0) {
			Destroy (GameObject.Find ("EnemyNPC"));
			Destroy (GameObject.Find ("EnemyHealth"));
			Health = 0;
		}

		if (Health >= 100)
			Health = 100;
		
		if (aAttackCastBar)
			CastBar.fillAmount += 1f / castbartime * Time.deltaTime;
		if (Casting)
			CastBar.fillAmount += 1f / castbartime * Time.deltaTime;
	
	}

	public void DoDamage ()
	{
		
		if (!aAttack)
			aAttack = true;
		if (aAttack)
			Health -= AutoAttackDamage;
		CastBar.fillAmount = 0;
		


	}

	public void Autoattack ()
	{
		if (aAttackCastBar) {
			CastBar.fillAmount = 0;
			aAttackCastBar = false;
		}
		if (!aAttackCastBar)
			aAttackCastBar = true;
		
		if (!aAttack) {
			castbartime = 3f;
			InvokeRepeating ("DoDamage", 3f, 3f);


		}
		if (aAttack) {
			aAttack = false;
			CancelInvoke ("DoDamage");
			CastBar.fillAmount = 0;
		}

	}

	public void HealthPotion ()
	{

		Health += 25;
	}

	public void FireBallSpell ()
	{
		StartCoroutine (FireBall ());
		Casting = true;
		castbartime = 5f;
	}

	IEnumerator FireBall ()
	{

		yield return new WaitForSeconds (5);
		Health -= FireBallDamage;
		CastBar.fillAmount = 0;
	}
}
