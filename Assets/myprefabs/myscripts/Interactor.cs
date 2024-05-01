using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactor : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 cam_forawrd;
    private Vector3 orign_point;
    RaycastHit hit;
    Ray Ray;
    Vector3 screenCenter = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
    void Start()
    {
        cam_forawrd = cam.transform.forward * -1f;
        orign_point = this.transform.localPosition;
    }

    public void OnInteract() 
    {
        Ray = cam.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(Ray.origin, Ray.direction, out hit, 100f))
        {

            if (hit.collider.gameObject.layer == 6)
            {
                hit.collider.gameObject.TryGetComponent<interactionAI>(out interactionAI Interactable);
                Interactable.enable_Outline();
                if (Input.GetKey(KeyCode.E))
                {
                    Interactable.Interact();
                }
            }
            else
            {

            }
        }

    }

    //void Update()
    //{
    //    Ray = cam.ScreenPointToRay(screenCenter);
    //    if (Physics.Raycast(Ray.origin,Ray.direction,out hit,100f))
    //    {
            
    //      if(hit.collider.gameObject.layer==6)
    //      {
    //        hit.collider.gameObject.TryGetComponent<interactionAI>(out interactionAI Interactable);
    //        Interactable.enable_Outline();
    //      if (Input.GetKey(KeyCode.E))
    //      {
    //        Interactable.Interact();
    //      }
    //      }
    //      else
    //      {
            
    //      }
    //    }
    //   //Debug.DrawLine(cam.transform.localPosition, hit.point, Color.red);


    //}
}
