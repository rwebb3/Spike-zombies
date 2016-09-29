using UnityEngine;
using System.Collections;

public class ComputerDeskBehavior : MonoBehaviour {
	public Sprite withComputer; //need a reference to compare to
	public Sprite withoutComputer;

	private bool hasComp = true;
	private SpriteRenderer spriteRenderer;
	
	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer.sprite == null){
			spriteRenderer.sprite = withComputer;}
	}

	//if a zombie without a computer gets to the desk with a computer, zombie gets computer
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("here");
			if (other.gameObject.tag == "Zombie"){
			//Debug.Log ("Zombie on Desk");
				if (!other.gameObject.GetComponent<ZombieBehavior>().HasAComputer() && hasComp){
					other.gameObject.SendMessage("PickUpComputer", gameObject);
					hasComp = false;
				}
			}
			//Debug.Log ("correct");
	}
	
	void GetComputerBack(){
		hasComp = true;
	}
	
	void Update(){
		if (!hasComp){
			spriteRenderer.sprite = withoutComputer;}
		else{
			spriteRenderer.sprite = withComputer;}
	}
			
			
		
}

