using UnityEngine;
using System.Collections;

public class ZombieBehavior : MonoBehaviour {
	private PlatformerCharacter2D thisZombie;
	private float spd;
	private Transform gameManager;
	private bool hasComp = false; // does the zombie have a computer?
	private Animator anim;
	private SpriteRenderer spriteRenderer;
	private bool isDead = false;
	private float waitTime; //time to wait before destorying object after it dies
	private GameObject sourceDesk; //when zombie gets a computer, where it came from.

	public int health = 30; // how much health does the zombie have?
	// Use this for initialization
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").transform;
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Awake() {
		spd = Random.Range(-2f, -1f);
		//Debug.Log(spd);
		thisZombie = GetComponent<PlatformerCharacter2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		thisZombie.Move(spd, false, false);
		
			
	}
	
	void Update(){
		if (isDead && anim.GetCurrentAnimatorStateInfo(0).IsName("ZombieDie")){
			if (waitTime < Time.time){
				//Debug.Log("here");
				Destroy(gameObject);}
		}
	}

	public bool HasAComputer(){
		return hasComp;
	}

	void PickUpComputer(GameObject desk){
		hasComp = true;
		anim.SetBool("HasComputer", true);
		spd = spd*-1;
		thisZombie.transform.position = new Vector2(thisZombie.transform.position.x, thisZombie.transform.position.y + .5f);
		spriteRenderer.sortingOrder = 3;
		sourceDesk = desk;
	}
	
	void Die(){
		gameManager.SendMessage("UpScore", 10);
		spd = 0;
		anim.SetBool("Dead", true);
		isDead = true;
		if (hasComp){
			hasComp = false;
			anim.SetBool("HasComputer", false);
			GameObject aComputer = (GameObject)Instantiate(Resources.Load ("Computer"));
			aComputer.SendMessage("SetSource",sourceDesk);
			//sourceDesk.SendMessage("GetComputerBack");
		}
		waitTime = Time.time + .4f;
	}

	void TakeDamage(int damageToTake){
		if (!isDead){
			audio.pitch = Random.Range (0.8f, 1f);
			audio.Play ();
			//Debug.Log (health);
			health = (health - damageToTake);
			//Debug.Log("hit Zombie and did " + damageToTake + " damage: " + health + " health left.");
			if (health <= 0){
				Die();
			}
		}
	}
		
}
