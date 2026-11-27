using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    void OnEnable()
    {
        playerInventory.OnFail += Lose;
    }
    void OnDisable()
    {
        playerInventory.OnFail -= Lose;
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Goal") )
        {
            Win();
        }
    }

    void Win()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Lose()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
