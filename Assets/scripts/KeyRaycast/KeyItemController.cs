using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool purpleDoor = false;
        [SerializeField] private bool greenKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (purpleDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (purpleDoor)
            {
                doorObject.PlayAnimation();
            }
            else if (greenKey)
            {
                _keyInventory.hasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
