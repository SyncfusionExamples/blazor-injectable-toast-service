# Syncfusion Blazor Toast Sample

A modern **Blazor Web App** demonstrating best practices for integrating **Syncfusion UI components** (Toast Notifications, Progress Bar, and Tooltip) with clean, reusable service patterns and server-side rendering. Built with .NET 10 and designed for production-ready applications.

## Introduction

Sample showcases a complete implementation of Syncfusion Blazor components integrated into a web application with a focus on maintainability, user experience, and architectural best practices. The sample demonstrates how to build reusable notification systems, progress tracking, and contextual help components without code duplication across pages.

This project is intended for developers building modern Blazor applications who need robust UI components with proper state management and user isolation in multi-user scenarios.

## Project Features

- **Injectable Toast Service** — Display application notifications (success, info, warning, error) from any page by injecting a single service; the `ToastHost` component in the layout renders all messages.
- **Scoped Circuit Isolation** — Toast and service state remains isolated per user/circuit, preventing notifications from leaking between concurrent sessions.
- **Progress Bar Patterns** — Indeterminate progress (loading indicators) and determinate progress (upload tracking with real-time percentage updates).
- **Tooltip Component** — Contextual help with configurable positions (top, bottom, left, right), rich HTML content, and click-to-open behavior.
- **Single Toast Host Architecture** — One centralized `ToastHost` component in `MainLayout` eliminates the need to duplicate toast components and styling across every page.
- **Modern Rendering Model** — Static Server-Side Rendering (SSR) by default for performance; pages opt into `InteractiveServer` only when needed for interactivity.
- **Syncfusion Theme Integration** — Bootstrap 5 theme applied once globally; all components inherit consistent styling.

## How to Run the Sample

This sample is a single Blazor Web App project. No separate backend or client configuration is required.

### 1. Prerequisites

- **.NET 10 SDK** ([download](https://dotnet.microsoft.com/en-us/download/dotnet/10.0))
- A code editor (Visual Studio 2022, VS Code with C# extension, or JetBrains Rider)

### 2. Start the Application

```bash
# Clone the repository
git clone https://github.com/your-username/ToastSample.git
cd ToastSample

# Restore NuGet packages
dotnet restore

# Run the application
dotnet run
```

The app starts at **https://localhost:5001** (or another port if 5001 is in use). The exact URL is printed to the console.

### 3. Open in Browser

Navigate to the URL shown in the console output. The Home page loads automatically with links to all sample pages.

## Using the Sample

The application presents three interactive demos:

### Toast Notifications
- Navigate to `/toast`
- Click any button (Success, Info, Warning, Error, Custom) to trigger a toast notification
- Toasts appear in the top-right corner, slide in/out with animation, and auto-dismiss after 5 seconds (errors stay open until manually closed)
- Multiple toasts can be stacked without overwriting each other

### Progress Bar
- Navigate to `/progressbar`
- **Indeterminate Progress**: View linear and circular loaders (use instead of GIFs)
- **Real-world Example**: Click "Save" to see a loader during a simulated 3-second operation
- **Determinate Progress**: Click "Start upload" to watch a progress bar increment from 0–100%

### Tooltip
- Navigate to `/tooltip`
- Hover over buttons to see tooltips in different positions (top, right, bottom, left)
- Click the "Click me" button to see rich HTML content in a tooltip

All pages are fully interactive; editing templates, inserting fields, and creating custom regions work immediately without a backend. No configuration is required.

## Folder Structure

```
ToastSample/
├── Components/
│   ├── App.razor                          # Root app component; Syncfusion theme & script setup
│   ├── Routes.razor                       # Routing configuration
│   ├── Layout/
│   │   └── MainLayout.razor               # Main layout with single ToastHost
│   ├── Pages/
│   │   ├── Home.razor                     # Landing page (Static SSR)
│   │   ├── Toast.razor                    # Interactive toast demo
│   │   ├── ProgressBar.razor              # Interactive progress bar demo
│   │   ├── Tooltip.razor                  # Interactive tooltip demo
│   │   ├── Error.razor                    # Global error handler
│   │   └── NotFound.razor                 # 404 page
│   ├── Shared/
│   │   └── ToastHost.razor                # Single toast component (renders all toasts)
│   └── _Imports.razor                     # Global using statements & component imports
├── Services/
│   └── ToastService.cs                    # Injectable toast service
├── Properties/
│   └── launchSettings.json                # Debug/run configuration
├── wwwroot/
│   ├── app.css                            # Custom application styles
│   ├── favicon.png                        # Browser tab icon
│   └── lib/                               # Bootstrap & other client libraries
├── Program.cs                             # Application startup & DI configuration
├── ToastSample.csproj                     # Project file with NuGet package references
├── appsettings.json                       # Application settings (logging, hosts)
├── appsettings.Development.json           # Development-specific settings
└── README.md                              # This file
```

## Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| **.NET SDK** | 10.0 | Runtime & tooling |
| **Blazor Web App** | (integrated in .NET 10) | Web framework |
| **Syncfusion.Blazor.Buttons** | 35.1.43 | SfButton component |
| **Syncfusion.Blazor.Notifications** | 35.1.43 | SfToast component |
| **Syncfusion.Blazor.Popups** | 35.1.43 | SfTooltip component |
| **Syncfusion.Blazor.ProgressBar** | 35.1.43 | SfProgressBar component |
| **Syncfusion.Blazor.Themes** | 35.1.43 | Bootstrap 5 theme CSS |
| **Bootstrap** | 5.x | Responsive layout & utility classes |

## Rendering Modes & Pages

| Page | Route | Render Mode | Purpose |
|---|---|---|---|
| Home | `/` | Static SSR | Landing page with links to demos |
| Toast | `/toast` | Interactive Server | Toast notification demo |
| Progress Bar | `/progressbar` | Interactive Server | Loader and progress tracking |
| Tooltip | `/tooltip` | Interactive Server | Contextual help patterns |
| Error | `/error` | Static SSR | Global error handler |
| Not Found | `/not-found` | Static SSR | 404 page |

## APIs & Services Used

### ToastService (Custom Service)

Located in `Services/ToastService.cs`. Provides a simple, injectable interface for displaying notifications across the app.

| Method | Parameters | Purpose |
|---|---|---|
| `ShowToast(ToastOption)` | `ToastOption` object | Display a toast with full control over title, content, type, and timeout |
| `ShowSuccess(string, string?)` | content, title (optional) | Display a success toast |
| `ShowInfo(string, string?)` | content, title (optional) | Display an info toast |
| `ShowWarning(string, string?)` | content, title (optional) | Display a warning toast |
| `ShowError(string, string?)` | content, title (optional) | Display an error toast (no auto-dismiss) |

### Syncfusion Components

| Component | Namespace | Used In | Purpose |
|---|---|---|---|
| `SfToast` | `Syncfusion.Blazor.Notifications` | ToastHost.razor | Render toast notifications |
| `SfProgressBar` | `Syncfusion.Blazor.ProgressBar` | ProgressBar.razor | Display progress (linear/circular, determinate/indeterminate) |
| `SfTooltip` | `Syncfusion.Blazor.Popups` | Tooltip.razor | Display contextual help |
| `SfButton` | `Syncfusion.Blazor.Buttons` | All pages | Styled action buttons |

## Key Architecture Patterns

### 1. **Scoped Service Registration**
```csharp
// Program.cs
builder.Services.AddScoped<ToastService>();
```
Each user/circuit gets its own `ToastService` instance, preventing toasts from leaking between sessions in multi-user deployments.

### 2. **Single Toast Host**
```razor
<!-- MainLayout.razor -->
<ToastHost />  <!-- Once here, never repeated on other pages -->
```
All pages inherit `ToastHost` from the layout. Pages simply inject and call `ToastService`, which triggers events that `ToastHost` listens to.

### 3. **Event-Driven Communication**
```csharp
// ToastService.cs
public event Action<ToastOption>? ShowToastTrigger;

public void ShowToast(ToastOption options) 
    => ShowToastTrigger?.Invoke(options);
```
Pages call `ToastService.ShowToast()`, which raises an event. `ToastHost` subscribes and renders the toast.

### 4. **Interactive Server Rendering**
Pages with interactivity explicitly declare:
```razor
@rendermode InteractiveServer
```
Static pages (Home, Error, NotFound) omit this for better performance. Only interactive pages establish a WebSocket circuit.

### 5. **Proper Disposal**
```csharp
// ToastHost.razor.cs
public void Dispose()
{
    ToastService.ShowToastTrigger -= OnShowToast;
}
```
Event handlers are unsubscribed to prevent memory leaks when the circuit ends.

## Usage Examples

### Display a Success Toast
```csharp
@page "/mypage"
@rendermode InteractiveServer
@inject ToastService Toast

<SfButton OnClick="SaveRecord">Save</SfButton>

@code {
    private void SaveRecord()
    {
        // ... save logic ...
        Toast.ShowSuccess("Record saved successfully.");
    }
}
```

### Display a Custom Toast with Timeout
```csharp
Toast.ShowToast(new ToastOption
{
    Title = "Custom Title",
    Content = "This message auto-dismisses after 2 seconds.",
    Type = ToastType.Info,
    Timeout = 2000
});
```

### Show a Loader During Async Work
```csharp
<SfButton Disabled="@IsBusy" OnClick="ProcessAsync">Process</SfButton>

@if (IsBusy)
{
    <SfProgressBar Type="ProgressType.Linear" IsIndeterminate="true" />
}

@code {
    private bool IsBusy;

    private async Task ProcessAsync()
    {
        IsBusy = true;
        await Task.Delay(3000);  // Replace with real work
        IsBusy = false;
        Toast.ShowSuccess("Processing complete.");
    }
}
```

### Create a Tooltip on Any Element
```razor
<SfTooltip Content="This is a helpful tip">
    <SfButton>Hover me</SfButton>
</SfTooltip>
```

## Configuration

### Syncfusion Theme

The Bootstrap 5 theme is applied globally in `App.razor`:
```html
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" />
```

To use a different theme (Material, Fluent, etc.), replace `bootstrap5.css` with your preferred theme CSS.

### Toast Behavior

Default toast behavior is configured in `ToastHost.razor`:
```razor
<SfToast Timeout="5000" 
         ShowCloseButton="true" 
         ShowProgressBar="true" 
         NewestOnTop="true">
    <ToastPosition X="Right" Y="Top"></ToastPosition>
</SfToast>
```

Modify these properties to customize auto-dismiss time, button visibility, animation, and position.

### Logging

Logging configuration is in `appsettings.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## Resources

- **Product Page**: [Syncfusion Blazor Components](https://blazor.syncfusion.com/demos/)
- **Documentation**: [Syncfusion Blazor Documentation](https://blazor.syncfusion.com/documentation/introduction)
- **Toast Component**: [Toast Documentation](https://blazor.syncfusion.com/documentation/toast/getting-started)
- **Progress Bar**: [Progress Bar Documentation](https://blazor.syncfusion.com/documentation/progress-bar/getting-started)
- **Tooltip**: [Tooltip Documentation](https://blazor.syncfusion.com/documentation/tooltip/getting-started)

## Support and feedback

For any other queries, reach our [Syncfusion support team](https://support.syncfusion.com/?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples) or post the queries through the [community forums](https://www.syncfusion.com/forums?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples). 

Request new feature through [Syncfusion feedback portal](https://www.syncfusion.com/feedback?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples). 

## License

This is a commercial product and requires a paid license for possession or use. Syncfusion's licensed software, including this component, is subject to the terms and conditions of [Syncfusion's EULA](https://www.syncfusion.com/license/studio/35.1.37/syncfusion_essential_studio_eula.pdf?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples). You can purchase a license [here](https://www.syncfusion.com/sales/products?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples) or start a free 30-day trial [here](https://www.syncfusion.com/account/manage-trials/start-trials?utm_source=github&utm_medium=listing&utm_campaign=github-github-documenteditor-examples).
