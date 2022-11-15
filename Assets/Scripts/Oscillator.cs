using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
   Vector3 startingPoint;
   [SerializeField] Vector3 endPoint;
   [SerializeField] [Range(0,1)] float movement;
    [SerializeField] float period = 2f;
    const float tau = 2 * Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        float rawSineWave = Mathf.Sin(tau * cycles);
        movement = (rawSineWave + 1f) / 2;
        Vector3 offset = endPoint * movement;
        transform.position = startingPoint + offset;
    }
}
