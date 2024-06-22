using System;
using UnityEngine;
public class LookAt:MonoBehaviour
{
    public enum Mode
    {
        LookAtCamera,
        LookAtInverted,
        LookAtCameraForward,
    }

    [SerializeField] private Mode _mode;
    private void Update()
    {
        switch (_mode)
        {
            case Mode.LookAtCamera:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position+(transform.position-Camera.main.transform.position));
                break;
            case Mode.LookAtCameraForward:
                transform.forward = - Camera.main.transform.forward;
                break;
            default:
                break;
        }
        
    }
}
