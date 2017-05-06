package com.androidplugin.demo;

import android.annotation.TargetApi;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

@TargetApi(9)
public class MainActivity extends UnityPlayerActivity {

	public static final String TAG = "MainActivity";

	private static Context mContext;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		mContext = this;
	}

	@Override
	protected void onPause() {
		super.onPause();
	}

	@Override
	protected void onResume() {
		super.onResume();
	}
	
	public void purchase(final String payCode) {

		Log.e(TAG, "purchase payCode: " + payCode);

		runOnUiThread(new Runnable() {
			@Override
			public void run() {
				//write sdk call here  
				Toast.makeText(getApplicationContext(), "purchase success", 0).show();
			}
		});
		
		//call back to unity
		UnityPlayer.UnitySendMessage("AndroidPlugins", "OnPurchaseResult",
				"success");

	}
	
	public static void callStaticJavaFunc()
	{
		Log.e(TAG, "callStaticJavaFunc");
		
		((MainActivity) mContext).showMessage("callStaticJavaFunc");
	}
	
	public void callNormalJavaFunc()
	{
		Log.e(TAG, "callNormalJavaFunc");
		showMessage("callNormalJavaFunc");
	}

	private void showMessage(final String msg) {

		runOnUiThread(new Runnable() {
			@Override
			public void run() {
				Toast.makeText(getApplicationContext(), msg, 0).show();
			}
		});
	}
}