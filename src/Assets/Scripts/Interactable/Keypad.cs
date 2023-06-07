using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject Door;
    private bool DoorOpen;

    protected override void Interact()
    {
        DoorOpen = !DoorOpen;
        Door.GetComponent<Animator>().SetBool("IsOpen", DoorOpen);
    }
}
