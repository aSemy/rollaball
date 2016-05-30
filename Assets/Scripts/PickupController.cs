using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	public float respawnSeconds = 5;

    public float currentSpawn = 0;

    public string respawnNoiseString = "2,.250,,.1763,,.2368,.3,.4525,,.2136,,,,,,,,,,,,,,,,1,,,,,,";

    public float maxScale =1;

    public float rescaleUpSpeed = 5f;

    private SfxrSynth respawnNoise = new SfxrSynth();

    // Use this for initialization
    void Start () {

        respawnNoise.parameters.SetSettingsString(respawnNoiseString);
	
	}


		// Update is called once per frame
        void Update()
    {
         if (this.gameObject.transform.localScale.magnitude < maxScale)
        {
            transform.localScale += new Vector3(rescaleUpSpeed * Time.deltaTime, rescaleUpSpeed * Time.deltaTime, rescaleUpSpeed * Time.deltaTime);

            if (transform.localScale.magnitude > 1)
            {
                transform.localScale.Normalize();
            }

        }
    }

	public void SpawnUpdate () {

        if (!this.gameObject.activeSelf) {
            if (currentSpawn <= 0) {
                this.gameObject.SetActive(true);

                respawnNoise.parameters.startFrequency = Random.Range(350, 650) / 1000f;
                respawnNoise.Play();

                this.gameObject.transform.localScale = Vector3.zero;

            } else {
                currentSpawn -= 1 * Time.deltaTime;
            }
        }
        
        }

    void OnDisable ()
    {
        currentSpawn = respawnSeconds;
    }
}
