using UnityEngine;

public class SantaWeakPoint : MonoBehaviour
{
    [SerializeField]
    private ItemUIController uiController;

    [SerializeField]
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        int currentItem = GameManager.Instance.CurrentItem;
        bool hasCorrectItem = GameManager.Instance.HasItem && currentItem == 1;

        if (hasCorrectItem)
        {
            Debug.Log("<color=green><b>¡Santa pierde, ganaste!</b></color>");
            gameManager.WinGame();
            uiController.WinUi();
            
        }
        else
        {
            Debug.Log("<color=red><b>Santa gana, perdiste</b></color>");
            
            gameManager.LoseGame();
            uiController.DefeatUi();
        }


    }

}
