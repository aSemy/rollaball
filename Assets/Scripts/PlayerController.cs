using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Rigidbody rb;

	public string coinNoiseString = "2,.261,,.055,.5097,.2309,.3,.4387,,,,,,,,,.4444,.6371,,,,,,,,1,,,,,,";

	private SfxrSynth coinNoise = new SfxrSynth();




	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

		coinNoise.parameters.SetSettingsString (coinNoiseString);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // before physics, for physics code
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        
    }

	/*
	 * Destroy(other.gameObject);
	 */
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")){
			other.gameObject.SetActive (false);

			coinNoise.parameters.startFrequency = Random.Range (350, 650)/1000f;
			coinNoise.Play ();

			//coinNoise.PlayMutated ();
		}
			
	}
}
