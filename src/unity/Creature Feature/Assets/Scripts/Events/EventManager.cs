using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager _current;

    private Dictionary<string, UnityEvent> _events = new Dictionary<string, UnityEvent>(StringComparer.OrdinalIgnoreCase);

    public static EventManager Current
    {
        get
        {
            if (_current == null)
            {
                _current = FindObjectOfType<EventManager>();
                if (_current == null)
                {
                    var go = new GameObject("~~~ EVENT MANAGER ~~~");
                    _current = go.AddComponent<EventManager>();
                }
            }

            return _current;
        }
    }

    public void CreateEvent<TEvent>() where TEvent : UnityEvent
    {
        _events[typeof(TEvent).Name] = (TEvent)Activator.CreateInstance(typeof(TEvent));
    }

    public void ListenForEvent<TEvent>(Action action) where TEvent : UnityEvent
    {
        UnityEvent unityEvent;
        if (_events.TryGetValue(typeof(TEvent).Name, out unityEvent))
        {
            unityEvent.AddListener(new UnityAction(action));
        }
    }

    public void Post<TEvent>() where TEvent : UnityEvent
    {
        UnityEvent unityEvent;
        if (_events.TryGetValue(typeof(TEvent).Name, out unityEvent))
        {
            unityEvent.Invoke();
        }
    }
}
