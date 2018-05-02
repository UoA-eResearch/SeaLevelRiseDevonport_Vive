﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;


public class Slider : MonoBehaviour
{

    public LinearMapping linearMapping;
    private float currentLinearMapping = float.NaN;
    private int sliderValue;
    private GameObject sliderCanvas;
    private Text sliderText;

    //-------------------------------------------------
    void Awake()
    {
        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }

        sliderCanvas = GameObject.Find("pHCanvas");
        sliderText = sliderCanvas.GetComponentInChildren<Text>();
    }


    //-------------------------------------------------
    void Update()
    {
        if (currentLinearMapping != linearMapping.value)
        {
            currentLinearMapping = linearMapping.value;
            Debug.Log("val: " + currentLinearMapping);

            var mappedToDecade = (currentLinearMapping - 0.0f) / (1.0f - 0.0f) * (2150.0f - 2000.0f) + 2000.0f;
            sliderValue = Mathf.RoundToInt(mappedToDecade);
            //sliderValue = Mathf.RoundToInt(mappedToDecade / 10) * 10;

            Debug.Log("Year: " + sliderValue);
            switch (sliderValue)
            {

                case 9:
                    sliderText.text = "Value: high";
                    break;

                case 8:
                case 7:
                case 6:
                case 5:
                case 4:
                    sliderText.text = "Value: " + sliderValue;
                    break;

                case 3:
                    sliderText.text = "Value: low";
                    break;
                default:
                    break;
            }
        }
    }

    public int GetPhValue()
    {
        return sliderValue;
    }
    public string GetPhValueStr()
    {
        return sliderText.text;
    }
}
