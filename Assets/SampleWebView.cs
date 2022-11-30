/*
 * Copyright (C) 2012 GREE, Inc.
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System.Collections;
using UnityEngine;
#if UNITY_2018_4_OR_NEWER
using UnityEngine.Networking;
#endif
using UnityEngine.UI;
#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine.Android;
#endif

public class SampleWebView : MonoBehaviour
{
    public string Url;
    public Text status;
    WebViewObject webViewObject;


#if !UNITY_EDITOR && UNITY_ANDROID
    bool inRequestingCameraPermission;

    void OnApplicationFocus(bool hasFocus)
    {
        if (inRequestingCameraPermission && hasFocus) {
            inRequestingCameraPermission = false;
        }
    }
#endif


    IEnumerator Start()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            inRequestingCameraPermission = true;
            Permission.RequestUserPermission(Permission.Camera);
        }        
        while (inRequestingCameraPermission) {
            yield return new WaitForSeconds(0.5f);
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            inRequestingCameraPermission = true;
            Permission.RequestUserPermission(Permission.Microphone);
        }        
        while (inRequestingCameraPermission) {
            yield return new WaitForSeconds(0.5f);
        }
#endif
        
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            cb: (msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
                status.text = msg;
                status.GetComponent<Animation>().Play();
            },
            err: (msg) =>
            {
                Debug.Log(string.Format("CallOnError[{0}]", msg));
                status.text = msg;
                status.GetComponent<Animation>().Play();
            },
            httpErr: (msg) =>
            {
                Debug.Log(string.Format("CallOnHttpError[{0}]", msg));
                status.text = msg;
                status.GetComponent<Animation>().Play();
            },
            started: (msg) =>
            {
                Debug.Log(string.Format("CallOnStarted[{0}]", msg));
            },
            hooked: (msg) =>
            {
                Debug.Log(string.Format("CallOnHooked[{0}]", msg));
            },
            ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
#if UNITY_EDITOR_OSX || (!UNITY_ANDROID && !UNITY_WEBPLAYER && !UNITY_WEBGL)
                // NOTE: depending on the situation, you might prefer
                // the 'iframe' approach.
                // cf. https://github.com/gree/unity-webview/issues/189
#if true
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        window.location = 'unity:' + msg;
                      }
                    }
                  }
                ");
#else
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        var iframe = document.createElement('IFRAME');
                        iframe.setAttribute('src', 'unity:' + msg);
                        document.documentElement.appendChild(iframe);
                        iframe.parentNode.removeChild(iframe);
                        iframe = null;
                      }
                    }
                  }
                ");
#endif
#elif UNITY_WEBPLAYER || UNITY_WEBGL
                webViewObject.EvaluateJS(
                    "window.Unity = {" +
                    "   call:function(msg) {" +
                    "       parent.unityWebView.sendMessage('WebViewObject', msg)" +
                    "   }" +
                    "};");
#endif
                webViewObject.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
            }
            //transparent: false,
            //zoom: true,
            //ua: "custom user agent string",
            //// android
            //androidForceDarkMode: 0,  // 0: follow system setting, 1: force dark off, 2: force dark on
            //// ios
            //enableWKWebView: true,
            //wkContentMode: 0,  // 0: recommended, 1: mobile, 2: desktop
            //wkAllowsLinkPreview: true,
            //// editor
            //separated: false
            );
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        // cf. https://github.com/gree/unity-webview/pull/512
        // Added alertDialogEnabled flag to enable/disable alert/confirm/prompt dialogs. by KojiNakamaru · Pull Request #512 · gree/unity-webview
        //webViewObject.SetAlertDialogEnabled(false);

        // cf. https://github.com/gree/unity-webview/pull/728
        //webViewObject.SetCameraAccess(true);
        //webViewObject.SetMicrophoneAccess(true);

        // cf. https://github.com/gree/unity-webview/pull/550
        // introduced SetURLPattern(..., hookPattern). by KojiNakamaru · Pull Request #550 · gree/unity-webview
        //webViewObject.SetURLPattern("", "^https://.*youtube.com", "^https://.*google.com");

        // cf. https://github.com/gree/unity-webview/pull/570
        // Add BASIC authentication feature (Android and iOS with WKWebView only) by takeh1k0 · Pull Request #570 · gree/unity-webview
        //webViewObject.SetBasicAuthInfo("id", "password");

        //webViewObject.SetScrollbarsVisibility(true);
        //(int)(Screen.height * 0.92f)
        webViewObject.SetMargins(0,0,0,0);
        webViewObject.SetTextZoom(100);  // android only. cf. https://stackoverflow.com/questions/21647641/android-webview-set-font-size-system-default/47017410#47017410
        webViewObject.SetVisibility(true);
        webViewObject.SetCameraAccess(true);
        webViewObject.SetMicrophoneAccess(true);


#if !UNITY_WEBPLAYER && !UNITY_WEBGL
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            var exts = new string[]{
                ".jpg",
                ".js",
                ".html"  // should be last
            };
            foreach (var ext in exts) {
                var url = Url.Replace(".html", ext);
                var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
                byte[] result = null;
                if (src.Contains("://")) {  // for Android
#if UNITY_2018_4_OR_NEWER
                    // NOTE: a more complete code that utilizes UnityWebRequest can be found in https://github.com/gree/unity-webview/commit/2a07e82f760a8495aa3a77a23453f384869caba7#diff-4379160fa4c2a287f414c07eb10ee36d
                    var unityWebRequest = UnityWebRequest.Get(src);
                    yield return unityWebRequest.SendWebRequest();
                    result = unityWebRequest.downloadHandler.data;
#else
                    var www = new WWW(src);
                    yield return www;
                    result = www.bytes;
#endif
                } else {
                    result = System.IO.File.ReadAllBytes(src);
                }
                System.IO.File.WriteAllBytes(dst, result);
                if (ext == ".html") {
                    webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
#endif
        yield break;
    }

    //void OnGUI()
    //{
    //    In both X and Y directions the screen becomes addressible as 0.0f to 1.0f.That's how I do it when I use the old OnGUI() system.
    //    Upper left would be(0,0) and lower right would be(1, 1) regardless of screen resolution.
    //    Rect MR(float x, float y, float w, float h)
    //    {
    //        return new Rect(Screen.width * x, Screen.height * y, Screen.width * w, Screen.height * h);
    //    }

    //    GUI.backgroundColor = Color.white;

    //    if (GUI.Button(MR(0f, 0.93f, 0.25f, 0.07f), _backButtonTexture))
    //    {
    //        webViewObject.GoBack();
    //    }
    //    if (GUI.Button(MR(0.25f, 0.93f, 0.25f, 0.07f), _nextButtonTexture))
    //    {
    //        webViewObject.GoForward();
    //    }
    //    if (GUI.Button(MR(0.50f, 0.93f, 0.25f, 0.07f), _reloadButtonTexture))
    //    {
    //        webViewObject.Reload();
    //    }
    //    if (GUI.Button(MR(0.75f, 0.93f, 0.25f, 0.07f), _settingButtonTexture))
    //    {
    //        webViewObject.ClearCookies();
    //    }

    //    var x = 0;
    //    Rect rect = new Rect(x, 80, 80, 80);


    //    GUI.enabled = webViewObject.CanGoBack();
    //    if (GUI.Button(rect, "<"))
    //    {
    //        webViewObject.GoBack();
    //    }
    //    GUI.enabled = true;
    //    x += 40;

    //    GUI.enabled = webViewObject.CanGoForward();
    //    if (GUI.Button(rect, ">"))
    //    {
    //        webViewObject.GoForward();
    //    }
    //    GUI.enabled = true;
    //    x += 50;

    //    if (GUI.Button(rect, "r"))
    //    {
    //        webViewObject.Reload();
    //    }
    //    x += 50;

    //    GUI.TextField(new Rect(x, (Screen.height - 25), 180, 40), "" + webViewObject.Progress());
    //    x += 190;

    //    if (GUI.Button(rect, "*"))
    //    {
    //        var g = GameObject.Find("WebViewObject");
    //        if (g != null)
    //        {
    //            Destroy(g);
    //        }
    //        else
    //        {
    //            StartCoroutine(Start());
    //        }
    //    }
    //    x += 90;

    //    if (GUI.Button(rect, "c"))
    //    {
    //        Debug.Log(webViewObject.GetCookies(Url));
    //    }
    //    x += 90;

    //    if (GUI.Button(new Rect(x, 10, 80, 80), "x"))
    //    {
    //        webViewObject.ClearCookies();
    //    }
    //    x += 90;

    //    if (GUI.Button(new Rect(x, 10, 80, 80), "D"))
    //    {
    //        webViewObject.SetInteractionEnabled(false);
    //    }
    //    x += 90;

    //    if (GUI.Button(new Rect(x, 10, 80, 80), "E"))
    //    {
    //        webViewObject.SetInteractionEnabled(true);
    //    }
    //    x += 90;
    //}

    public void GotoPreviewPage()
    {
        webViewObject.GoBack();
    }
    public void GotoNextPage()
    {
        webViewObject.GoForward();
    }
    public void ReloadPage()
    {
        webViewObject.Reload();
    }
    public void SetttingMenu()
    {
        webViewObject.ClearCache(true);
    }
}
