using UnityEngine;


public class BossCameraScript : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private GameObject focusPoin;

    [SerializeField]
    private SantaCombat santaCombat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(santaCombat.combatStarted == true)
            {
                
                return;
            }
            cameraController.FocusOn(focusPoin.transform);
            santaCombat.StartCombat();
            
            santaCombat.combatStarted = true;
        }
    }
}
