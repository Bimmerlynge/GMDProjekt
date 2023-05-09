using UnityEngine;

namespace Interactables
{
    public interface IInteractable
    {
        void Start();
        void OnDestroy();
        void OnInteract();
        void OnTriggerEnter(Collider other);
        void OnTriggerExit(Collider other);
    
    }
}
