using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CurrentItem { get; private set; } = 0;     // 0 = nada, 1-3 = items
    public bool HasItem => CurrentItem != 0;

    [SerializeField]
    private ItemUIController uiController;

    

    [SerializeField]
    private SantaCombat santa;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool TryCollectItem(int itemNumber)
    {
        if (HasItem)
        {
            // Opcional: mostrar mensaje "Ya tienes un item, reinicia para escoger otro"
            Debug.LogWarning("¡Ya tienes un item! No puedes recoger más.");
            return false;
        }

        CurrentItem = itemNumber;
        Debug.Log($"Item recogido: {itemNumber}");

        // Aquí puedes disparar eventos, actualizar UI, guardar partida, etc.
        OnItemCollected?.Invoke(itemNumber);

        return true;
    }

    public void ResetItem()
    {
        CurrentItem = 0;
        Debug.Log("Item liberado / juego reiniciado");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        PlayerInputHandler inputHandler = FindObjectOfType<PlayerInputHandler>();

        inputHandler.DisableInput();
        santa.SantaWin();
        santa.StopCombatImmediate();
        uiController.WinUi();

        
    }

    public void LoseGame()
    {
        PlayerInputHandler inputHandler = FindObjectOfType<PlayerInputHandler>();

        santa.SantaWin();
        inputHandler.DisableInput();
        santa.StopCombatImmediate();
        uiController.DefeatUi();
        

        
    }
    
    public delegate void ItemCollectedHandler(int itemNumber);
    public event ItemCollectedHandler OnItemCollected;


}
