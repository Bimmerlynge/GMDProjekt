using UnityEngine;

namespace Stage
{
    public class LightController : MonoBehaviour
    {
        private float _max = 75f;
        private Transform _player;
        private Light _light;
        private float maxDistance = 7f;
        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            StageReward.OnRewardPickedUp += EnableLight;
        }

        private void OnDestroy()
        {
            StageReward.OnRewardPickedUp -= EnableLight;
        }

        private void LateUpdate()
        {
            SetLightIntensity();
        }

        private void EnableLight()
        {
            _light.enabled = true;
        }

        private void SetLightIntensity()
        {
            if (_player == null) return;
            var distance = Vector2.Distance(GetLightPosition(), GetPlayerPosition());
            _light.intensity = distance < maxDistance ? Calculate(distance) : 0f;
        }

        private float Calculate(float x)
        {
            return Slope() * x + _max;
        }

        private float Slope()
        {
            return -_max / maxDistance;
        }
        
        private Vector2 GetLightPosition()
        {
            return new Vector2(transform.position.x, transform.position.z);
        }

        private Vector2 GetPlayerPosition()
        {
            return new Vector2(_player.position.x, _player.position.z);
        }
    }
}