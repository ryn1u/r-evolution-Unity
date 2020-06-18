using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class SequencerWait : MonoBehaviour
{
    private List<float> timers;

    public UnityEvent timerCompleted;
    public void StartTimer(float duration)
    {
        timers.Add(duration);
    }
    public void Awake()
    {
        timers = new List<float>();
    }
    public void StartTimer(float duration, out int index)
    {
        timers.Add(duration);
        index =  timers.Count - 1;
    }
    public float GetTimeLeft(int index)
    {
        return timers[index];
    }

    private void Update()
    {
        for(int i = timers.Count - 1; i >= 0; i--)
        {
            timers[i] -= Time.deltaTime;
            if(timers[i] <= 0)
            {
                timerCompleted.Invoke();
                timers.RemoveAt(i);
            }
        }
    }
}
