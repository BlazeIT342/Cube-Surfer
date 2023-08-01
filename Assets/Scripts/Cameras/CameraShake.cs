using Cinemachine;
using TZ.Core;
using TZ.EventController;
using UnityEngine;

namespace TZ.Cameras
{
    public class CameraShake : MonoBehaviour
    {
        CinemachineVirtualCamera virtualCamera;
        float shakeAmplitude = 2f;
        float shakeFrequency = 3.0f;

        float shakeElapsedTime = 0f;
        float duration = 0.2f;

        private void OnEnable()
        {
            GameEventManager.instance.onAddNewCube.AddListener(OnAddNewCube);
            GameEventManager.instance.onCollisionWall.AddListener(OnCollisionWall);
        }

        private void OnDisable()
        {
            GameEventManager.instance.onAddNewCube.RemoveListener(OnAddNewCube);
            GameEventManager.instance.onCollisionWall.RemoveListener(OnCollisionWall);
        }

        private void OnAddNewCube(bool isGameRunning)
        {
            ShakeCamera(duration);
        }

        private void OnCollisionWall(bool isGameRunning)
        {
            ShakeCamera(duration);
        }

        private void Start()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public void ShakeCamera(float duration)
        {
            CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = shakeAmplitude;
            noise.m_FrequencyGain = shakeFrequency;
            shakeElapsedTime = duration;
            VibrationManager.Vibrate(20);
        }

        private void Update()
        {
            if (shakeElapsedTime > 0)
            {
                shakeElapsedTime -= Time.deltaTime;
                if (shakeElapsedTime <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    noise.m_AmplitudeGain = 0f;
                    noise.m_FrequencyGain = 0f;
                }
            }
        }
    }
}
