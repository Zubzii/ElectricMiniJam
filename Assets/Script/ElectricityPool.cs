using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElectricityPool : MonoBehaviour
{
    public GameObject manaBar;
    private  Image manaBarImage;

    public GameObject shield;
    private SpriteRenderer shieldImage;
    private Collider2D shieldCollider;

    public GameObject playerLight;
    private Light2D light2D;

    public float mana = 1f;
    public float manaReductionSpeed = .01f;

    private void Awake()
    {
        manaBarImage = manaBar.GetComponent<Image>();
        shieldCollider = shield.GetComponent<Collider2D>();
        shieldImage = shield.GetComponent<SpriteRenderer>();
        light2D = playerLight.GetComponent <Light2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shieldCollider.enabled = false;
        shieldImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        shieldActivate();
        lightSource();
        manaReduction();
    }

    public void shieldActivate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shieldCollider.enabled = true;
            shieldImage.enabled = true;
            mana -= 0.1f * Time.deltaTime;
            manaBarImage.fillAmount = mana;
        }
        else
        {
            shieldCollider.enabled = false;
            shieldImage.enabled = false;
        }
    }

    public void lightSource()
    {
        light2D.pointLightOuterRadius = mana*10;

        if (light2D.pointLightOuterRadius < .01) 
        {
            SceneManager.LoadScene(2);
            mana = 0;
        }
    }

    public void manaReduction()
    {
        mana -= manaReductionSpeed*Time.deltaTime;
        manaBarImage.fillAmount = mana;

    }

}
