using Unity.Cinemachine;
using UnityEngine;

public class NPCInteraction: MonoBehaviour
{
    [SerializeField] private CameraController cameraController;

    [SerializeField]
    private string[] npcDialogues;

    [SerializeField]
    private DialogueController dialogueController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInputHandler input = other.GetComponent<PlayerInputHandler>();

            if (input != null)
            {
                input.DisableInput();
                
            }
            cameraController.FocusOn(transform);
            dialogueController.InitializeDialogue(npcDialogues);
            dialogueController.StartDialogue();
        }

                
    }

}
