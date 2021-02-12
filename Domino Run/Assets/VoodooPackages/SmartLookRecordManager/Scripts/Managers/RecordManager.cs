using UnityEngine;

namespace VoodooPackages.Tool
{

	[HelpURL("https://voodoo.atlassian.net/wiki/x/GYDtD")]
	public class RecordManager : MonoBehaviour
	{

		[Tooltip("Find this key on the Manage Project tab from the SmartLook website")]
		public string smartLookKey = "";

		public bool testOnDevBuild = false;



		void Awake()
		{

			#if UNITY_IOS

			DontDestroyOnLoad(gameObject);

			if (Debug.isDebugBuild && testOnDevBuild)
			{
				Smartlook.Init(smartLookKey, 10);
			}
			else
			{
				switch (Device.generation)
				{
					case DeviceGeneration.iPhone8:
					case DeviceGeneration.iPhone8Plus:
					case DeviceGeneration.iPhoneX:
					{
						Smartlook.Init(smartLookKey, 10);
						break;
					}
				}
			}
			#endif
		}


	}
}