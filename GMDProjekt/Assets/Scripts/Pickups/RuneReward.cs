using UnityEngine;


public class RuneReward : MonoBehaviour, IPickup
{
    [SerializeField] private bool playerInRange;

    private void Start()
    {
        PlayerInputController.InteractEvent += ApplyReward;
    }

    public void ApplyReward()
    {
        if (!playerInRange) return;
        OpenRuneSelector();
        Destroy(gameObject);
    }

    private void OpenRuneSelector()
    {
        UIManager.Instance.EnableRuneSelectionPanel();
    }

    public void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    private void OnDestroy()
    {
        PlayerInputController.InteractEvent -= ApplyReward;
    }

    
}
