using UnityEngine;
using UnityEditor;
using System.Collections;

public class Builder {

	[UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
	public static void BuildProjectAllSceneAndroid() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}
		PlayerSettings.productName = "Jenkins Test App";
		PlayerSettings.bundleIdentifier = "jp.co.hoge.hoge";
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer( allScene,
		                          "out.apk",
		                          BuildTarget.Android,
		                          BuildOptions.None
		                          );
	}
}
