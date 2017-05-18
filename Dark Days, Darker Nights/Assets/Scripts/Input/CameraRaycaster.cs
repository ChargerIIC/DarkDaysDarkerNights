using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycaster : MonoBehaviour
{
    // INSPECTOR PROPERTIES RENDERED BY CUSTOM EDITOR SCRIPT
    [SerializeField] int[] layerPriorities;

    float maxRaycastDepth = 100f; // Hard coded value
    int topPriorityLayerLastFrame = -1; // So get ? from start with Default layer terrain

    // Setup delegates for broadcasting layer changes to other classes
    public delegate void OnCursorLayerChange(int newLayer); // declare new delegate type

    public event OnCursorLayerChange notifyLayerChangeObservers; // instantiate an observer set

    public delegate void OnClickPriorityLayer(RaycastHit raycastHit, int layerHit); // declare new delegate type

    public event OnClickPriorityLayer notifyMouseClickObservers; // instantiate an observer set //TODO: Split into right and left click observers


    void Update()
    {
        if (Camera.main == null)
            return;
        // Check if pointer is over an interactable UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            NotifyObserversIfLayerChanged(5); //TODO: Determine why the hell we have a magic number here and then do penance.
            return; // Stop looking for other objects
        }

        // Raycast to max depth, every frame as things can move under mouse
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray, maxRaycastDepth);

        RaycastHit? priorityHit = FindTopPriorityHit(raycastHits);
        if (!priorityHit.HasValue) // if hit no priority object
        {
            NotifyObserversIfLayerChanged(0); // broadcast default layer
            return;
        }

        // Notify delegates of layer change
        var layerHit = priorityHit.Value.collider.gameObject.layer;
        NotifyObserversIfLayerChanged(layerHit);

        // Notify delegates of highest priority game object under mouse when clicked
        //Reminder - target must have collider!
        if (Input.GetMouseButton(0))
        {
            notifyMouseClickObservers(priorityHit.Value, layerHit);
        }
    }

    void NotifyObserversIfLayerChanged(int newLayer)
    {
        if (newLayer != topPriorityLayerLastFrame)
        {
            topPriorityLayerLastFrame = newLayer;
            if (notifyLayerChangeObservers != null)
                notifyLayerChangeObservers(newLayer);
        }
    }

    RaycastHit? FindTopPriorityHit(RaycastHit[] raycastHits)
    {
        // Form list of layer numbers hit
        List<int> layersOfHitColliders = new List<int>();
        foreach (RaycastHit hit in raycastHits)
        {
            layersOfHitColliders.Add(hit.collider.gameObject.layer);
        }

        // Step through layers in order of priority looking for a gameobject with that layer
        foreach (int layer in layerPriorities)
        {
            foreach (RaycastHit hit in raycastHits)
            {
                if (hit.collider.gameObject.layer == layer)
                {
                    return hit; // stop looking
                }
            }
        }

        return null; 
    }
}
