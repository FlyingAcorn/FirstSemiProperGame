using UnityEngine;
public class Lights : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] private GameObject door;
    [SerializeField] private float leverCount;

    private void OnEnable()
    {
        LeverLight.LightToggle += LightSwitch;
    }

    private void LightSwitch(bool lever)
    {
        leverCount += lever ? +1:-1;
        switch (leverCount)
        {
            case 0:
                lights[0].SetActive(false);
                lights[1].SetActive(false);
                door.SetActive(true);
                break;
            case 1:
                lights[0].SetActive(true);
                lights[1].SetActive(false);
                door.SetActive(true);
                break;
            case 2:
                lights[0].SetActive(true);
                lights[1].SetActive(true);
                door.SetActive(false);
                break;
        }
    }

    private void OnDisable()
    {
        LeverLight.LightToggle -= LightSwitch;
    }
}
