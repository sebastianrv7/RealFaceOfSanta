using Unity.VisualScripting;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    private int itemNumber = 1;  

    [SerializeField]
    private bool disableOnCollect = true;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private ItemUIController uiController;

    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") & gameManager.HasItem == false)
        {
            
            if (GameManager.Instance.TryCollectItem(itemNumber))
            {
                
                gameObject.SetActive(false);
                uiController.ShowItem(icon);
                Destroy(gameObject);
            }
            
        }
    }

    private void CollectFeedback()
    {
      
        Debug.Log($"¡Item {itemNumber} recogido!");
        
    }
}
