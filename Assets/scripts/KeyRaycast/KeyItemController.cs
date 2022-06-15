using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] public bool purpleDoor = false;
        [SerializeField] public bool blueDoor = false;
        [SerializeField] public bool greenKey = false;
        [SerializeField] public bool redKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (purpleDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
            else if (blueDoor)
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
            else if (blueDoor)
            {
                doorObject.PlayAnimation();
            }
            else if (greenKey)
            {
                _keyInventory.hasGreenKey = true;
                gameObject.SetActive(false);
            }
            else if (redKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
