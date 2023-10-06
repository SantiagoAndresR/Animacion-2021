using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform armTarget; // Objeto de destino del brazo en el inspector
    public float armRotationSpeed = 5.0f; // Velocidad de rotaci�n del brazo

    void Update()
    {
        // Obt�n la posici�n actual del mouse en pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Convierte la posici�n del mouse a un punto en el mundo 3D
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // Calcula la direcci�n desde el brazo hacia la posici�n del mouse
        Vector3 direction = worldPosition - armTarget.position;

        // Calcula la rotaci�n necesaria para apuntar hacia el mouse
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Aplica la rotaci�n al brazo (ajusta seg�n tu jerarqu�a de huesos)
        // Por ejemplo, si el brazo es un hijo del personaje y la mano es un hijo del brazo:
        // armTarget.parent.rotation = rotation;

        // Otra opci�n si usas Animation Rigging:
        armTarget.parent.transform.rotation = Quaternion.Slerp(armTarget.parent.transform.rotation, rotation, armRotationSpeed * Time.deltaTime);
    }
}
