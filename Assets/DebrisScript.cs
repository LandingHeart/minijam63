using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour
{
    // Start is called before the first frame update
   public ParticleSystem particle;

   public void InitDebris()
   {
        particle.Play();
   }

    public void StopDebris()
    {
        particle.Stop();

    }
}
