using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject blackUI;
    [SerializeField] private TextMeshProUGUI txtoldhealth;
    [SerializeField] private TextMeshProUGUI txtnewhealth;
    [SerializeField] public TextMeshProUGUI pricehealth;
    [SerializeField] private TextMeshProUGUI txtoldmana;
    [SerializeField] private TextMeshProUGUI txtnewmana;
    [SerializeField] public TextMeshProUGUI pricemana;
    [SerializeField] private TextMeshProUGUI txtoldattack;
    [SerializeField] private TextMeshProUGUI txtnewattack;
    [SerializeField] public TextMeshProUGUI priceattack;
    [SerializeField] private TextMeshProUGUI txtoldskill;
    [SerializeField] private TextMeshProUGUI txtnewskill;
    [SerializeField] public TextMeshProUGUI priceskill;

    public static Shop main;
    private int health;
    private int mana;
    private float attack;
    private float skill;

    private void Awake()
    {
        main = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shop.SetActive(true);
            blackUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shop.SetActive(false);
        blackUI.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("UseHealth"))
        {
            txtoldhealth.text = PlayerPrefs.GetString("UseHealth");
            newhealth();
        }
        if (PlayerPrefs.HasKey("UseMana"))
        {
            txtoldmana.text = PlayerPrefs.GetString("UseMana");
            newmana();
        }
        if (PlayerPrefs.HasKey("Attack"))
        {
            txtoldattack.text = PlayerPrefs.GetFloat("Attack").ToString();
            newmana();
        }
        if (PlayerPrefs.HasKey("Skill"))
        {
            txtoldskill.text = PlayerPrefs.GetFloat("Skill").ToString();
            newmana();
        }
        pricehealth.text = "10";
        pricemana.text = "10";
        priceattack.text = "20";
        priceskill.text = "20";
    }

    private void Update()
    {
        txtoldhealth.text = PlayerStats.main.txtusehealth.text;
        newhealth();
        txtoldmana.text = PlayerStats.main.txtusemana.text;
        newmana();
        txtoldattack.text = PlayerStats.main.damageattack.ToString();
        newattack();
        txtoldskill.text = PlayerStats.main.damagebullet.ToString();
        newskill();
    }

    private void newhealth()
    {
        health = int.Parse(txtoldhealth.text);
        txtnewhealth.text = (health + 1).ToString();
    }

    private void newmana()
    {
        mana = int.Parse(txtoldmana.text);
        txtnewmana.text = (mana + 1).ToString();
    }

    private void newattack()
    {
        attack = float.Parse(txtoldattack.text);
        txtnewattack.text = (attack + 1).ToString();
    }

    private void newskill()
    {
        skill = float.Parse(txtoldskill.text);
        txtnewskill.text = (skill + 1).ToString();
    }
}
