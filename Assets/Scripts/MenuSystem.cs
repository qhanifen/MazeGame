using UnityEngine;

namespace GearNex
{
	public class MenuSystem : MonoBehaviour
	{
		[SerializeField] Transform pool;
		[SerializeField] Transform activeObject;
		[SerializeField] string defaultMenu;


		void Awake ()
		{
			//DontDestroyOnLoad(transform.parent.gameObject);
		}

		void Start()
		{
			if (!string.IsNullOrEmpty(defaultMenu))
				PresentMenu(defaultMenu);
		}

		public void PresentMenu(string menuName)
		{
			HideMenu();
			pool.Find(menuName).SetParent(activeObject);
			UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		}

		public void HideMenu()
		{
			while (activeObject.childCount > 0)
				activeObject.GetChild(0).SetParent(pool);
		}

		public void FullScreen()
		{
		Screen.fullScreen = !Screen.fullScreen;
		}

		public void Tutorial(){
			Application.LoadLevel ("Tutorial");
			Time.timeScale = 1F;
		}

		public void Easy(){
			Application.LoadLevel ("Easy");
			Time.timeScale = 1F;
		}

		public void Medium(){
			Application.LoadLevel ("Medium");
			Time.timeScale = 1F;
		}

		public void Hard(){
			Application.LoadLevel ("Hard");
			Time.timeScale = 1F;
		}

		public void Exit(){
			Application.LoadLevel ("Title");
		}

}
}