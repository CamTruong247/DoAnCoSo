using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{

    private float buyhealth;
    private float buymana;
    private float buyattack;
    private float buyskill;

    private void Start()
    {
        
    }

    public void BuyHealth()
    {
        if(MoneyUI.main.money >= float.Parse(Shop.main.pricehealth.text))
        {
            buyhealth = float.Parse(PlayerPrefs.GetString("UseHealth"));
            buyhealth++;
            PlayerPrefs.SetString("UseHealth", buyhealth.ToString());
            MoneyUI.main.MoneyBuy(10);
            PlayerStats.main.UpdateUseHealth(1);
        }
    }

    public void BuyMana()
    {
        if(MoneyUI.main.money >= float.Parse(Shop.main.pricemana.text))
        {
            buymana = float.Parse(PlayerPrefs.GetString("UseMana"));
            buymana++;
            PlayerPrefs.SetString("UseMana", buymana.ToString());
            MoneyUI.main.MoneyBuy(10);
            PlayerStats.main.UpdateUseMana(1);
        }
    }

    public void BuyAttack()
    {
        if (MoneyUI.main.money >= float.Parse(Shop.main.priceattack.text))
        {
            buyattack = PlayerPrefs.GetFloat("Attack");
            buyattack++;
            PlayerPrefs.SetFloat("Attack", buyattack);
            MoneyUI.main.MoneyBuy(20);
            PlayerStats.main.UpdateAttack(1);
        }
    }
    public void BuySkill()
    {
        if (MoneyUI.main.money >= float.Parse(Shop.main.priceskill.text))
        {
            buyskill = PlayerPrefs.GetFloat("Skill");
            buyskill++;
            PlayerPrefs.SetFloat("Skill", buyskill);
            MoneyUI.main.MoneyBuy(20);
            PlayerStats.main.UpdateSkill(1);
        }
    }
}
