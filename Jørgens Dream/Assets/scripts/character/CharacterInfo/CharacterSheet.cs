using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSheet : MonoBehaviour
{

	public int Health;
	//Spells på Actionbar

	//Spells i bobla
	public Image CastBarTimer;
	public GameObject BallLoc;
	public Image PowerStrikeBall;
	public Image FireBallBall;
	public Text CurrentSpellText;

	//Abilities Damage
	public int AutoAttackDamage;
	public int PowerStrikeDamage;
	public int FireBallDamage;

	//EnemyInfo
	public GameObject EnemyNPC;
	public Text EnemyNPChealth;

	//Spells
	public bool AutoAttack = false;
	public bool PowerStrike = false;
	public bool FireBall = false;
	public bool casting = false;
	public bool AutoCasting = false;


	public float castbartime;


	// Use this for initialization
	void Start ()
	{

		Health = 100;
		AutoAttackDamage = 3;
		PowerStrikeDamage = 10;
		FireBallDamage = 20;
		castbartime = 0f;
		FireBallBall.enabled = false;
		PowerStrikeBall.enabled = false;

		CastBarTimer.fillAmount = 0;
		CurrentSpellText.text = "Attack";
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

		if (AutoAttack)
			CurrentSpellText.text = "Auto Attack";
		    CastBarTimer.fillAmount -= 1f / castbartime * Time.deltaTime;

		if (PowerStrike) {
            CurrentSpellText.text = "Power Strike";
            PowerStrikeBall.enabled = true;
			FireBallBall.enabled = false;
			AutoAttack = false;
			CancelInvoke ("AutoAttackInvoke");
            
       


        } else if (!PowerStrike)
			PowerStrikeBall.enabled = false;
		
		if (FireBall) {
			CurrentSpellText.text = "Fire Ball";
			PowerStrikeBall.enabled = false;
			FireBallBall.enabled = true;
			AutoAttack = false;
			CancelInvoke ("AutoAttackInvoke");
			
		} else if (!FireBall)
			FireBallBall.enabled = false;
		
	
	}

	public void AutoAttackSpell ()
	{
		if (!casting) {
			
                if (!AutoAttack) { 
                    AutoAttack = true;
                CastBarTimer.fillAmount = 1;
                castbartime = 2f;
                InvokeRepeating("AutoAttackInvoke", 2f, 2f);
                }
            
        
            else if (AutoAttack)
        {
            AutoAttack = false;
            CancelInvoke("AutoAttackInvoke");
                CastBarTimer.fillAmount = 0;
            //  AutoCasting = false;


        }

        }

        else if (FireBall)
        {
            if (casting)

                FireBall = false;
            casting = false;
            CastBarTimer.fillAmount = 0;

        }

        else if (PowerStrike)
        {
            if (casting)
                PowerStrike = false;
            casting = false;
            CastBarTimer.fillAmount = 0;

        }


    }

    

	public void AutoAttackInvoke ()
	{
		CastBarTimer.fillAmount = 1;
		Health -= AutoAttackDamage;
		//AutoCasting = true;
	}

    public void PowerStrikeSpell()
    {
        if (!casting)
        {
            CastBarTimer.fillAmount = 1;
            PowerStrike = true;
            castbartime = 3f;
            StartCoroutine(PowerStrikeSpellTimer());

            if (AutoCasting)
            {
                AutoAttack = false;
                AutoCasting = false;
            }



        }

        else if (PowerStrike)
        {
            if (casting)
                PowerStrike = false;
            casting = false;
            CastBarTimer.fillAmount = 0;

        }
    }

	public void HealthPotion ()
	{

		Health += 25;
	}

	public void FireBallSpell ()
	{
		if (!casting) {
			CastBarTimer.fillAmount = 1;
            castbartime = 5f;
            FireBall = true;
            StartCoroutine (FireBallSpellTimer ());
            if (AutoCasting)
            {
                AutoAttack = false;
                AutoCasting = false;
            }



        }
        else if (FireBall)
        {
            if (casting)

                FireBall = false;
            casting = false;
            CastBarTimer.fillAmount = 0;

        }
    }

	IEnumerator FireBallSpellTimer ()
	{
		casting = true;
        CastBarTimer.fillAmount += 1f / castbartime * Time.deltaTime;
        yield return new WaitForSeconds (5);
		Health -= FireBallDamage;
		FireBall = false;
		casting = false;
		CurrentSpellText.text = "Attack";
	}

	IEnumerator PowerStrikeSpellTimer ()
	{
		casting = true;
        CastBarTimer.fillAmount += 1f / castbartime * Time.deltaTime;
        yield return new WaitForSeconds (3);
		Health -= PowerStrikeDamage;
		casting = false;
		PowerStrike = false;
		CurrentSpellText.text = "Attack";
	}
}
