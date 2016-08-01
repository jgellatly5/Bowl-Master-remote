using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    // destroys pins
    void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }
}
