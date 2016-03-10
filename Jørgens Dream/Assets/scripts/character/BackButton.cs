using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour
{

	public void GoBack ()
	{
		Application.LoadLevel ("Scene2");
	}
}
