using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{

    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise() {
        // remove anything won't couse trouble;
        for (int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].onSignalRaise();
        }
    }

    public void RegisterListener(SignalListener listener) {
        listeners.Add(listener);
    }

    public void DegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
