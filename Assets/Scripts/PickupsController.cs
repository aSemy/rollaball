using UnityEngine;
using System.Collections;

public class PickupsController : MonoBehaviour {

    private PickupController[] c;

    // Use this for initialization
    void Start () {
        
        c = GetComponentsInChildren<PickupController>(true);
        	
	}
	
	// Update is called once per frame
	void Update () {

        foreach (PickupController p in c)
        {
           if (!p.gameObject.activeSelf)
        {
            p.SpawnUpdate();
            }
        }
	}
}
