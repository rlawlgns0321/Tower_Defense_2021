using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;
    

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    private float fadecountdown = 0f;

    public Text waveCountdownText;
    public Text waveIndicatorText;
    private Animator WaveIndicatorAnim;
    private int i = 0;

    private int waveIndex = 1;

    private void Start()
    {
        waveIndicatorText.enabled = false;
        WaveIndicatorAnim = waveIndicatorText.GetComponent<Animator>();
        WaveIndicatorAnim.enabled = false;
    }

    void Update()
    {
        if (countdown <= 0f && PlayerStats.Rounds < StageLevelModifier.modified_waveNumber)
        {          
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            Debug.Log("Now round : " + PlayerStats.Rounds + " Goal is " + StageLevelModifier.modified_waveNumber);
            waveIndicatorText.text = "Wave " + waveIndex + " Started!";
            waveIndicatorText.enabled = true;
            WaveIndicatorAnim.enabled = true;
            fadecountdown = 0;
        }

        countdown -= Time.deltaTime;
        fadecountdown += Time.deltaTime;
        if (waveIndicatorText.enabled == true && fadecountdown > 3)
        {
            waveIndicatorText.enabled = false;
            WaveIndicatorAnim.enabled = false;
        }
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex ; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;    
    }

    void SpawnEnemy()
    {
        
        Transform enemyClone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyClone.name = "enemy" + i;
        i++;
    }
}
