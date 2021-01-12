using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidbody;
    AudioSource m_MyAudioSource;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        m_MyAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {



        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            rigidbody.AddRelativeForce(Vector3.up);
            if (!m_MyAudioSource.isPlaying)
            {
                m_MyAudioSource.Play();
            }


        }
        else
        {
            m_MyAudioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A)) // can thrust while rotating
        {
            //rigidbody.AddRelativeForce(Vector3.right);
            transform.Rotate(Vector3.forward);
             
        }

        if (Input.GetKey(KeyCode.D)) // can thrust while rotating
        {
            //rigidbody.AddRelativeForce(Vector3.left);
            transform.Rotate(-Vector3.forward);
           
        }

    }
}
