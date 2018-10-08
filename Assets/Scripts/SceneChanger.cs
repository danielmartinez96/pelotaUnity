using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

public GameObject boton;
public Text textGanar;
	private void Start() {	
	boton.SetActive(false);
	}
  private void Update() {
		if(textGanar.text=="You Win!!!"&&SceneManager.GetActiveScene().name!="nivel2")
		{
			boton.SetActive(true);
		}
	}
	public void nivel2()
	{
	
		SceneManager.LoadScene("nivel2");	

	}

  
}
