using UnityEngine;

public class LeverDoor : Lever
{
    [SerializeField] private GameObject door;

    public override void Interact()
    {
        base.Interact();
        door.SetActive(!leverCondition);
    }
}
