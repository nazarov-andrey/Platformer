﻿using UnityEngine;
using System.Collections;

namespace PlatformerPro.Extras
{
	/// <summary>
	/// Base class for simple FX.
	/// </summary>
	public abstract class FX_Base : MonoBehaviour
	{
		/// <summary>
		/// Should we play this on awake.
		/// </summary>
		[Tooltip ("Start the effect immediately on Awake?")]
		public bool playOnAwake;

		/// <summary>
		/// If we have play on awake true but we are not enabled we will defer the play until we are enabled.
		/// </summary>
		protected bool playWhenEnabled;

		/// <summary>
		/// Unity Awake hook.
		/// </summary>
		void Awake()
		{
			if (playOnAwake)
			{
				if (enabled) DoEffect ();
				else playWhenEnabled = true;
			}
		}
		/// <summary>
		/// Unity OnEnable hook.
		/// </summary>
		void OnEnable()
		{
			if (playWhenEnabled) DoEffect ();
			playWhenEnabled = false;
		}

		/// <summary>
		/// Starts the effect.
		/// </summary>
		virtual public void StartEffect()
		{
			DoEffect ();
		}

		/// <summary>
		/// Starts the effect.
		/// </summary>
		/// <param name="callbackObject">Call back object.</param>
		/// <param name="function">Function to call.</param>
		virtual public void StartEffect(GameObject callbackObject, string function)
		{
			Debug.LogError ("This effect doesn't support call backs");
		}

		/// <summary>
		/// The effect implementation.
		/// </summary>
		abstract protected void DoEffect();
	}
}