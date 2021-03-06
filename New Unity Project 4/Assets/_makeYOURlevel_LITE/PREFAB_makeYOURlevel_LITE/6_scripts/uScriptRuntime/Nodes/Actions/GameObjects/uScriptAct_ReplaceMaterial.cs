// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces an existing Material at the specified index on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Replace Material", "Replaces an existing Material at the specified index on the target GameObject with another Material.")]
public class uScriptAct_ReplaceMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to replace the material on.")]
      GameObject[] Target,

      [FriendlyName("Material Index", "The index of the material you wish to replace on the Target.")]
      int materialIndex,

      [FriendlyName("New Material", "The new material you wish to use.")]
      Material newMaterial
      )
   {
      if (null != newMaterial)
      {
         foreach (GameObject tmpTarget in Target)
         {
            if (null != tmpTarget)
            {
               try
               {
                  Material[] tmpMaterials = tmpTarget.renderer.materials;

                  // Check to make sure the specified index is in range
                  if (materialIndex < tmpMaterials.Length && materialIndex > -1)
                  {
                     tmpMaterials[materialIndex] = newMaterial;
                     tmpTarget.renderer.materials = tmpMaterials;
                  }
                  else
                  {
                     uScriptDebug.Log("(Node = Replace Material) The index supplied is outside the material index range on the specified Target GameObject (" + tmpTarget.name + ").");
                  }


               }
               catch (System.Exception e)
               {
                  uScriptDebug.Log("(Node = Replace Material) Could not replace the material on '" + tmpTarget.name + "'. " + e.ToString(), uScriptDebug.Type.Error);
               }
            }
         }
      }
      else
      {
         uScriptDebug.Log("(Node = Replace Material) The new material is empty (null), not replacing.");
      }
   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop(object o)
   {
      if (typeof(Material).IsAssignableFrom(o.GetType()))
      {
         Material ac = (Material)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Material"] = UnityEditor.AssetDatabase.GetAssetPath(ac.GetInstanceID());

         return hashtable;
      }
      if (typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()))
      {
         GameObject go = (GameObject)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Target"] = go.name;

         return hashtable;
      }

      return null;
   }
#endif


}