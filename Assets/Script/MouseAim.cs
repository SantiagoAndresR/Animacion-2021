using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Camera Cam;
    Vector3 aim;
    public float speed = 2f;
    public GameObject target;
    private bool isAiming = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            isAiming = !isAiming;

          
            target.SetActive(isAiming);
        }

   
        if (isAiming)
        {
            aim = Input.mousePosition;
            aim.z = speed;
            transform.position = Cam.ScreenToWorldPoint(aim);
        }
    }
}
