using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera camera;
    public TMP_Text itemPickText;
    public TMP_Text[] inventoryTexts; // Pole pre TMP texty v UI
    private List<string> inventory = new List<string>(); // Zoznam nazvov vyzdvihnutych objektov

    void Update()
    {
        InteractionMethod();
    }
    public void InteractionMethod()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 2.3f))
            {
                string itemName = hit.collider.gameObject.name;
                if (itemName == "Book")
                {
                    AddToInventory(itemName);
                    Destroy(hit.collider.gameObject);
                    ShowItemPickedText("Book");
                    Destroy(hit.collider.gameObject);
                }
                if (itemName == "Ball")
                {
                    AddToInventory(itemName);
                    Destroy(hit.collider.gameObject);
                    ShowItemPickedText("Ball");
                    Destroy(hit.collider.gameObject);
                }
                if (itemName == "Ruler")
                {
                    AddToInventory(itemName);
                    Destroy(hit.collider.gameObject);
                    ShowItemPickedText("Ruler");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    void ShowItemPickedText(string itemName)
    {
        itemPickText.text = "Picked up " + itemName;
        StartCoroutine(FadeText(itemPickText));
    }
    IEnumerator FadeText(TMP_Text text)
    {
        text.gameObject.SetActive(true);
        text.canvasRenderer.SetAlpha(0.0f);

        // Fade in
        text.CrossFadeAlpha(1.0f, 1.0f, false);
        yield return new WaitForSeconds(1.0f);

        // Stay visible for 1 second
        yield return new WaitForSeconds(1.0f);

        // Fade out
        text.CrossFadeAlpha(0.0f, 1.0f, false);
        yield return new WaitForSeconds(1.0f);

        text.gameObject.SetActive(false);
    }
    void AddToInventory(string itemName)
    {
        if (inventory.Count < inventoryTexts.Length) // Ak este mame miesto v inventari
        {
            inventory.Add(itemName);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryTexts.Length; i++)
        {
            if (i < inventory.Count)
            {
                inventoryTexts[i].text = inventory[i]; // Nastavime nazov objektu do UI
            }
            else
            {
                inventoryTexts[i].text = ""; // Ak nie je dostatok objektov, zostane prazdne
            }
        }
    }
}
