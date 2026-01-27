using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ItemUIController: MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image itemIcon;
        

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject defeatPanel;

    

    private Coroutine currentRoutine;

    private void Awake()
    {
        
        winPanel.SetActive(false);
        defeatPanel.SetActive(false);   
        panel.SetActive(false);
    }

    public void ShowItem(Sprite icon)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        itemIcon.sprite = icon;        

        panel.SetActive(true);
        
    }

    public void WinUi()
    {
        winPanel.SetActive(true);
    }

    public void DefeatUi()
    {
        defeatPanel.SetActive(true);
    }

    
}
