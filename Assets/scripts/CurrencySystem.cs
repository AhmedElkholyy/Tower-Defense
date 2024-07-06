using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public int cash = 350;
    public Text cashText;
    public GameObject turretPrefab;
    public Transform[] turretTiles; 
    private bool[] tileOccupied; 
    private int selectedTileIndex = -1;

    void Start()
    {
        tileOccupied = new bool[turretTiles.Length]; 
        UpdateCashText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < turretTiles.Length; i++)
                {
                    if (hit.transform == turretTiles[i])
                    {
                        selectedTileIndex = i;
                        PlaceTurret();
                        break;
                    }
                }
            }
        }
    }

    void PlaceTurret()
    {
        if (cash >= 50 && selectedTileIndex != -1 && !tileOccupied[selectedTileIndex])
        {
            Instantiate(turretPrefab, turretTiles[selectedTileIndex].position, Quaternion.identity);
            cash -= 50;
            tileOccupied[selectedTileIndex] = true; 
            UpdateCashText();
            selectedTileIndex = -1;
        }
    }

    public void EarnCash(int amount)
    {
        cash += amount;
        UpdateCashText();
    }

    void UpdateCashText()
    {
        cashText.text = "Cash: " + cash;
    }
}
