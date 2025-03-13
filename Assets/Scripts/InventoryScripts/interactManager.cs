using UnityEngine;

public class interactManager : MonoBehaviour
{
    [SerializeField] LayerMask itemLayer;
    public InventorySystem inventorySystem;
    public float maxDistance;

    void Start()
    {
        inventorySystem = GetComponent<InventorySystem>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit interactable;
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayOrigin, out interactable, maxDistance, itemLayer))
            {
                Debug.Log(interactable.transform);
            }
        }
    }
}
