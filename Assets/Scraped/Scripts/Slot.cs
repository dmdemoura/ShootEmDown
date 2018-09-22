using System;
using UnityEngine;

public class Slot : MonoBehaviour {
    
    ModuleDrag currentHoveringModuleDrag;
    public bool isOccupied = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Module")
        {
            currentHoveringModuleDrag = other.GetComponent<ModuleDrag>();
            if(!isOccupied)
                currentHoveringModuleDrag.isHoveringSlot = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Module")
        {
            if(Input.GetMouseButtonUp(0) && !isOccupied)
            {
                isOccupied = true;
                currentHoveringModuleDrag.isHoveringSlot = false;
                currentHoveringModuleDrag.isAttached = true;
                currentHoveringModuleDrag.fixedPos = this.transform.position;

                if(currentHoveringModuleDrag.attachedSlot != null)
                    currentHoveringModuleDrag.attachedSlot.isOccupied = false;
                
                currentHoveringModuleDrag.attachedSlot = this;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Module")
        {
            currentHoveringModuleDrag.isHoveringSlot = false;
        }
    }

}