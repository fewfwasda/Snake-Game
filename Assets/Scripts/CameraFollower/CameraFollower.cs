using UnityEngine;
public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.y = Target.position.y + 3;
        transform.position = transformPosition;
    }
}