using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}

public class EventManager
{
    private static readonly IDictionary<EventType, UnityAction> dictionary = new Dictionary<EventType, UnityAction>();

    public static void Subscribe(EventType eventType, UnityAction unityAction)
    {
        UnityEvent unityEvent;
        if (dictionary.TryGetValue(eventType, out unityAction))
        {
            //unityEvent.AddListener(unityAction);
        }

        else
        {
            unityEvent = new UnityEvent();
            unityEvent.AddListener(unityAction);
            dictionary.Add(eventType, unityAction);
        }
    }

    public static void UnSubScribe(EventType eventType, UnityAction unityAction)
    {

    }

    public static void Publish(EventType eventType)
    {

    }
}
