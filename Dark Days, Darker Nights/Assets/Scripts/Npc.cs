using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    public DialogueFile CharacterDialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.gameObject == this) //TODO: need null checks
        //        {
        //            FindObjectOfType<DialogController>().StartConversation();
        //        }
        //    }

        //}
    }

    void OnMouseClick()
    {
        
    }

}
