using MvvmCross.Platform.IoC;
using MvvmCross.Core.ViewModels;

namespace PhoneDirectory.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.ContactsListViewModel>();
        }
    }
}
