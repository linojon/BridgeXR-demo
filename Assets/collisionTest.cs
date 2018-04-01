using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour {

        public BxrInputIdentifier InputIdentifier;
        private BxrInputSender sender;

       
        void Start()
        {
            sender = GetComponent<BxrInputSender>();
        }

        private void OnCollisionEnter(Collision other)
        {
         //   OnTriggeredEvent.Invoke(InputIdentifier);
            sender.r
        }
    
}
