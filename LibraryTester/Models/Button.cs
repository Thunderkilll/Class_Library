namespace Stt_ShowCase.Models
{
	public class Button
	{
		 
		public EventHandler<MyCustomArguments> ClickEvent;

		public void OnClick() {
			MyCustomArguments myCustomArguments = new MyCustomArguments();
			myCustomArguments.Name= "Khaled Guesmi";
			ClickEvent.Invoke(this , myCustomArguments);
		}
	}

	public class MyCustomArguments: EventArgs {
		public string Name { get; set; }
	}
}
