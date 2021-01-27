using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Components
{
    public class RawImageDownloadingComponent : MonoBehaviour
    {
        [SerializeField]
        private string _imageURL;

        private RawImage _rawImage;

        private void Awake()
        {
            _rawImage = this.gameObject.GetComponent<RawImage>();
        }
        private void Start()
        {
            StartCoroutine(DownloadImage(_imageURL, _rawImage));
        }

        private IEnumerator DownloadImage(string imageURL, RawImage rawImage)
        {
            var request = UnityWebRequestTexture.GetTexture(imageURL);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
        }
    }
}
