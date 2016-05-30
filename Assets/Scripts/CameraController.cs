using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public float zoom = 1;
    private float zoomMax = 2;
    private float zoomMin = 0.1f;
    private float zoomWheelDelta= 0.1f;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset*zoom;
	}

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
        {
            zoom = Mathf.Max(zoomMin, zoom - zoomWheelDelta);
        }
        if (Input.GetAxis("Mouse ScrollWheel")< 0) // back
        {
			zoom = Mathf.Min(zoomMax, zoom + zoomWheelDelta);
        }
    }
}
