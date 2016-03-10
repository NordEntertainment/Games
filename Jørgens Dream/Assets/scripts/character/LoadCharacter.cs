using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour
{

	public void NewChar ()
	{
		Application.LoadLevel ("New Character");
	}

	public void LoadChar ()
	{
		Application.LoadLevel ("Existing Character");
	}


}
