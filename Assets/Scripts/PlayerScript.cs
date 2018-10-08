using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float velocidad;
	private Rigidbody rb;
	private int contador;
	public Text contadorText;
	public Text winText;
	public float jumpForce;
	private bool isGrounded;
	public Transform cameraTransform;
    private int items;
	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		contador=0;
		items= GameObject.FindGameObjectsWithTag("Item").Length;
		SetText();
		winText.text= "";
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direccion= Vector3.zero; 
		float mHorizontal= Input.GetAxis("Horizontal")*velocidad;
		float mVertical=Input.GetAxis("Vertical")*velocidad;
		direccion+=cameraTransform.right*mHorizontal;
		direccion+=cameraTransform.forward*mVertical;
		direccion.y=0.0f;

		float salto= 0.0f;
		if(isGrounded)
		{
			if(Input.GetButtonDown("Jump")){
			salto=30*jumpForce;
			}
		}
		
		Vector3 saltoMovimiento = new Vector3(direccion.x, salto, direccion.z);
		rb.AddForce(saltoMovimiento);
		
		transform.position+= direccion.normalized*Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Item"))
		{
			other.gameObject.SetActive(false);
			contador++;
			SetText();
		}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Piso"))
		{
			isGrounded=true;
		}
	}
	private void OnCollisionExit(Collision other) {
		if(other.gameObject.CompareTag("Piso"))
		{
			isGrounded=false;
		}
	}
	private void SetText()
	{
		contadorText.text="Score: "+ contador.ToString();
		if(contador>=items)
		{
			winText.text= "You Win!!!";
			
		}
	}
}
