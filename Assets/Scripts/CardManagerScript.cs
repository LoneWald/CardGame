using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Card 
{
    public string Name;
    public Sprite Logo;
    public int Attack, Defense;

    public Card(string name, string logoPath, int attack, int defense) 
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}
public class CardManagerScript : MonoBehaviour
{

    private void Awake()
    {
        CardManager.AllCards.Add(new Card("Помыкан", "Sprites/Cards/Pomikan", 1, 2));
        CardManager.AllCards.Add(new Card("Димончес", "Sprites/Cards/Dimonches", 2, 1));
        CardManager.AllCards.Add(new Card("Baby", "Sprites/Cards/BB", 3, 3));
        CardManager.AllCards.Add(new Card("Богдашенька", "Sprites/Cards/Bogdashenka", 2, 3));
        CardManager.AllCards.Add(new Card("ВладиSlave", "Sprites/Cards/Vladislave", 3, 2));
    }
}
