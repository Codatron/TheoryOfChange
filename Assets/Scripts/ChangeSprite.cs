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
            transform.localScale = ChangeScale(0.40f, 0.40f, 0.0f);
        }
        else if (transform.position.y > -1.0f)
        {
            transform.localScale = ChangeScale(0.55f, 0.55f, 0.0f);
        }
        else if (transform.position.y > -2.0f)
        {
            transform.localScale = ChangeScale(0.65f, 0.65f, 0.0f);
        }
        else if (transform.position.y > -3.0f)
        {
            transform.localScale = ChangeScale(0.70f, 0.70f, 0.0f);

            spriteRend.sortingOrder = -2;
        }
        else if (transform.position.y > -4.0f)
        {
            transform.localScale = ChangeScale(0.85f, 0.850f, 0.0f);

            spriteRend.sortingOrder = -1;
        }
        else if (transform.position.y > -5.0f)
        {
            spriteRend.sortingOrder = 0;
        }
    }

    Vector3 ChangeScale(float x, float y, float z)
    {
        var scaleChange = new Vector3(x, y, z);
        return scaleChange;
    }
}
