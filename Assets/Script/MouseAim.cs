using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Camera Cam;
    Vector3 aim;
    public float speed = 2f;
    private bool isAiming = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAiming = !isAiming;
        }

        if (isAiming)
        {
            aim = Input.mousePosition;
            aim.z = speed;
            transform.position = Cam.ScreenToWorldPoint(aim);
        }
    }
}
