using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gui : MonoBehaviour
{
    public Texture2D handTexture;
    public Texture2D circleTexture;
    public float handScale = 0.2f;
    public float circleScale = 0.2f;
    public TMP_Text messageText;

    private void OnGUI()
    {
        // Check if we are currently pointing at an object
        RaycastHit hit;

        Vector3 raycastStartPos = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;

        bool isHandImageActive = false;

        if (Physics.Raycast(raycastStartPos, Camera.main.transform.forward, out hit, 1.8f))
        {
            // Calculate the screen position of the hit point
            Vector3 screenPos = Camera.main.WorldToScreenPoint(hit.point);

            if (hit.collider.name == "Ball" ||
                hit.collider.name == "Book" ||
                hit.collider.name == "Ruler")
                
            {
                isHandImageActive = true;
                GUI.DrawTexture(new Rect(screenPos.x - (handTexture.width * handScale / 2),
                                         Screen.height - screenPos.y - (handTexture.height * handScale / 2),
                                         handTexture.width * handScale,
                                         handTexture.height * handScale),
                                handTexture);
            }
        }

        if (!isHandImageActive)
        {
            // Calculate the screen position of the forward point
            Vector3 screenPos = Camera.main.WorldToScreenPoint(Camera.main.transform.position + Camera.main.transform.forward * 2f);

            GUI.DrawTexture(new Rect(screenPos.x - (circleTexture.width * circleScale / 2),
                                      Screen.height - screenPos.y - (circleTexture.height * circleScale / 2),
                                      circleTexture.width * circleScale,
                                      circleTexture.height * circleScale),
                             circleTexture);
        }
    }
}
