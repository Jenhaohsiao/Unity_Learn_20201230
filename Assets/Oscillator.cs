using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;

    [Range(0, 1)] [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;


    void Start()
    {
        movementVector = new Vector3(10f, 10f, 10f);
        period = 2f;
        startingPos = transform.position;

    }

    void Update()
    {
        //todo protect against period is zero

        if (period <= Mathf.Epsilon)
        {
            return;
        };

        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
