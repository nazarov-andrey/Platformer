using UnityEngine;
using System.Collections;

namespace PlatformerPro
{
	/// <summary>
	/// Condition which requires a specific item to be held.
	/// </summary>
	public class MustHaveItemCondition : AdditionalCondition
	{

		/// <summary>
		/// If this is not empty require the character to have an item with the matching type before triggering.
		/// </summary>
		[Tooltip ("If this is not empty require the character to have an item with the matching type to meet this condition.")]
		public string requiredItemType;

		/// <summary>
		/// Checks the condition. For example a check when entering a trigger.
		/// </summary>
		/// <returns><c>true</c>, if enter trigger was shoulded, <c>false</c> otherwise.</returns>
		/// <param name="character">Character.</param>
		/// <param name="other">Other.</param>
		override public bool CheckCondition(Character character, object other)
		{
			if (requiredItemType != null && requiredItemType != "")
			{
				ItemManager itemManager = character.GetComponentInChildren<ItemManager>();
				if (itemManager == null) 
				{
					Debug.LogWarning("Conditions requires an item but the character has no item manager.");
					return false;
				}
				if (itemManager.HasItem(requiredItemType)) return true;
				return false;
			}
			Debug.LogWarning("MustHaveItemCondition has no item configured.");
			return false;
		}

	}

}
