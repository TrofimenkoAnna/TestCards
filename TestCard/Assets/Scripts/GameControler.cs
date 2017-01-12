using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameControler : MonoBehaviour {

	public GameObject btnStart;
	public GameObject card;

	private GameObject prefInst;

	RaycastHit2D hit; 
	Vector3 worldPoint;

	Vector3 startPos = new Vector3 (-5, 3.5f, 0);
	Vector3 newPos;
	int nuberOfCards = 36;
	public static List<GameObject> fetchedCards = new List<GameObject>();

	public static List<int> cardID = new List<int> ();

	int n = 0;

	// Use this for initialization
	void Start () {
		newPos = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			worldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
			hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			if (hit.collider != null && hit.transform.gameObject.name == "Deck" && n < 6) {
				CreateCards ();
			} 
			if (n == 6) {
				prefInst.SetActive (false);
			}
		}
	}

	public void OnClickStart()
	{
		btnStart.SetActive (false);
		prefInst = (GameObject) Instantiate (card, Vector3.zero, Quaternion.identity);
		prefInst.name = "Deck";
		int[] temp = new int[36];

		for (int i = 0; i < 36; i++) {
			temp [i] = i+1;
		}

		Shuffle (temp);

		cardID.AddRange (temp);
	}


	void CreateCards()
	{
		Debug.Log ("create");
		fetchedCards.Add (Instantiate (card, newPos, Quaternion.identity) as GameObject);
		if (n == 2) {
			newPos = new Vector3 (startPos.x, -startPos.y, startPos.z);
		} else {
			newPos = new Vector3 (newPos.x + 5, newPos.y, newPos.z);
		}
		n++;
		Debug.Log ("n++" + n);
	}

	void Shuffle (int[] t)
	{
		for (int i = 0; i < t.Length; i++) {
			int tmp = t [i];
			int randomIndex = Random.Range (0, t.Length);
			t [i] = t [randomIndex];
			t [randomIndex] = tmp;
		}
	}
}
