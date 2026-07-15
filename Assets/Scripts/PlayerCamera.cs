using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera tpsCamera;

    public void Look(Vector2 _input, Vector3 _playerPos)
    {
        tpsCamera.transform.RotateAround(_playerPos, Vector3.up, _input.x);
    }
}
