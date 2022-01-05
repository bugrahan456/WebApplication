using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace koordinatGirme
{
    class firebasebaglanti
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            //AuthSecret = firebase connection,;
            //BasePath = Address of firebaselink;
        };

        public IFirebaseClient client;
        public FirebaseResponse response;
      
    }
    

}
