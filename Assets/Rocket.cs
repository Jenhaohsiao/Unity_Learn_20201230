using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidbody;
    AudioSource m_MyAudioSource;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        m_MyAudioSource = GetComponent<AudioSource>();
        rigidbody.mass = 0.08f;

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly");
                break;
            case "ok":
                print("OK");
                break;
            case "dead":
                print("Dead");
                SceneManager.LoadScene(0);
                break;
            case "ground":
                print("ground");
                break;
            case "Finish":
                print("Hit Finish");
                SceneManager.LoadScene(1);
                break;
        }
    }

    private void Thrust()
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
    }

    void Rotate()
    {

        rigidbody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) // can thrust while rotating
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);

        }

        if (Input.GetKey(KeyCode.D)) // can thrust while rotating
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        }

        rigidbody.freezeRotation = false;

    }




}
