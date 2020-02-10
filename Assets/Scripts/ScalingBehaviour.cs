using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingBehaviour : MonoBehaviour
{

    public PlayerBehaviour player;
    public BallBehaviour ball;
    public GameObject buttons;
    private Vector3 buttonOrigPos;
    private Transform buttonsTransform;

    void Start()
    {
        buttonsTransform = buttons.GetComponent<Transform>();
        buttonOrigPos = buttonsTransform.position;

    }

    public void ChangeScale(float multiplyer)
    {
        ball.ChangeScale(multiplyer);
        player.ChangeScale(multiplyer);
        buttonsTransform.localScale = new Vector3(multiplyer, multiplyer, multiplyer);
        buttonsTransform.position = new Vector3(
                                            buttonOrigPos.x,
                                            buttonOrigPos.y * buttonsTransform.localScale.y,
                                            buttonOrigPos.z);

    }


}
