using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Current;

    [SerializeField]
    SerializableInterface<IWindow>[] windowList;

    private void Awake()
    {
        Current = this;
    }

    public void ShowWindow(EWindowType type)
    {
        foreach (SerializableInterface<IWindow> windowSerializableInterface in windowList)
        {
            IWindow window = windowSerializableInterface.Value;
            bool isVisible = (type == window.WindowType);
            window.Show(isVisible);
        }
    }
}
