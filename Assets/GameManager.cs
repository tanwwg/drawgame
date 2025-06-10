using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CardList topCards;
    public CardList bottomCards;

    public CardPlacement topCardPlacement;
    public CardPlacement bottomCardPlacement;
    public UnityEvent startGame;
    
    void Start()
    {
        var top = ShuffleUtility.Shuffle(topCards.cards.ToList()).First();
        var bottom = ShuffleUtility.Shuffle(bottomCards.cards.ToList()).First();
        
        topCardPlacement.Setup(top);
        bottomCardPlacement.Setup(bottom);
        startGame.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

public static class ShuffleUtility
{
    public static List<T> Shuffle<T>(List<T> list)
    {
        return list.OrderBy(_ => UnityEngine.Random.value).ToList();
    }
}