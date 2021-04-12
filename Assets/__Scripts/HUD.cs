﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject soulCounter;
    private Text text1;

    public GameObject health;
    public GameObject attackDamage;
    public GameObject attackSpeed;
    public GameObject projSpeed;

    

    void Start()
    {

        text1 = soulCounter.GetComponent<Text>();

        if (GlobalVarStore.Equipped == "default")
        {
            Text text2 = health.GetComponent<Text>();
            text2.text = "Max Health: 200";

            Text text3 = attackDamage.GetComponent<Text>();
            text3.text = "Attack Damage: 50";

            Text text4 = attackSpeed.GetComponent<Text>();
            text4.text = "Attack Speed: 1x";

            Text text5 = projSpeed.GetComponent<Text>();
            text5.text = "Projectile Speed: 15";
        }
        if (GlobalVarStore.Equipped == "fire")
        {
            Text text6 = health.GetComponent<Text>();
            text6.text = "Max Health: 150";

            Text text7 = attackDamage.GetComponent<Text>();
            text7.text = "Attack Damage: 30";

            Text text8 = attackSpeed.GetComponent<Text>();
            text8.text = "Attack Speed: 1x";

            Text text9 = projSpeed.GetComponent<Text>();
            text9.text = "Projectile Speed: 20";
        }
        if (GlobalVarStore.Equipped == "ice")
        {
            Text text10 = health.GetComponent<Text>();
            text10.text = "Max Health: 300";

            Text text11 = attackDamage.GetComponent<Text>();
            text11.text = "Attack Damage: 25";

            Text text12 = attackSpeed.GetComponent<Text>();
            text12.text = "Attack Speed: 1x";

            Text text13 = projSpeed.GetComponent<Text>();
            text13.text = "Projectile Speed: 20";
        }
        if (GlobalVarStore.Equipped == "lightning")
        {
            Text text14 = health.GetComponent<Text>();
            text14.text = "Max Health: 200";

            Text text15 = attackDamage.GetComponent<Text>();
            text15.text = "Attack Damage: 20";

            Text text16 = attackSpeed.GetComponent<Text>();
            text16.text = "Attack Speed: 2x";

            Text text17 = projSpeed.GetComponent<Text>();
            text17.text = "Projectile Speed: 20";
        }
    }

    void Update()
    {
        string coins = GlobalVarStore.Coins.ToString();
        text1.text = "Souls: " + coins;
    }

}
