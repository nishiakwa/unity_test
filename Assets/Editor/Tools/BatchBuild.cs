using UnityEngine;
using UnityEditor;
using System.Collections;

public class BatchBuild
{
	static string bundleIdentifier = "com.zappallas.enterprise.toysparade";

	// シーンを Editor の設定から取り出す
	private static string[] GetScenes ()
	{
		ArrayList levels = new ArrayList ();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (scene.enabled) {
				levels.Add (scene.path);
			}
		}
		return (string[])levels.ToArray (typeof(string));
	}

	[UnityEditor.MenuItem("Tools/Build Android")]
	public static void BuildAndroid ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.Android);
		PlayerSettings.bundleIdentifier = bundleIdentifier;
		//PlayerSettings.bundleVersion = bundleVersion;
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer(GetScenes(), "android.apk", BuildTarget.Android, BuildOptions.None);
	}

	[UnityEditor.MenuItem("Tools/Build iOS")]
	public static void BuildiOS() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.iOS );
		BuildOptions opt = BuildOptions.SymlinkLibraries | BuildOptions.AllowDebugging | BuildOptions.Development;

		//BUILD for Device
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
		PlayerSettings.iOS.targetOSVersion = iOSTargetOSVersion.iOS_6_0;

		PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneAndiPad;

		PlayerSettings.bundleIdentifier = bundleIdentifier;
		//PlayerSettings.bundleVersion = bundleVersion;
//		PlayerSettings.statusBarHidden = true;
//		PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeRight;

		string errorMsg_Device = BuildPipeline.BuildPlayer(GetScenes(), "iOS", BuildTarget.iOS, opt);

		if (string.IsNullOrEmpty(errorMsg_Device)){

		} else {
			//エラー処理適当に		
		}
	}

}