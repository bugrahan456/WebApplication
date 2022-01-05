using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace Map
{
    class firebasebaglanti
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            //AuthSecret = "firebase baglanti kodu",
            //BasePath = "fireabase veritabani baglanti adresi "
        };

        public IFirebaseClient client;
        public FirebaseResponse response;
    }
}
