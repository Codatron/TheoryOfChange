using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    //public Sprite[] sprites;
    //public GameObject[] flowers;

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
        //int randomIndex = Random.Range(0, sprites.Length);
        //spriteRend.sprite = sprites[randomIndex];

        //int randomIndex = Random.Range(0, flowers.Length);
        //spriteRend.sprite = sprites[randomIndex];
        spriteRend.sortingOrder = -5;

        if (transform.position.y > 0.0f)
        {
            transform.localScale = ChangeScale(0.50f, 0.50f, 0.0f);
        }
        else if (transform.position.y > -1.0f)
        {
            transform.localScale = ChangeScale(0.6f, 0.6f, 0.0f);
        }
        else if (transform.position.y > -2.0f)
        {
            transform.localScale = ChangeScale(0.7f, 0.7f, 0.0f);
        }
        else if (transform.position.y > -3.0f)
        {
            transform.localScale = ChangeScale(0.80f, 0.80f, 0.0f);

            spriteRend.sortingOrder = -2;
        }
        else if (transform.position.y > -4.0f)
        {
            transform.localScale = ChangeScale(0.90f, 0.90f, 0.0f);

            spriteRend.sortingOrder = -1;
        }
        else if (transform.position.y > -5.0f)
        {
            spriteRend.sortingOrder = 0;
        }
        else if (transform.position.y > -7.0f)
        {
            spriteRend.sortingOrder = 1;
        }
    }

    Vector3 ChangeScale(float x, float y, float z)
    {
        var scaleChange = new Vector3(x, y, z);
        return scaleChange;
    }
}
