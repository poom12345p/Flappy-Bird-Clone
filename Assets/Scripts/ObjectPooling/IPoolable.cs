using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
   public GameObject OriginPref { get; set; }
   void OnGet();
   void OnRelease();
   void OnDestroy();
}
