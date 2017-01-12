using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private int ID;
	private Animator anim;
	private bool rotation = false;

	public Sprite[] fases;

	private SpriteRenderer sRend;


	// Use this for initialization
	void Start () { 
		anim = GetComponent<Animator> ();

		if (name.StartsWith ("Card")) {
			rotation = true; 
			ID = GameControler.cardID [0]; // get first card from deck
			GameControler.cardID.Remove (GameControler.cardID [0]); // remove first card from deck
			Debug.Log ("ID" + ID);
			sRend = GetComponent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		anim.SetBool ("Rotation", rotation);

	}

	void SetSpriteFase()
	{
		Debug.Log ("event");
		sRend.sprite = fases [ID]; // set fase of card
		sRend.flipX = true;
	}
}
