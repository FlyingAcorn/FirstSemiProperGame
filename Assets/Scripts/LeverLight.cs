using System;
public class LeverLight : Lever
{
    public static event Action<bool> LightToggle;

    private void OnDisable()
    {
        leverCondition = false;
        LeverSwitch();
    }

    public override void Interact()
    {
        base.Interact();
        SendEvent();
    }

    protected void SendEvent()
    {
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
