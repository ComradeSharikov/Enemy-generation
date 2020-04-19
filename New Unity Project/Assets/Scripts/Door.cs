using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public bool IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _reached?.AddListener(value);
        remove => _reached?.RemoveListener(value);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (IsReached)
            {
                IsReached = false;
            }
            else
            {
                IsReached = true;
            }

            _reached.Invoke();
        }
    }
}
