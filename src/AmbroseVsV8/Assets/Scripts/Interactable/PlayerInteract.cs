using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        cam = GetComponent<FirstPersonController>().playerCamera;
    }

    private void Update()
    {
        Ray ray = new(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        if (Physics.Raycast(ray, out var hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                var interactable = hitInfo.collider.GetComponent<Interactable>();
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
