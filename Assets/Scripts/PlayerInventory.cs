using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Light flashlight1;
    int slot = 1;
    bool isFlashLightOn;
    int numberOfStones = 10;
    void Start()
    {
        
    }

    
    void Update()
    {
        ChangeSlot();
        UseItem();
    }

    void ChangeSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot = 2;
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            switch ( slot ) 
            {
                case 1: // Flashlight
                    if (isFlashLightOn)
                    {
                        isFlashLightOn = false;
                    }
                    else
                    {
                        isFlashLightOn = true;
                    }
                    OnOffFlashlight();
                    break;
                case 2: // Stones
                    if (numberOfStones > 0)
                    {
                        ThrowStone();
                    }
                    break;
            }
        }
    }

    void OnOffFlashlight()
    {
        flashlight1.enabled = !flashlight1.isActiveAndEnabled;
    }

    void ThrowStone()
    {
        
    }


}
