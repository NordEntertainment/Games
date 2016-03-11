using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

	public void GoBack ()
	{
		SceneManager.LoadScene ("Scene2");
	}
}
