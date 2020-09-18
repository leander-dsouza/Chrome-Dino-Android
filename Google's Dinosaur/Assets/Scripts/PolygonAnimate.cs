using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonAnimate : MonoBehaviour
{

    public bool iStrigger ;
         //public PhysicsMaterial2D _material ;
     
         private SpriteRenderer spriteRenderer;
         private List<Sprite> spritesList;
         private Dictionary<int, PolygonCollider2D> spriteColliders;
         private bool _processing ;
     
         private int _frame ;
         public int Frame {
                 get { return _frame; }
                 set {
                         if (value != _frame) {
                                 if (value > -1) {
                                         spriteColliders [_frame].enabled = false;
                                         _frame = value;
                                         spriteColliders [_frame].enabled = true;
                                 } else {
                                         _processing = true;
                                         StartCoroutine (AddSpriteCollider (spriteRenderer.sprite));
                                 }
                         }
                 }
         }
 
         private IEnumerator AddSpriteCollider (Sprite sprite)
         {
                 spritesList.Add (sprite);
                 int index = spritesList.IndexOf (sprite);
                 PolygonCollider2D spriteCollider = gameObject.AddComponent<PolygonCollider2D> ();
                 spriteCollider.isTrigger = iStrigger;
                 //    spriteCollider.sharedMaterial = _material;
                 spriteColliders.Add (index, spriteCollider);
                 yield return new WaitForEndOfFrame ();
                 Frame = index;
                 _processing = false;
         }
     
         private void OnEnable ()
         {
                 spriteColliders [Frame].enabled = true;
         }
     
         private void OnDisable ()
         {
                 spriteColliders [Frame].enabled = false;
         }
 
         private void Awake ()
         {
                 spriteRenderer = this.GetComponent<SpriteRenderer> ();
         
                 spritesList = new List<Sprite> ();
         
                 spriteColliders = new Dictionary<int, PolygonCollider2D> ();
         
                 Frame = spritesList.IndexOf (spriteRenderer.sprite);
         }
     
         private void LateUpdate ()
         {
                 if (!_processing)
                         Frame = spritesList.IndexOf (spriteRenderer.sprite);
         }



}
