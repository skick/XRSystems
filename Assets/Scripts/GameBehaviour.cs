using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameBehaviour : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 currPosition;
    private Vector3 buttonBoxPos;
    private Vector3 scale;
    private float startRange;

    public BallDrop ball;
    public ScalingBehaviour scaling;
    public List<PressableButton> buttons;
    public GameObject player;
    public AudioSource beep;
    public GameObject buttonBox;
    public Light infoSpotLight;

    Transform ballTransform;
    Transform playerTransform;

    void Start()
    {
        ballTransform = ball.GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();
        startRange = infoSpotLight.GetComponent<Light>().range;
    }

    void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Transform buttonTransform = buttons[i].GetComponent<Transform>();
            Rigidbody buttonRigid = buttons[i].GetComponent<Rigidbody>();
            currPosition = buttonTransform.localPosition;
            if ((buttons[i].GetPosition().y - currPosition.y) > (0.1f * buttonTransform.localScale.y))
            {
                beep.Play(0);
                ChangeScale(buttons[i].multiplyer); // changes the scale of player ball and buttons
                MoveBallPlayer(buttons[i].multiplyer); //moves the player and the ball to the center
                SetButtonPositions(); // Resets the buttons
                infoSpotLight.GetComponent<Light>().range = startRange * buttons[i].multiplyer;
                break;
            }
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
            player.GetComponent<CharacterController>().enabled = true;
        }

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            RestartGame();
        }
    }

    public void ChangeScale(float multiplyer)
    {
        scaling.ChangeScale(multiplyer);

    }

    public void MoveBallPlayer(float multiplyer)
    {
        buttonBoxPos = buttonBox.GetComponent<Transform>().position;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Transform>().position = buttonBoxPos + new Vector3(-1f * multiplyer, 0f, 0f);
        player.GetComponent<CharacterController>().enabled = true;

        ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        ball.GetComponent<Transform>().position = buttonBoxPos + new Vector3(1f * multiplyer, 0f, 0f);
    }


    public void SetButtonPositions()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Transform>().localPosition = buttons[i].GetPosition();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}
