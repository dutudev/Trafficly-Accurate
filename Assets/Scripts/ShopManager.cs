using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public car[] cars;
    public int currentIndex = 0;
    public TMP_Text carName, buyText;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText()
    {
        carName.text = cars[currentIndex].name;
        image.sprite = cars[currentIndex].image;

    }
}
[System.Serializable]
public class car
{
    public string name;
    public int cost;
    public Sprite image;
}