
namespace Racen.Fun.Website.Components.Layout
{
	public partial class Navbar
	{
		private bool isNavbarCollapsed = false;


        public void ToggleNavbar()
		{
			isNavbarCollapsed = !isNavbarCollapsed;
		}
		public void HandleAnchorClick()
		{
			isNavbarCollapsed = false;
		}
	}
}
