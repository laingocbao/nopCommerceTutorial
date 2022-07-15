using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HelloWorld.Components;

[ViewComponent(Name = "HelloWorldWidget")]
public class ExampleWidgetViewComponent: NopViewComponent
{
    public IViewComponentResult Invoke(string widgetZone, object additionalData)
    {
        return Content("Lại Ngọc Bảo");
    }
}