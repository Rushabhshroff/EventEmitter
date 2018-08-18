﻿using System.Collections;
using System.Collections.Generic;
using System;
public class EventEmitter<L,T>
{
    private Dictionary<L, List<Action<T>>> handlers = new Dictionary<L, List<Action<T>>>();
    public EventEmitter()
    {
        handlers = new Dictionary<L, List<Action<T>>>();
    }
    public void On(L ev, Action<T> callback)
    {
        if (!handlers.ContainsKey(ev))
        {
            handlers[ev] = new List<Action<T>>();
        }
        handlers[ev].Add(callback);
    }
    public void Off(L ev, Action<T> callback)
    {
        if (!handlers.ContainsKey(ev))
        {
            return;
        }

        List<Action<T>> l = handlers[ev];
        if (!l.Contains(callback))
        {
            return;
        }

        l.Remove(callback);
        if (l.Count == 0)
        {
            handlers.Remove(ev);
        }
    }
    public void emit(L name, T data)
    {
        if (!handlers.ContainsKey(name)) { return; }
        foreach (Action<T> handler in this.handlers[name])
        {
            try
            {
                handler(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
