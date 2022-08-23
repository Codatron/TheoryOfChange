using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    
    private SpriteRenderer spriteRend;

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InitSprite();
    }

    void InitSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRend.sprite = sprites[randomIndex];

        //int randomOrder = Random.Range(-2, -15);
        //spriteRend.sortingOrder = randomOrder;

        //transform.localScale /= randomOrder * -1;

        //if (transform.position.y > -4.0f && transform.position.y < -2.0f)
        //{
        //    spriteRend.sortingOrder = -3;
        //}
        //else if (transform.position.y > -1.9f && transform.position.y < -0.0f)
        //{
        //    spriteRend.sortingOrder = -5;
        //}

    }
}
