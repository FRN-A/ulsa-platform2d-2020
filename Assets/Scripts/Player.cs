using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Player : Character2D
{
    public Vector2 Pos {get;set;}

    [SerializeField]
    float maxVel;

    void Start()
    {
        transform.position = GameManager.instance.GameData.PlayerPos;
    }

    void FixedUpdate()
    {        
        if(GameplaySystem.JumpBtn){
            if(Grounding)
            {
                GameManager.instance.GameData.PlayerPos = transform.position;
                //Debug.Log(Gamemanager.instance.gameData.Player);
                GameManager.instance.Save();
                anim.SetTrigger("jump");
                GameplaySystem.Jump(rb2D, jumpForce);
            }
        }
        anim.SetBool("grounding", Grounding);
        GameplaySystem.MovementVelocity(rb2D, moveSpeed, maxVel);
    }
    void Update()
    { 
       //GameplaySystem.TMovementDelta(transform, moveSpeed);
    }

    void LateUpdate()
    {
        //spr.flipX = FlipSprite;
        IFlip flip = new PlayerFlip();
        spr.flipX = flip.FlipSprite(GameplaySystem.Axis.x, spr);
        anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("collectable"))
        {
            Collectable collectable = other.GetComponent<Collectable>();
            GameManager.instance.Score.AddPoints(collectable.Points);
            //score.AddPoints(collectable.Points);
            Destroy(other.gameObject);
        }
    }
}
