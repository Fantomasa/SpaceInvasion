using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private enum State { Starting, OnGoing, Finished }

    [System.Serializable]
    public class Wave
    {
        public GameObject spawner;
        public float waveDuration;
    }

    public Wave[] waves;
    private int currentWaveIdx;

    private float waveCountdown = 0f;
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Starting;
        currentWaveIdx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCountdown <= 0)
        {
            if (state == State.Starting)
            {
                SpawnWave(currentWaveIdx);
            }
            else if (state == State.OnGoing)
            {
                state = State.Finished;
                currentWaveIdx++;

                SpawnWave(currentWaveIdx);
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private void SpawnWave(int waveIdx)
    {
        if (waveIdx >= waves.Length)
        {
            return;
        }

        Wave currentWave = waves[waveIdx];

        GameObject go = Instantiate(waves[waveIdx].spawner);
        Destroy(go, currentWave.waveDuration);

        state = State.OnGoing;
        waveCountdown = waves[waveIdx].waveDuration;
    }
}
