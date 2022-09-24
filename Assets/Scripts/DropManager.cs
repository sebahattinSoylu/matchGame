using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
   AudioSource audioSource;

   private void Awake() {
    audioSource=GetComponent<AudioSource>();
   }

   public void YerlestiFNC()
   {
    audioSource.Play();
   }
}
