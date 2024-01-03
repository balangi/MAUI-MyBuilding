#nullable disable

using Microsoft.JSInterop;

namespace Farabeh.MyBuilding.Framework;

public static class JSRuntimeExtentions
{
    public static async Task CloseModal(this IJSRuntime jSRuntime, string htmlSelector)
    {
        await jSRuntime.InvokeVoidAsync("CloseModal", htmlSelector);
    }

    public static async Task OpenModal(this IJSRuntime jSRuntime, string htmlSelector)
    {
        await jSRuntime.InvokeVoidAsync("OpenModal", htmlSelector);
    }

    public static async Task ToastSuccess(this IJSRuntime jSRuntime, string message, string title = null)
    {
        await jSRuntime.InvokeVoidAsync("ToastSuccess", title, message);
    }

    public static async Task ToastWarning(this IJSRuntime jSRuntime, string message, string title = null)
    {
        await jSRuntime.InvokeVoidAsync("ToastWarning", title, message);
    }
    public static async Task ToastError(this IJSRuntime jSRuntime, string message, string title = "خطا")
    {
        await jSRuntime.InvokeVoidAsync("ToastError", title, message);
    }

    public static async Task AlertSuccess(this IJSRuntime jSRuntime, string message, string title = null)
    {
        await jSRuntime.InvokeVoidAsync("AlertSuccess", title, message);
    }

    public static async Task<bool> AlertConfirm(this IJSRuntime jSRuntime, string message, string title = null, string icon = "question")
    {
        return await jSRuntime.InvokeAsync<bool>("AlertConfirm", title, message, icon);
    }

    public static async Task AlertWarning(this IJSRuntime jSRuntime, string message, string title = null)
    {
        await jSRuntime.InvokeVoidAsync("AlertWarning", title, message);
    }

    public static async Task AlertError(this IJSRuntime jSRuntime, string message, string title = "خطا")
    {
        await jSRuntime.InvokeVoidAsync("AlertError", title, message);
    }
}
