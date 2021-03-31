using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives;

    public static int Rounds;

    private void Start()
    {
        startLives = StageLevelModifier.modified_lives;
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}
