using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {

        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.name == "DestroyThis")
            {
                Destroy(col.gameObject);
            }
    }
    
}
