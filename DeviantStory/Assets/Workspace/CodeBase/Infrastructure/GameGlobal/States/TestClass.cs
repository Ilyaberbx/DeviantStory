using System.IO;
using System.Net;
using UnityEngine;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class TestClass : MonoBehaviour
    {
        public float MyFloat = 32;
        
        private void GoogleApiRequest()
        {
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=Disneyland&destination=Universal+Studios+Hollywood&key=AIzaSyAJgBs8LYok3rt15rZUg4aUxYIAYyFzNcw";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);

            var result = reader.ReadToEnd();
            
            response.Close();
            
            Debug.Log(result);
        }
    }
}