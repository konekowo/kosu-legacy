#if ENABLE_UNITYWEBREQUEST && (!UNITY_2019_1_OR_NEWER || UNITASK_WEBREQUEST_SUPPORT)

using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks
{
    public class UnityWebRequestException : Exception
    {
        public UnityWebRequest UnityWebRequest { get; }
#if UNITY_2020_2_OR_NEWER
        public UnityWebRequest.Result Result { get; }
#else
        public bool IsNetworkError { get; }
        public bool IsHttpError { get; }
#endif
        public string Error { get; }
        public string Text { get; }
        public long ResponseCode { get; }
        public Dictionary<string, string> ResponseHeaders { get; }

        private string msg;

        public UnityWebRequestException(UnityWebRequest unityWebRequest)
        {
            UnityWebRequest = unityWebRequest;
#if UNITY_2020_2_OR_NEWER
            Result = unityWebRequest.result;
#else
            this.IsNetworkError = unityWebRequest.isNetworkError;
            this.IsHttpError = unityWebRequest.isHttpError;
#endif
            Error = unityWebRequest.error;
            ResponseCode = unityWebRequest.responseCode;
            if (UnityWebRequest.downloadHandler != null)
                if (unityWebRequest.downloadHandler is DownloadHandlerBuffer dhb)
                    Text = dhb.text;
            ResponseHeaders = unityWebRequest.GetResponseHeaders();
        }

        public override string Message
        {
            get
            {
                if (msg == null)
                {
                    if (!string.IsNullOrWhiteSpace(Text))
                        msg = Error + Environment.NewLine + Text;
                    else
                        msg = Error;
                }

                return msg;
            }
        }
    }
}

#endif