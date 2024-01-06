using UnityEngine;
public class DissapearingPath : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private void OnDisable()
    {
        Instantiate(effect, transform.position, transform.rotation);
    }
}
