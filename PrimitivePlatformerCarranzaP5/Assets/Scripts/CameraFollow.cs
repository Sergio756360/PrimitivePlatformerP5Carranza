using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (target != null)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = target.position + offset;
        }
    }
}