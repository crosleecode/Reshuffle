using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int rank;
    public bool isRed;
    public TMP_Text rankText;
    public SpriteRenderer sr;

    public bool isPlayer;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        UpdateCard();
    }

    public void SetCard(int rank, bool isRed)
    {
        this.rank = rank;
        this.isRed = isRed;
        UpdateCard();
    }

    private void UpdateCard()
    {
        rankText.text = GetRankString();
        
        if(isRed)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.black;
        }
    }

    private string GetRankString()
    {
        return rank switch
        {
            1 => "A",
            13 => "K",
            12 => "Q",
            11 => "J",
            _ => rank.ToString(),
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Card o = collision.GetComponent<Card>();

        if (o != null)
        {
            if (isNext(o))
            {

                SetCard(o.rank, !isRed);

                GameManager.instance.UpdatePlayerCard(o.rank, !isRed);

                Destroy(o.gameObject);

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
               

                gm.points++;
                gm.pointsText.text = "Points: " + gm.points;

                if(gm.points >= gm.pointsToWin)
                {
                    gm.EndGame(true);
                }

                Debug.Log("Gottem");
            }
            else
            {
                if (isPlayer)
                {
                    gm.EndGame(false);
                    Debug.Log("Game Over, Man");
                }
                
            }
        }
    }

    private bool isNext(Card o)
    {
        if (isPlayer)
        {
            o.GetComponent<Collider2D>().enabled = false;  
            int tempRank = this.rank;

            if (this.rank == 13)
            {
                tempRank = 0;
            }
            return o.rank == tempRank + 1 && o.isRed != this.isRed && isPlayer;
        }
        return false;
    }

}
