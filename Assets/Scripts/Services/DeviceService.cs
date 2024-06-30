using UnityEngine;

public class DeviceService : MonoBehaviour
{
    public bool IsDesktop()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) { return true; }

        return false;
    }
    
    public bool IsHandheld()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) { return true; }

        return false;
    }
}
