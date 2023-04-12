using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteraction : MonoBehaviour, IPointerClickHandler
{
    new private Collider2D collider2D;

    void Start()
    {
        // Get the Collider2D component of the object
        collider2D = GetComponent<Collider2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Disable the Collider2D component of the object
        collider2D.enabled = false;

        // Check for collisions with other objects here
        // ...

        // Re-enable the Collider2D component of the object
        collider2D.enabled = true;
    }
}
