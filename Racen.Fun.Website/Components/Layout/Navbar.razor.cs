using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Racen.Fun.Website.Components.Layout
{
	public partial class Navbar
	{
		private bool isNavbarCollapsed = false;

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		private void ToggleNavbar()
		{
			isNavbarCollapsed = !isNavbarCollapsed;
		}

		private void NavigateToMain() => NavigateToSection("main");
		private void NavigateToGame() => NavigateToSection("game");
		private void NavigateToContact() => NavigateToSection("contact");

		private void NavigateToSection(string sectionId)
		{
			var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
			if (uri.AbsolutePath != "/")
			{
				NavigationManager.NavigateTo($"/#{sectionId}", forceLoad: true);
			}
			else
			{
				ScrollToSection(sectionId);
			}
		}

		private void ScrollToSection(string sectionId)
		{
			var script = $"document.getElementById('{sectionId}').scrollIntoView({{behavior: 'smooth'}});";
			JSRuntime.InvokeVoidAsync("eval", script);
		}
	}
}