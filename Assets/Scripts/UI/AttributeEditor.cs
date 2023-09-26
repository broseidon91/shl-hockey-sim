using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributeEditor : MonoBehaviour
{
    public TMP_Text TitleText;
    public TMP_Text CostText;
    public TMP_Text AttributeValueText;


    public Attribute attribute;
    private int _value;
    public int AttributeValue
    {
        set
        {
            if (value > attribute.Costs.Length)
            {
                _value = attribute.Costs.Length;
            }
            else if (value < 0)
            {
                _value = 0;
            }
            else
                _value = value;

            AttributeValueText.text = _value.ToString();
            if (_value > attribute.Costs.Length - 1)
                CostText.text = "--";
            else
                CostText.text = attribute.Costs[_value].ToString();
        }
        get { return _value; }
    }

    public void Init(Attribute attribute)
    {

        this.attribute = attribute;
        TitleText.text = attribute.Name;
        AttributeValue = 5;
        AttributeValueText.text = AttributeValue.ToString();
        CostText.text = attribute.Costs[AttributeValue].ToString();

    }

    public void Increase()
    {
        AttributeValue++;
    }

    public void Decrease()
    {
        AttributeValue--;
    }

}
