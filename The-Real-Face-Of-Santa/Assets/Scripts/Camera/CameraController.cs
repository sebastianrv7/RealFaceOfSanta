using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera vcam;
    [SerializeField] private Transform player;

    public void FocusOn(Transform target)
    {
        vcam.Follow = target;
    }

    public void FocusOnPlayer()
    {
        FocusOn(player);
    }
}
