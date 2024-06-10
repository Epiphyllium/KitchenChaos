using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";
    
    private Animator walkingAnimator;

    [SerializeField] private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        walkingAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walkingAnimator.SetBool(IS_WALKING,_player.GetIsWalking());
    }
}
