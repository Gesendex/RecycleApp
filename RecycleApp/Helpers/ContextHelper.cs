using System.Windows.Controls;

namespace RecycleApp.Helpers
{
	public static class ContextHelper
	{
		public static TResult GetButtonContext<TResult>(object sender)
		{
			var button = sender as Button;
			var currentGCP = (TResult)button?.DataContext ?? default;

			return currentGCP;
		}

		public static TResult GetListViewItem<TResult>(object sender)
		{
			var listView = sender as ListView;
			var currentGCP = (TResult)listView?.SelectedItem ?? default;

			return currentGCP;
		}
		public static TResult GetComboBoxItem<TResult>(object sender)
		{
			var comboBox = sender as ComboBox;
			var currentGCP = (TResult)comboBox?.SelectedItem ?? default;

			return currentGCP;
		}
	}
}