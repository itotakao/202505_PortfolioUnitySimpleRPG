using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MainMenuから表示するWindowを判別するためのインターフェース
/// </summary>
public interface IWindow
{
    public EWindowType WindowType { get; }
    public void Show(bool isVisible);
}

public class WindowBase<T> : MonoBehaviour, IWindow
{
    private T window;

    public EWindowType WindowType => _windowType;
    [SerializeField]
    private EWindowType _windowType;

    public virtual void Show(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}
