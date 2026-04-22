using Unity.Cinemachine;
using UnityEngine;

public class CineCamShake : MonoBehaviour
{
    private CinemachineCamera cineCam;
    float shakeTimer;

    private void Awake()
    {
        cineCam = GetComponent<CinemachineCamera>();
    }

    

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cineCamPerlin = cineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();

        cineCamPerlin.AmplitudeGain = intensity;
        shakeTimer = time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.fixedDeltaTime;
        }
        if(shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cineCamPerlin = cineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
            cineCamPerlin.AmplitudeGain = 0;
        }
    }
}
