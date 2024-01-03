using System;
public class LeverLight : Lever
{
    public static event Action<bool> LightToggle;

    public override void Interact()
    {
        base.Interact();
        switch (leverCondition)
        {
            case true:
                LightToggle?.Invoke(leverCondition);
                break;
            case false:
                LightToggle?.Invoke(leverCondition);
                break;
        }
    }
}
