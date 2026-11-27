using UnityEngine;
using System;
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Light flashlight1;
    [SerializeField] private GameObject rock;
    [SerializeField] private Transform playerCamera;
    public event Action OnFail;
    private int slot = 1;
    private int numberOfStones = 10;
    public float batteryLife = 100;

    void Start()
    {
        
    }

    
    void Update()
    {
        ChangeSlot();
        UseItem();
        BatteryDrain();
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
                case 1: 
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
        if (batteryLife <= 0) return;
        flashlight1.enabled = !flashlight1.isActiveAndEnabled;
    }

    void ThrowStone()
    {
        if (numberOfStones <= 0) return;
        numberOfStones--;

        Vector3 currentPosition = playerCamera.position;
        Quaternion currentRotation = playerCamera.rotation;
        GameObject spawnedRock = Instantiate(rock, currentPosition, currentRotation);
        Rigidbody rb = spawnedRock.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = playerCamera.forward * 3; 
        }

    }

    void BatteryDrain()
    {
        if (batteryLife < 0)
        {
            batteryLife = 0;
            return;
        }
        if (flashlight1.isActiveAndEnabled) 
        {
            batteryLife -= Time.deltaTime;
        }
        if (batteryLife <= 0)
        {
            flashlight1.enabled = false;
            OnFail?.Invoke();
        }
    }

}
