// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Rect in a Rect List (uScript events must drive each iteration). Note that the list will be stored until all items have been iterated through or Reset is hit with a new list (which can only be done using named list variables).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List (Rect)", "Iterates through a list, one item at a time, and returns the current item.\n\nNote: uScript events must drive each iteration.")]
public class uScriptAct_ForEachListRect : uScriptLogic
{
   private Rect[] m_List = null;
   private int m_CurrentIndex = 0;
   private bool m_Done = false;
   private bool m_ImmediateDone = false;

   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Immediate
   {
      get
      { 
         if (!m_ImmediateDone)
         {
            m_ImmediateDone = true;
            return true; 
         }
         
         return false;
      } 
   }
   
   [FriendlyName("Done Iterating")]
   public bool Done { get { return m_Done; } }

   [FriendlyName("Iteration")]
   public bool Iteration { get { return m_List != null && m_CurrentIndex <= m_List.Length && m_CurrentIndex != 0; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in In()
   [FriendlyName("Reset")]
   public void Reset(Rect[] List, out Rect Value, out int currentIndex)
   {
      Value = new Rect(0,0,0,0);
      
      m_List = List;
      m_CurrentIndex = 0;
      currentIndex = m_CurrentIndex;
      m_Done = false;

      m_ImmediateDone = false;
   }

   public void In(
      [FriendlyName("List", "The list to iterate over.")]
      Rect[] List,

      [FriendlyName("Current", "The item for the current loop iteration.")]
      out Rect Value,

      [FriendlyName("Current Index", "The index value for the current loop iteration.")]
      [SocketState(false, false)]
      out int currentIndex
      )
   {
      if (m_List == null)
      {
         m_List = List;
         m_CurrentIndex = 0;
         m_Done = false;
      }

      m_ImmediateDone = !(m_List != null && m_CurrentIndex == 0);
      Value = new Rect(0,0,0,0);
      currentIndex = m_CurrentIndex;
      if (m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            Value = m_List[m_CurrentIndex];
            currentIndex = m_CurrentIndex;
         }
         m_CurrentIndex++;

         // done iterating
         if (m_CurrentIndex > m_List.Length)
         {
            m_List = null;
            m_Done = true;
         }
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
