using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public delegate void EventReceiver(params object[] parameterContainer);


    static Dictionary<EnumNotify.Notifications, EventReceiver> _dictionaryEvents;
   

    public static void Subscribe(EnumNotify.Notifications eventype, EventReceiver listener)
    {
        if (_dictionaryEvents == null)
        {
            _dictionaryEvents = new Dictionary<EnumNotify.Notifications, EventReceiver>();
        }
        if(!_dictionaryEvents.ContainsKey(eventype))
        {
            _dictionaryEvents.Add(eventype, null);
        }
        _dictionaryEvents[eventype] += listener;
    }
    public static void Unsuscribe(EnumNotify.Notifications eventype, EventReceiver listener)
    {
        if (_dictionaryEvents != null)
        {
            if(_dictionaryEvents.ContainsKey(eventype))
            {
                _dictionaryEvents[eventype] -= listener;
            }
        }
    }
    public static void TriggerEvents(EnumNotify.Notifications eventype)
    {
        TriggerEvents(eventype, null);
    }

    public static void TriggerEvents(EnumNotify.Notifications eventype, params object[] parameters)
    {
        if(_dictionaryEvents == null)
        {
            return;
        }
        if(_dictionaryEvents.ContainsKey(eventype))
        {
            if(_dictionaryEvents[eventype] !=null)
            {
                _dictionaryEvents[eventype](parameters);
            }
        }
    }



}
