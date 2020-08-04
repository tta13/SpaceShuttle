using UnityEngine;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public static class BrightnessUtility
{
    /// <summary>
    /// Returns the current screen brightness on Android or iOS devices. 
    /// </summary>
    /// <returns></returns>
    public static float GetScreenBrightness()
    {
        var brightness = 1f;

#if UNITY_EDITOR
        brightness = 0.8f;
#elif UNITY_ANDROID
        using (var actClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
            var context = actClass.GetStatic<AndroidJavaObject> ("currentActivity");
            AndroidJavaClass systemSettings = new AndroidJavaClass ("android.provider.Settings$System");

            var brightnessVal = systemSettings.CallStatic<int> ("getInt", context.Call<AndroidJavaObject> ("getContentResolver"), "screen_brightness");

            brightness = (float) brightnessVal / 255f;
        }
#else
        brightness = Screen.brightness;
#endif

        return brightness;
    }

    /// <summary>
    /// Sets the screen brightness of mobile devices to the specified value.
    /// </summary>
    /// <param name="value">
    /// Desired screen brightness from 0f to 1f
    /// </param>
    public static void SetScreenBrightness(float value)
    {
        if (value < 0f) value = 0f;
        else if (value > 1f) value = 1f;
#if UNITY_EDITOR
#elif UNITY_ANDROID
        using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var context = actClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass systemSettings = new AndroidJavaClass("android.provider.Settings$System");

            if (!systemSettings.CallStatic<bool>("canWrite", context))
            {
                var settings = new AndroidJavaClass("android.provider.Settings");
                var uri = new AndroidJavaClass("android.net.Uri");

                var intent = new AndroidJavaObject("android.content.Intent", settings.GetStatic<string>("ACTION_MANAGE_WRITE_SETTINGS"));
                intent.Call<AndroidJavaObject>("setData", uri.CallStatic<AndroidJavaObject>("parse", "package:" + context.Call<string>("getPackageName")));

                context.Call("startActivityForResult", intent, 1);
            } else {
                var mode = systemSettings.CallStatic<int>("getInt", context.Call<AndroidJavaObject>("getContentResolver"), "screen_brightness_mode");

                if (mode == 1) {
                    systemSettings.CallStatic<bool>("putInt", context.Call<AndroidJavaObject>("getContentResolver"), "screen_brightness_mode", 0);
                }

                int newValue = (int)(value * 255f);

                systemSettings.CallStatic<bool>("putInt", context.Call<AndroidJavaObject>("getContentResolver"), "screen_brightness", newValue);
            }
        }
#else
        Screen.brightness = value;
#endif
    }
}
