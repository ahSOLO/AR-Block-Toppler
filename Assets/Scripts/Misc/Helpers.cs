using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Helpers
{
    public static bool IsPointerOverUIObject(Vector2 touchPosition)
    {
        var eventData = new PointerEventData(EventSystem.current) { position = touchPosition };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    public static float NormalizeAngle(float a)
    {
        if (a > 180f) return a - 360f;
        else if (a < -180f) return a + 360f;
        return a;
    }
}
