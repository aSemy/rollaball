using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;

    private int count = 0;
    public Text countText;
    public Text winText;
    public int winScore = 5;

    public string coinNoiseString = "2,.261,,.055,.5097,.2309,.3,.4387,,,,,,,,,.4444,.6371,,,,,,,,1,,,,,,";
    public string winNoiseString = "0,.221,,.3883,,.3418,.3,.4901,,.1461,,,,,,,,,,,.3279,,,,,1,,,,,,";


    private SfxrSynth coinNoise = new SfxrSynth();
    private SfxrSynth winNoise = new SfxrSynth();

    private float winTime = 0;
    private float startTime = 0;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        coinNoise.parameters.SetSettingsString(coinNoiseString);
        winNoise.parameters.SetSettingsString(winNoiseString);

        countText.text = "Count: " + count.ToString();
        setCountText();

        winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {

    }

    // before physics, for physics code
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        if (startTime == 0 && movement.magnitude > 0)
        {
            startTime = Time.fixedTime;
            Debug.Log("Start time " + startTime);
        }

    }

    /*
	 * Destroy(other.gameObject);
	 */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            coinNoise.parameters.startFrequency = UnityEngine.Random.Range(350, 650) / 1000f;
            coinNoise.Play();

            count++;
            setCountText();
        }

    }

    private void setCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= winScore)
        {
            winTime = Time.fixedTime;
            Debug.Log("Win time " + winTime);
            
            winText.text = "You Win! Time: " + Math.Round(winTime - startTime, 2) + " seconds";
            startTime = winTime = 0;
            winNoise.Play();
        }
        else if (winTime == 0
            )
        {
            count = 0;
            startTime = Time.fixedTime;
            winText.text = "";
        }
    }
}
