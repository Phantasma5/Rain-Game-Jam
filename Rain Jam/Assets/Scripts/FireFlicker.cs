using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    [SerializeField] private float MinIntensity;
    [SerializeField] private float MaxIntensity;
    [SerializeField] private float TimeDelta = 0.0f;
    [SerializeField] private Light light;

    private float timer = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= TimeDelta)
        {
            timer = 0.0f;
            light.intensity = Random.Range(MinIntensity, MaxIntensity);
        }
    }

    private void OnValidate()
    {
        if(light == null)
        {
            light = GetComponent<Light>();
        }
    }
}
