using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateChar : MonoBehaviour
{

	private Text CharText;
	public Dropdown dropdown;
	public GameObject CreateCharButton;
	private int ClassID;

	void Start ()
	{
		CharText = GameObject.Find ("CharInfo").GetComponent<Text> ();
		GameObject.Find ("CharInfo").GetComponent<Text> ().text = "...";


		CreateCharButton.SetActive (false);

		ClassID = 0;
	}

	public void PickaClass ()
	{
		if (dropdown.value == 0) {
			CharText.text = "...";
			CreateCharButton.SetActive (false);
		}

		if (dropdown.value == 1)
			Fighter ();
		
		
		if (dropdown.value == 2)
			Thief ();
		
		if (dropdown.value == 3)
			Spellcaster ();



	}

	public void OnCharButtonClick ()
	{
		
		if (ClassID == 1)
			print ("You chose Fighter");
			
		if (ClassID == 2)
			print ("You chose Thief");

		if (ClassID == 3)
			print ("You chose Spellcaster");
			
	}

	public void Fighter ()
	{
		
		CharText.text = "A Fighter uses various weapons and shields in battle.";
		CreateCharButton.SetActive (true);

		ClassID = 1;
	}

	public void Thief ()
	{

		CharText.text = "A Thief locates weakness in his enemies and steals yo shit.";
		CreateCharButton.SetActive (true);

		ClassID = 2;
	}

	public void Spellcaster ()
	{

		CharText.text = "A Spellcaster draws upon the power of the ancient forces, both devastating and harmonic.";
		CreateCharButton.SetActive (true);

		ClassID = 3;
	}

}
