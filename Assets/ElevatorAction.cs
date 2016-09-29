using UnityEngine;
using System.Collections;

public class ElevatorAction : MonoBehaviour {
	Transform ElevatorExit;
	private float timeToWait = 0.4f; //wait before checking for input again to prevent going too far
	private float timer;



	// Use this for initialization
	void Awake() {
		ElevatorExit = transform.FindChild("Exit");
	}

	void OnTriggerEnter2D(Collider2D other){
		timer = Time.time + timeToWait;
	}


	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("here");
		if (other.gameObject.tag == "Player"){
			if (ElevatorExit != null){
				if (Input.GetAxis("Vertical") != 0f && timer < Time.time){
					other.gameObject.transform.position = new Vector2(ElevatorExit.position.x, ElevatorExit.position.y);
				}
			}
			//Debug.Log ("correct");
		}
	}

}
