namespace ToastSample.Services
{
    public enum ToastType
    {
        Info,
        Success,
        Warning,
        Error
    }

    public class ToastOption
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ToastType Type { get; set; } = ToastType.Info;

        /// <summary>Auto-hide delay in milliseconds. 0 keeps the toast open until closed.</summary>
        public int Timeout { get; set; } = 5000;
    }

    /// <summary>
    /// Injectable toast service. Register it as <b>Scoped</b> so every user (circuit) gets their own instance.
    /// A single &lt;ToastHost /&gt; in MainLayout listens to this service and renders the toasts,
    /// so pages only need: <c>@inject ToastService Toast</c> and <c>Toast.ShowSuccess("Saved")</c>.
    /// </summary>
    public class ToastService
    {
        public event Action<ToastOption>? ShowToastTrigger;

        public void ShowToast(ToastOption options) => ShowToastTrigger?.Invoke(options);

        public void ShowInfo(string content, string title = "Information") =>
            ShowToast(new ToastOption { Title = title, Content = content, Type = ToastType.Info });

        public void ShowSuccess(string content, string title = "Success") =>
            ShowToast(new ToastOption { Title = title, Content = content, Type = ToastType.Success });

        public void ShowWarning(string content, string title = "Warning") =>
            ShowToast(new ToastOption { Title = title, Content = content, Type = ToastType.Warning });

        public void ShowError(string content, string title = "Error") =>
            ShowToast(new ToastOption { Title = title, Content = content, Type = ToastType.Error, Timeout = 0 });
    }
}
