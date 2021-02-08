using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    Rigidbody rigidbody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;


    void Start()
    {
        //todo: shomewhere stop sound onn death
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidbody.mass = 0.08f;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();

        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (state != State.Alive)
        {
            return;
        };

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly");
                break;
            case "ok":
                print("OK");
                break;

            case "ground":
                print("ground");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        print("Hit something deadly");
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("LoadFirstLevel", 1f);
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", 1f);
    }

    private void LoadFirstLevel()
    {
        print("Load fiirst level");
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        //Todo: allow foor moore thann 2 levels;
        SceneManager.LoadScene(1);

    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            ApplyThrust();

        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ApplyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    void RespondToRotateInput()
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
