using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<ParticleSystem>().Play();
            CameraShaker.Invoke();
        }
    }
}
