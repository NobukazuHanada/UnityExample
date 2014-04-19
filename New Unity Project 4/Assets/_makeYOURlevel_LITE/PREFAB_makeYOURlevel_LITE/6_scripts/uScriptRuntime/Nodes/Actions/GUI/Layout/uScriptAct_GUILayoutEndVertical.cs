// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Close a control group started with a \"GUILayout Begin Vertical\" node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_EndVertical")]

[FriendlyName("GUILayout End Vertical", "Close a control group started with a \"GUILayout Begin Vertical\" node.")]
public class uScriptAct_GUILayoutEndVertical : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      GUILayout.EndVertical();
   }
}
