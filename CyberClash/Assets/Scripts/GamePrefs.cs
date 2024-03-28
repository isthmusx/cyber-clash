using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePrefs : MonoBehaviour
{
    public Image playerImage;
    public Image enemyImage;
    
    public Sprite playerSprite;
    public Sprite enemySprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.faction == "Security")
        {
            playerSprite = Resources.Load<Sprite>("GamePrefs/Security");
            enemySprite = Resources.Load<Sprite>("GamePrefs/Threat");
        }
        else if (MainMenu.faction == "Threat")
        {
            playerSprite = Resources.Load<Sprite>("GamePrefs/Threat");
            enemySprite = Resources.Load<Sprite>("GamePrefs/Security");
        }

        playerImage.sprite = playerSprite;
        enemyImage.sprite = enemySprite;
    }
}
