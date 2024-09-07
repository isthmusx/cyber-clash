using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePrefs : MonoBehaviour
{
    public static GamePrefs Instance;
    public Image playerImage;
    public Image enemyImage;

    public Image playerIconBg;
    public Image enemyIconBg;
    
    public static Sprite playerSprite;
    public static Sprite enemySprite;

    public Sprite playerIconBgSprite;
    public Sprite enemyIconBgSprite;
    
    private const string PlayerIconKey = "PlayerIcon";
    void Start()
    {
        LoadIcons();
        
        if (MainMenu.faction == "Security" || MainMenu.faction == "Story1Deck" ||  MainMenu.faction == "Story2Deck" || MainMenu.faction == "Story3Deck" ||  MainMenu.faction == "Story4Deck" ||  MainMenu.faction == "Story5Deck")
        {
            playerIconBgSprite = Resources.Load<Sprite>("GamePrefs/IconBGSecurity");
            enemyIconBgSprite = Resources.Load<Sprite>("GamePrefs/IconBGThreat");
        }
        else if (MainMenu.faction == "Threat")
        {
            playerIconBgSprite = Resources.Load<Sprite>("GamePrefs/IconBGThreat");
            enemyIconBgSprite = Resources.Load<Sprite>("GamePrefs/IconBGSecurity");
        }

        playerIconBg.sprite = playerIconBgSprite;
        enemyIconBg.sprite = enemyIconBgSprite;
    }

    // Update is called once per frame
    void Awake()
    {
        Instance = this;
    }

    public void ChangeIcon(string icon)
    {
        PlayerPrefs.SetString(PlayerIconKey, icon);

    }


    
    private void LoadIcons()
    {
        Sprite defaultEnemyIcon = Resources.Load<Sprite>("GamePrefs/Threat");
        enemyImage.sprite = defaultEnemyIcon;
        
        if (PlayerPrefs.HasKey(PlayerIconKey))
        {
            string playerIconName = PlayerPrefs.GetString(PlayerIconKey);
            string path = "GamePrefs/" + playerIconName;
            playerImage.sprite = Resources.Load<Sprite>(path);
            Debug.LogWarning("Player icon loaded from PlayerPrefs: " + playerIconName);
            
            
        }
        else
        {
            Sprite defaultPlayerIcon = Resources.Load<Sprite>("GamePrefs/Security");

            if (defaultPlayerIcon != null)
            {
                playerImage.sprite = defaultPlayerIcon;
                
            }
            else
            {
                Debug.LogWarning("Default icons not found");
            }
        }
    }


}
