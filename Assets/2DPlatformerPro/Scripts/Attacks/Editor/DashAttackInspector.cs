#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlatformerPro
{
	/// <summary>
	/// Editor for dash attacks.
	/// </summary>
	[CustomEditor (typeof(DashAttack), false)]
	public class DashAttackInspector : BasicAttacksInspector
	{
		/// <summary>
		/// Draw the inspector GUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			// Always maintain control with a dash
			bool maintainControl = true;
			if (maintainControl != ((BasicAttacks)target).attackSystemWantsMovementControl)
			{
				((BasicAttacks)target).attackSystemWantsMovementControl = maintainControl;
				EditorUtility.SetDirty(target);
			}

			// Draw one attack
			if (((BasicAttacks)target).attacks == null)
			{ 
				((BasicAttacks)target).attacks = new List<BasicAttackData> ();
				((BasicAttacks)target).attacks.Add(new BasicAttackData());
				((BasicAttacks)target).attacks[0].name = "Dash";
				EditorUtility.SetDirty(target);
			}

			DrawBasicAttackEditor(((BasicAttacks)target).attacks[0]);

			float speed = EditorGUILayout.FloatField(new GUIContent("Dash Speed", "How fast the dash attack is"), ((DashAttack)target).dashSpeed);
			if (speed != ((DashAttack)target).dashSpeed && speed > 0.0f)
			{
				((DashAttack)target).dashSpeed = speed;
				EditorUtility.SetDirty(target);
			}
		}
	}
}