using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMessages : MonoBehaviour
{
    public GameObject playerChat;
    public GameObject enemyChat;

    public TMP_Text playerText;
    public TMP_Text enemyText;
    
    private bool halfHPReached = false;
    private bool battleEnded = false;

    public AudioSource messageSound;
    
    void Start()
    {
        StartCoroutine(StartChat());
    }

    // Update is called once per frame
    IEnumerator StartChat()
    {
        enemyChat.SetActive(true);
        enemyText.text = GetEnemyMessage();
        PlayMessageSound();
        yield return new WaitForSeconds(3f); 
        enemyChat.SetActive(false);
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); 
        playerChat.SetActive(true);
        playerText.text = GetPlayerMessage();
        PlayMessageSound();
        yield return new WaitForSeconds(3f); 
        playerChat.SetActive(false);
    }

    string GetEnemyMessage()
    {
        string[] enemyMessages = {
            "I will destroy you!",
            "You're no match for me!",
            "Prepare to be defeated!",
            "You'll regret challenging me!"
        };

        if (halfHPReached)
        {
            string[] halfHPEnemyMessages = {
                "You think you've won? You're mistaken!",
                "I'm just getting started!",
                "You'll pay dearly for this!",
                "This battle is far from over!"
            };
            return halfHPEnemyMessages[Random.Range(0, halfHPEnemyMessages.Length)];
        }
        else
        {
            return enemyMessages[Random.Range(0, enemyMessages.Length)];
        }
    }

    string GetPlayerMessage()
    {
        string[] playerMessages = {
            "I think you won't!",
            "Bring it on!",
            "You'll be the one regretting this!",
            "We'll see about that!"
        };

        if (halfHPReached)
        {
            string[] halfHPPlayerMessages = {
                "You're tougher than I thought!",
                "This isn't over yet!",
                "I won't go down without a fight!",
                "You're in for a surprise!"
            };
            return halfHPPlayerMessages[Random.Range(0, halfHPPlayerMessages.Length)];
        }
        else
        {
            return playerMessages[Random.Range(0, playerMessages.Length)];
        }
    }

    string GetEnemyReply()
    {
        string[] enemyReplies = {
            "Haha! That's just the beginning!",
            "You're not getting away that easily!",
            "You'll regret crossing me!",
            "I'll make you pay for that!"
        };
        return enemyReplies[Random.Range(0, enemyReplies.Length)];
    }

    string GetPlayerReply()
    {
        string[] playerReplies = {
            "I'm not done yet!",
            "You'll see what I'm capable of!",
            "This fight is far from over!",
            "I'll show you what I'm made of!"
        };
        return playerReplies[Random.Range(0, playerReplies.Length)];
    }
    string GetVictoryMessage()
    {
        string[] victoryMessage = {
            "Victory is mine!",
            "You were no match for me!",
            "I emerged victorious!",
            "I knew I could win!"
        };
        return victoryMessage[Random.Range(0, victoryMessage.Length)];
    }

    void Update()
    {
        if (!halfHPReached)
        {
            if (PlayerHPIsHalf() || EnemyHPIsHalf())
            {
                halfHPReached = true;
                StartCoroutine(HalfHPChat());
            }
        }
        
        if (!battleEnded)
        {
            if (PlayerHPIsZero())
            {
                battleEnded = true;
                StartCoroutine(EndBattle(true));
            }
        }
    }

    IEnumerator HalfHPChat()
    {
        yield return new WaitForSeconds(0.5f); 
        if (PlayerHPIsHalf())
        {
            playerChat.SetActive(true);
            playerText.text = GetPlayerMessage();
            PlayMessageSound();
            yield return new WaitForSeconds(3f); 
            playerChat.SetActive(false);

            enemyChat.SetActive(true);
            enemyText.text = GetEnemyReply();
            PlayMessageSound();
            yield return new WaitForSeconds(3f); 
            enemyChat.SetActive(false);
        }
        else if (EnemyHPIsHalf())
        {
            enemyChat.SetActive(true);
            enemyText.text = GetEnemyMessage();
            PlayMessageSound();
            yield return new WaitForSeconds(3f); 
            enemyChat.SetActive(false);

            playerChat.SetActive(true);
            playerText.text = GetPlayerReply();
            PlayMessageSound();
            yield return new WaitForSeconds(3f); 
            playerChat.SetActive(false);
        }
    }
    
    IEnumerator EndBattle(bool playerWon)
    {
        yield return new WaitForSeconds(0.5f);
        if (playerWon)
        {
            playerChat.SetActive(true);
            playerText.text = GetVictoryMessage();
            PlayMessageSound();
            yield return new WaitForSeconds(2f);
            playerChat.SetActive(false);
        }
        else
        {
            enemyChat.SetActive(true);
            enemyText.text = GetVictoryMessage();
            PlayMessageSound();
            yield return new WaitForSeconds(2f);
            enemyChat.SetActive(false);
        }
    }


    bool PlayerHPIsHalf()
    {
        return PlayerHealth.staticHP <= (PlayerHealth.maxHP / 2);
    }

    bool EnemyHPIsHalf()
    {
        return EnemyHealth.staticHP <= (EnemyHealth.maxHP / 2);
    }
    bool PlayerHPIsZero()
    {
        return PlayerHealth.staticHP <= 0;
    }
    bool EnemyHPIsZero()
    {
        return EnemyHealth.staticHP <= 0;
    }
    void PlayMessageSound()
    {
        messageSound.Play();
    }
}

