using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI txtmoney;

    public static MoneyUI main;
    public float money;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            txtmoney.text = PlayerPrefs.GetString("Money");
        }
        money = float.Parse(txtmoney.text);
    }

    private void Update()
    {
        txtmoney.text = money.ToString();
        PlayerPrefs.SetString("Money",txtmoney.text);
    }

    public void MoneyBuy(float money)
    {
        this.money -= money;
        txtmoney.text = this.money.ToString();
    }

    public void UpdateMoney(float money)
    {
        this.money += money;
        txtmoney.text = this.money.ToString();
    }
}
