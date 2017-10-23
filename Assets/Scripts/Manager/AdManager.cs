
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
public class AdManager : MonoBehaviour {

//Admanager.Instance.ShowBanner();
	public static AdManager Instance{set; get;}

	public string bannerId;
	public string videoId;


	public string screenId;
 //ADManager.Instance.ShowBanner();

	// Use this for initializat 
public void Start()
{
			Instance = this;

      var admob = Admob.Instance();
      admob.initAdmob( bannerId, videoId );
      admob.setTesting( false );

      admob.loadRewardedVideo( videoId );
      admob.rewardedVideoEventHandler += rewardedVideoEvent;
 
  
	StartCoroutine(VidieoLoadingUpdate(	));
   }
   void rewardedVideoEvent( string eventName, string msg )
   {
      Debug.Log( string.Format( "eventName {0} msg {1}", eventName, msg ) );
      do
      {
         if( AdmobEvent.onAdClosed == eventName )
         {
            // 광고를 스킵하기 위해 닫거나, 모두 시정 완료 후 닫을 때 발생
            break;
         }
         if( AdmobEvent.onRewarded == eventName )
         {
			invoReward ();

            // 광고를 모두 시청한 경우 발생
            break;
         }
      }
      while( false );
   }


 


	public void ShowVideo()
	{
		Admob.Instance().initAdmob(bannerId, videoId);
		Admob.Instance().setTesting(false);
		Admob.Instance().loadRewardedVideo(videoId);


		if(!Admob.Instance().isRewardedVideoReady())
		{
			loadVideo();
		}
		if(Admob.Instance().isRewardedVideoReady())
		{
			getVideo();
			
		}
		// #endif 
	}	


   ////////////////////

	IEnumerator VidieoLoadingUpdate()
	{ 

		while(true){
		videoLoading ();
	
	yield return new WaitForSeconds(1f);
	
		}


	}
	// Update is called once per frame
	public void ShowBanner () {

		Admob.Instance().showBannerRelative(AdSize.Banner,AdPosition.TOP_LEFT, 4);
 	}

	public void HideBanner () {
		// #if UNITY_EDITOR
		// Debug.Log("Unable to play ads from EDITOR");
		// #elif UNITY_ANDROID
		Admob.Instance().removeBanner();
		// #endif
	}
/*
	public void ShowVideo_interstitial()
	{ 
		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from EDITOR");
		#elif UNITY_ANDROID
		if(Admob.Instance().isInterstitialReady())
		{ 
			Admob.Instance().showInterstitial();
		}
		#endif 
 

	}	
*/



	void loadVideo()
	{

		// #if UNITY_EDITOR
		// Debug.Log("");
		// #elif UNITY_ANDROID
		Admob.Instance().loadRewardedVideo(videoId);
		if(!Admob.Instance().isRewardedVideoReady())
		{
		ShowVideo();
		}

		// #endif
	}

	void getVideo()
	{
		// #if UNITY_EDITOR
		Debug.Log("Unable to play ads from EDITOR");
		// #elif UNITY_ANDROID

		if(Admob.Instance().isRewardedVideoReady())
		{
		Admob.Instance().showRewardedVideo();

		} 
		// #endif
	}



	public void videoLoading()
	{
 		if(!Admob.Instance().isRewardedVideoReady())
		{
		Admob.Instance().loadRewardedVideo(videoId);
		}
/*
		if(!Admob.Instance().isInterstitialReady())
		{
		Admob.Instance().loadInterstitial();
		}
*/
 	}



	public void ShowVideo2()
	{
		// #if UNITY_EDITOR
		Debug.Log("Unable to play ads from EDITOR");
		// #elif UNITY_ANDROID
		Admob.Instance().initAdmob(bannerId, videoId);
		Admob.Instance().setTesting(false);
		Admob.Instance().loadRewardedVideo(videoId);

		if(!Admob.Instance().isRewardedVideoReady())
		{
		loadVideo();
		}
		else if(Admob.Instance().isRewardedVideoReady())
		{
		getVideo();
		}
		// #endif
		if (Admob.Instance ().isRewardedVideoReady ()) {
			BtnReward (20);
		}


 	}/*
	public void HandleAdResult(ShowResult result)
	{
		switch (result) {
		case ShowResult.Finished:
			break;
		case ShowResult.Skipped:
			break;
		case ShowResult.Failed:
			break;
		}

	}
	*/

	void invoReward()
	{

		if(ControlTowerScript.controlTowerScript.SceneNumber==2){
		int rand = GameObject.FindGameObjectWithTag("Multiplier").GetComponent<ColliderScript>().rand ;
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().Exp_Battle *= rand;
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().Coin_Battle *= rand;
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().Crst_Battle *= rand;
		Debug.Log("rand:" +rand);
	 }

		if(ControlTowerScript.controlTowerScript.SceneNumber==1)
		{

						 	EggSpawnManager.Instances.GotEgg_ChangeTime();
			int a = Random.Range(0,100);
			{
				/*
				1) 산삼 5개
				2) 크리스탈 20개
				3) 랜덤 알
				4) 고급 알
				5) 
				 */
			}
		}

		

		if(ControlTowerScript.controlTowerScript.SceneNumber==7)
		{
			if(EggSpawnManager.Instances.whatAdsTake == 1)
			{
				EggSpawnManager.Instances.ad10mAuto=true;
				EggSpawnManager.Instances.whatAdsTake=0;
			}

			else if(EggSpawnManager.Instances.whatAdsTake == 2)
			{
				EggSpawnManager.Instances.ad5mAtk2times=true;
				EggSpawnManager.Instances.whatAdsTake=0;
			}
		// auto atk 10minute
		}
	}

	public void BtnReward(int crstReward)
	{
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript> ().cristals+= crstReward;
	}


}
