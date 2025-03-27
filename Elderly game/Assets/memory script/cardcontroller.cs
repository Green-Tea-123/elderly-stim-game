using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardcontroller : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] card cardprefab;
    [SerializeField] Transform gridtransform;
    [SerializeField] TextMeshProUGUI movetext;
    [SerializeField] TextMeshProUGUI finishtext;
    public int matchset = 0;
    public int movecount = 0;

    private List<Sprite> spritepairs;

    card firstselected;
    card secondselected;


    private void Start()
    {
        finishtext.enabled = false;
        PrepareSprites();
        CreateCards();
    }

    private void PrepareSprites()
    {
        spritepairs = new List<Sprite>();
        for(int i = 0; i <sprites.Length; i++)
        {
            spritepairs.Add(sprites[i]);
            spritepairs.Add(sprites[i]);
        }
        ShuffleSprites(spritepairs);
    }

    void CreateCards()
    {
        for(int i = 0; i<spritepairs.Count; i++)
        {
            card card = Instantiate(cardprefab, gridtransform);
            card.SetIconSprite(spritepairs[i]);
            card.controller = this;
        }
    }


    public void SetSelected(card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstselected == null)
            {
                firstselected = card;
                return;
            }

            if(secondselected == null)
            {
                secondselected = card;
                StartCoroutine(CheckMatching(firstselected, secondselected));
                firstselected = null;
                secondselected = null;
            }
        }
    }

    IEnumerator CheckMatching(card a, card b)
    {
        yield return new WaitForSeconds(0.3f);
        if(a.iconsprite == b.iconsprite)
        {
            matchset++;
            movecount++;
            movetext.text = "Moves Taken: " + movecount.ToString();
            if (matchset == spritepairs.Count / 2)
            {
                finishtext.enabled = true;
            }
        }
        else
        {
            a.Hide();
            b.Hide();
            movecount++;
            movetext.text = "Moves Taken: " + movecount.ToString();
        }
    }



    void ShuffleSprites(List<Sprite> spritelist)
    {
        for(int i = spritelist.Count - 1; i>0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Sprite temp = spritelist[i];
            spritelist[i] = spritelist[randomIndex];
            spritelist[randomIndex] = temp;
        }
    }
}
