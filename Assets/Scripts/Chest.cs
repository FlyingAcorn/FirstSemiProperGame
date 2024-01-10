using UnityEngine;

public class Chest : MonoBehaviour,ICollision
{
    private MeshFilter _myMeshFilter;
    private MeshCollider _myMeshCollider;
    [SerializeField] private Mesh[] chests;
    [SerializeField] private GameObject confetti;
    
    
    [SerializeField] private bool chestToggle;

    private void Start()
    {
        _myMeshFilter = GetComponent<MeshFilter>();
        _myMeshCollider = GetComponent<MeshCollider>();
    }

    public void Interact()
    {
        chestToggle = !chestToggle;
        _myMeshFilter.mesh = chestToggle ? chests[0] : chests[1];
        _myMeshCollider.sharedMesh = chestToggle ? chests[0] : chests[1];
        confetti.SetActive(chestToggle);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Win);

    }
}
