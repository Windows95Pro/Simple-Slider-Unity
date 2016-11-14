using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrolltest : MonoBehaviour {

	public Scrollbar scroll;
	public float timescroll = 2f;
	private IEnumerator coroutine;

	///  TOUCH http://pfonseca.com/swipe-detection-on-unity/

	void Start () {
		coroutine = testingen1(0.0f);
		StartCoroutine(coroutine);
	}
		
	void Update(){

		#if UNITY_EDITOR
		if (Input.touchCount == 0) {

			if (Input.GetMouseButton(0) ) {
				
				StopCoroutine(coroutine);

			}
			if (Input.GetMouseButtonUp(0) ) {
				if (scroll.value > 0.3f && scroll.value < 0.7f) {

					coroutine = testingen1(0.5f);
					StartCoroutine(coroutine);

					//StartCoroutine (testingen1(0.5f));


					Debug.Log ("menu2");

				} else if (scroll.value < 0.3f) {

					coroutine = testingen1(0.0f);
					StartCoroutine(coroutine);
					//StartCoroutine (testingen1(0.0f));


					Debug.Log ("menu1");

				} else if (scroll.value > 0.7f) {

					coroutine = testingen1(1.0f);
					StartCoroutine(coroutine);
					//StartCoroutine (testingen1(1.0f));

					Debug.Log ("menu3");
				}
			}
		}
		#endif

		if (Input.touchCount > 0) {
			Debug.Log ("touch");
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began:
				//	StopCoroutine ("menuenter1");
				//	StopCoroutine ("menuenter2");
				//	StopCoroutine ("menuenter3");
					StopCoroutine (coroutine);

					Debug.Log ("stopc");
					break;

				case TouchPhase.Canceled:


					break;

				case TouchPhase.Ended:

					if (scroll.value > 0.3f && scroll.value < 0.7f) {

						coroutine = testingen1(0.5f);
						StartCoroutine(coroutine);

						//StartCoroutine (testingen1(0.5f));


						Debug.Log ("menu2");

					} else if (scroll.value < 0.3f) {

						coroutine = testingen1(0.0f);
						StartCoroutine(coroutine);
						//StartCoroutine (testingen1(0.0f));


						Debug.Log ("menu1");

					} else if (scroll.value > 0.7f) {

						coroutine = testingen1(1.0f);
						StartCoroutine(coroutine);
						//StartCoroutine (testingen1(1.0f));

						Debug.Log ("menu3");
					}

				
					break;
				}
			}

		} 

	}
		
	public void enterscene(){

		Application.LoadLevelAsync ("Scene");
	}


	IEnumerator testingen1(float value_scroll){

		float elapsedTime = 0f;
		while (elapsedTime < timescroll)
		{
			scroll.value = Mathf.Lerp (scroll.value, value_scroll, Time.deltaTime * timescroll);
			elapsedTime += Time.deltaTime;
			Debug.Log ("in corou");
			yield return null;
		}

	}
}
