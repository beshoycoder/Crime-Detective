using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact_tester : MonoBehaviour
{
    RaycastHit hit;
    

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(this.transform.position,this.transform.forward, out hit,1000f))
        {
            if(hit.collider.gameObject.layer==6)
            {
               GameObject game= hit.collider.gameObject;
                game.TryGetComponent<interactionAI>(out interactionAI testable);
                testable.enable_Outline();
                testable.Interact();
            }
            
        }
        Debug.DrawRay(this.transform.position,this.transform.forward, Color.yellow);
        
    }
}
