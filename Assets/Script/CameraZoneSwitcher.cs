using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoneSwitcher : MonoBehaviour
{
    public Dictionary<string, CinemachineVirtualCameraBase> cameraZoneMap;
    private CinemachineBrain cinemachineBrain;

  
    public CinemachineVirtualCameraBase camera1;
    public CinemachineVirtualCameraBase camera2;
    public CinemachineVirtualCameraBase camera3;

    private void Start()
    {

        cameraZoneMap = new Dictionary<string, CinemachineVirtualCameraBase>();
   
        cameraZoneMap["Zona1"] = camera1;
        cameraZoneMap["Zona2"] = camera2;
        cameraZoneMap["Zona3"] = camera3;
        
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zona"))
        {
            string zonaName = other.name;

            // Verifica si la zona tiene una c�mara asignada
            if (cameraZoneMap.ContainsKey(zonaName))
            {
                // Activa la c�mara correspondiente a la zona
                CinemachineVirtualCameraBase camera = cameraZoneMap[zonaName];

                // Cambia la c�mara activa utilizando CinemachineBrain (no necesitas desactivar otras c�maras)
                cinemachineBrain.enabled = false; // Desactiva temporalmente Cinemachine
                cinemachineBrain.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.Cut, 0); // Cambia de c�mara sin transici�n
                cinemachineBrain.enabled = true; // Reactiva Cinemachine

                // Opcional: Puedes desactivar las otras c�maras si es necesario, pero no es recomendable
                // porque ya has cambiado la c�mara activa
                foreach (var kvp in cameraZoneMap)
                {
                    if (kvp.Value != camera)
                    {
                        kvp.Value.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
